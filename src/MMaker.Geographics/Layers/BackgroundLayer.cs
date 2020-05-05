using BruTile;
using BruTile.Cache;

using DotSpatial.Controls;
using DotSpatial.Data;
using DotSpatial.Projections;
using DotSpatial.Symbology;

using GeoAPI.Geometries;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Threading;

#pragma warning disable CS0168, CS0067

namespace MMaker.Geographics.Layers
{
    public class BackgroundLayer : ImageLayer, IMapImageLayer
    {
        public ITileSource TileSource { get; private set; }
        public ITileCache<byte[]> TileCache { get; private set; }

        public bool ShowErrorInTile = true;
        private readonly ProjectionInfo _projection;

        public BackgroundLayer(ITileSource tileSource, ITileCache<byte[]> tileCache)
        {
            TileSource = tileSource;
            TileCache = tileCache ?? new MemoryCache<byte[]>(200, 300);
            if (int.TryParse(TileSource.Schema.Srs.Substring(5), out int epsgCode))
            {
                _projection = new ProjectionInfo();
                _projection = ProjectionInfo.FromEpsgCode(epsgCode);
            }
            else
                _projection = KnownCoordinateSystems.Projected.World.WebMercator;

            LegendItemVisible = true;
        }
        private static void AddAllProperties(List<string> properties)
        {
            properties.AddRange(new[] { "TileSource", "TileCache", "ShowErrorsInTile" });
        }

        #region IMapLayer Interface

        public override DotSpatial.Data.Extent InvalidRegion
        {
            get
            {
                if (MapFrame != null && MapFrame.ViewExtents != null)
                    return MapFrame.ViewExtents;

                return null;
            }
        }
        private static BruTile.Extent ToBrutileExtent(DotSpatial.Data.Extent extent)
        {
            return new BruTile.Extent(extent.MinX, extent.MinY, extent.MaxX, extent.MaxY);
        }
        public override List<SymbologyMenuItem> ContextMenuItems
        {
            get
            {
                return new List<SymbologyMenuItem>
                {
                }; // null;
            }
            set { }
        }
        public override IEnumerable<ILegendItem> LegendItems
        {
            get { yield break; }
        }
        public override string LegendText
        {
            get { return TileSource.ToString(); }
            set { }
        }
        public override DotSpatial.Data.Extent Extent
        {
            get
            {
                var tileExtent = TileSource.Schema.Extent;
                return new DotSpatial.Data.Extent(tileExtent.MinX, tileExtent.MinY, tileExtent.MaxX, tileExtent.MaxY);
            }
        }
        public new ProjectionInfo Projection
        {
            get { return _projection; }
            set { }
        }
        public new string ProjectionString
        {
            get { return _projection.ToProj4String(); }
            set { }
        }

        public override bool CanReceiveItem(ILegendItem item)
        {
            return false;
        }
        public bool ClearSelection(out Envelope affectedArea)
        {
            affectedArea = null;
            return false;
        }
        public object Clone()
        {
            return new BackgroundLayer(TileSource, TileCache) { ShowErrorInTile = ShowErrorInTile };
        }
        public new void CopyProperties(object other)
        {
            if (!(other is BackgroundLayer otherBrutileLayer))
                throw new ArgumentException();
        }
        public void DrawRegions(MapArgs args, List<DotSpatial.Data.Extent> regions, bool selected)
        {
            BruTile.Extent extent = ToBrutileExtent(args.GeographicExtents);
            var pixelSize = extent.Width / args.ImageRectangle.Width;

            var level = Utilities.GetNearestLevel(TileSource.Schema.Resolutions, pixelSize);
            var tiles = TileSource.Schema.GetTileInfos(extent, level);

            IList<WaitHandle> waitHandles = new List<WaitHandle>();

            foreach (TileInfo info in tiles)
            {
                if (TileCache.Find(info.Index) != null) continue;
                AutoResetEvent waitHandle = new AutoResetEvent(false);
                waitHandles.Add(waitHandle);
                ThreadPool.QueueUserWorkItem(GetTileOnThread, new object[] { TileSource, info, TileCache, waitHandle });
            }

            foreach (WaitHandle handle in waitHandles)
                handle.WaitOne();

            foreach (TileInfo info in tiles)
            {
                using (Image bitmap = System.Drawing.Image.FromStream(new MemoryStream(TileCache.Find(info.Index))))
                {
                    PointF min = args.ProjToPixel(new Coordinate(info.Extent.MinX, info.Extent.MinY));
                    PointF max = args.ProjToPixel(new Coordinate(info.Extent.MaxX, info.Extent.MaxY));

                    min = new PointF((float)Math.Round(min.X), (float)Math.Round(min.Y));
                    max = new PointF((float)Math.Round(max.X), (float)Math.Round(max.Y));

                    ColorMatrix matrix = new ColorMatrix { Matrix33 = 0.45f }; // Symbolizer.Opacity
                    using (var attributes = new ImageAttributes())
                    {
                        attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                        args.Device.DrawImage(bitmap
                            , new Rectangle((int)min.X, (int)max.Y, (int)(max.X - min.X), (int)(min.Y - max.Y))
                            , 0
                            , 0
                            , TileSource.Schema.GetTileWidth(info.Index.Level)
                            , TileSource.Schema.GetTileHeight(info.Index.Level)
                            , GraphicsUnit.Pixel
                            , attributes);
                    }
                }
            }
        }
        private void GetTileOnThread(object parameter)
        {
            object[] parameters = (object[])parameter;
            if (parameters.Length != 4) throw new ArgumentException("Four parameters expected");
            ITileProvider tileProvider = (ITileProvider)parameters[0];
            TileInfo tileInfo = (TileInfo)parameters[1];
            ITileCache<byte[]> bitmaps = (ITileCache<byte[]>)parameters[2];
            AutoResetEvent autoResetEvent = (AutoResetEvent)parameters[3];
            
            try
            {
                byte[] bytes = tileProvider.GetTile(tileInfo);
                Bitmap bitmap = new Bitmap(new MemoryStream(bytes));
                bitmaps.Add(tileInfo.Index, bytes);
            }
            catch (WebException ex)
            {
                if (ShowErrorInTile)
                {
                    //an issue with this method is that one an error tile is in the memory cache it will stay even
                    //if the error is resolved. PDD.
                    var width = TileSource.Schema.GetTileWidth(tileInfo.Index.Level);
                    var height = TileSource.Schema.GetTileHeight(tileInfo.Index.Level);
                    Bitmap bitmap = new Bitmap(width, height);
                    Graphics graphics = Graphics.FromImage(bitmap);
                    graphics.DrawString(ex.Message, new Font(FontFamily.GenericSansSerif, 12), new SolidBrush(Color.Black),
                        new RectangleF(0, 0, width, height));
                    graphics.Dispose();

                    using (MemoryStream m = new MemoryStream())
                    {
                        bitmap.Save(m, ImageFormat.Png);
                        bitmaps.Add(tileInfo.Index, m.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                StackFrame CallStack = new StackFrame(1, true);
                Trace.WriteLine("Error: " + ex.Message + ", File: " + CallStack.GetFileName() + ", Line: " + CallStack.GetFileLineNumber());
            }
            finally
            {
                autoResetEvent.Set();
            }
        }

        #endregion IMapLayer Interface
    }
}
