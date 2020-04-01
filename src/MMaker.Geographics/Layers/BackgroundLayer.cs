using BruTile;
using BruTile.Cache;
using DotSpatial.Controls;
using DotSpatial.Data;
using DotSpatial.Projections;
using DotSpatial.Symbology;
using GeoAPI.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Threading;

#pragma warning disable CS0168, CS0067

namespace MMaker.Geographics.Layers
{
    public class BackgroundLayer : IMapLayer
    {
        public ITileSource TileSource { get; private set; }
        public ITileCache<byte[]> TileCache { get; private set; }
        public bool ShowErrorInTile = true;

        public BackgroundLayer(ITileSource tileSource, ITileCache<byte[]> tileCache)
        {
            TileSource = tileSource;
            TileCache = tileCache ?? new MemoryCache<byte[]>(200, 300);
            int epsgCode;
            if (int.TryParse(TileSource.Schema.Srs.Substring(5), out epsgCode))
            {
                _projection = new ProjectionInfo();
                _projection = ProjectionInfo.FromEpsgCode(epsgCode);
            }
            else
                _projection = KnownCoordinateSystems.Projected.World.WebMercator;

            LegendItemVisible = true;
        }

        private readonly ProjectionInfo _projection;

        private static void AddAllProperties(List<string> properties)
        {
            properties.AddRange(new[] { "TileSource", "TileCache", "ShowErrorsInTile" });
        }

        #region IMapLayer Interface
        public IDataSet DataSet
        {
            get { return null; }
            set { }
        }

        public DotSpatial.Data.Extent InvalidRegion
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

        public IFrame MapFrame { get; set; }
        public IProgressHandler ProgressHandler { get; set; }
        public List<SymbologyMenuItem> ContextMenuItems
        {
            get { return null; }
            set { }
        }
        public bool Checked { get; set; }
        public bool IsExpanded { get; set; }
        public bool IsSelected { get; set; }

        public IEnumerable<ILegendItem> LegendItems
        {
            get { yield break; }
        }

        public bool LegendItemVisible { get; set; }

        public SymbolMode LegendSymbolMode => SymbolMode.Symbol;

        public string LegendText
        {
            get { return TileSource.ToString(); }
            set { }
        }
        public bool LegendTextReadOnly { get; set; }

        public LegendType LegendType => LegendType.Custom;

        public DotSpatial.Data.Extent Extent
        {
            get
            {
                var tileExtent = TileSource.Schema.Extent;
                return new DotSpatial.Data.Extent(tileExtent.MinX, tileExtent.MinY, tileExtent.MaxX, tileExtent.MaxY);
            }
        }

        public bool IsInitialized => true;

        public bool IsVisible { get; set; }
        public bool SelectionEnabled
        {
            get { return false; }
            set { }
        }
        public double DynamicVisibilityWidth { get; set; }
        public DynamicVisibilityMode DynamicVisibilityMode { get; set; }
        public bool UseDynamicVisibility
        {
            get { return false; }
            set { }
        }

        public bool IsDisposeLocked => false;

        public bool CanReproject => false;

        public ProjectionInfo Projection
        {
            get { return _projection; }
            set { }
        }
        public string ProjectionString
        {
            get { return _projection.ToProj4String(); }
            set { }
        }

        public event HandledEventHandler ShowProperties;
        public event EventHandler<EnvelopeArgs> ZoomToLayer;
        public event EventHandler<LayerSelectedEventArgs> LayerSelected;
        public event EventHandler FinishedLoading;
        public event EventHandler ItemChanged;
        public event EventHandler RemoveItem;
        public event EventHandler<EnvelopeArgs> EnvelopeChanged;
        public event EventHandler Invalidated;
        public event EventHandler VisibleChanged;
        public event EventHandler SelectionChanged;

        public bool CanReceiveItem(ILegendItem item)
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

        public void CopyProperties(object other)
        {
            if (!(other is BackgroundLayer otherBrutileLayer))
                throw new ArgumentException();
        }

        public void Dispose()
        {
            ;
        }

        public void DrawRegions(MapArgs args, List<DotSpatial.Data.Extent> regions)
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
                using (Image bitmap = Image.FromStream(new MemoryStream(TileCache.Find(info.Index))))
                {
                    PointF min = args.ProjToPixel(new Coordinate(info.Extent.MinX, info.Extent.MinY));
                    PointF max = args.ProjToPixel(new Coordinate(info.Extent.MaxX, info.Extent.MaxY));

                    min = new PointF((float)Math.Round(min.X), (float)Math.Round(min.Y));
                    max = new PointF((float)Math.Round(max.X), (float)Math.Round(max.Y));

                    args.Device.DrawImage(bitmap, new Rectangle((int)min.X, (int)max.Y, (int)(max.X - min.X), (int)(min.Y - max.Y)),
                                0, 0, TileSource.Schema.GetTileWidth(info.Index.Level), TileSource.Schema.GetTileHeight(info.Index.Level), GraphicsUnit.Pixel);

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


                //todo: log and use other ways to report to user.
            }
            finally
            {
                autoResetEvent.Set();
            }
        }

        public Size GetLegendSymbolSize()
        {
            return new Size(25, 25);
        }

        private ILegendItem _parentItem;
        public ILegendItem GetParentItem()
        {
            return _parentItem;
        }

        public void Invalidate(DotSpatial.Data.Extent region)
        {
            ;
        }

        public void Invalidate()
        {
            ;
        }

        public bool InvertSelection(Envelope tolerant, Envelope strict, SelectionMode mode, out Envelope affectedArea)
        {
            affectedArea = null;
            return false;
        }

        public bool IsWithinLegendSelection()
        {
            return true;
        }

        public void LegendSymbol_Painted(Graphics g, Rectangle box)
        {
            //g.DrawImage(Properties.Resources.BruTileLogoBig, box);
        }

        public void LockDispose()
        {
            ;
        }

        public bool Matches(IMatchable other, out List<string> mismatchedProperties)
        {
            var matches = true;

            mismatchedProperties = new List<string>();
            var otherBruTileLayer = other as BackgroundLayer;
            if (otherBruTileLayer == null)
            {
                AddAllProperties(mismatchedProperties);
                return false;
            }

            if (!ReferenceEquals(TileSource, otherBruTileLayer.TileSource))
            {
                mismatchedProperties.Add("TileSource");
                matches = false;
            }

            if (!ReferenceEquals(TileCache, otherBruTileLayer.TileCache))
            {
                mismatchedProperties.Add("TileCache");
                matches = false;
            }

            if (ShowErrorInTile != otherBruTileLayer.ShowErrorInTile)
            {
                mismatchedProperties.Add("ShowErrorInTile");
                matches = false;
            }

            return matches;
        }

        public void PrintLegendItem(Graphics g, Font font, Color fontColor, SizeF maxExtent)
        {
            g.DrawString(TileSource.Schema.Name, font, new SolidBrush(fontColor), new RectangleF(new PointF(0, 0), maxExtent));
        }

        public void Randomize(Random generator)
        {
            ;
        }

        public void Reproject(ProjectionInfo targetProjection)
        {
            ;
        }

        public bool Select(Envelope tolerant, Envelope strict, SelectionMode mode, out Envelope affectedArea)
        {
            affectedArea = null;
            return false;
        }

        public void SetParentItem(ILegendItem value)
        {
            _parentItem = value;
        }

        public void UnlockDispose()
        {
            ;
        }

        public bool UnSelect(Envelope tolerant, Envelope strict, SelectionMode mode, out Envelope affectedArea)
        {
            affectedArea = null;
            return false;
        }

        public bool VisibleAtExtent(DotSpatial.Data.Extent geographicExtent)
        {
            return Extent.Intersects(geographicExtent);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <param name="regions"></param>
        /// <param name="selected"></param>
        public void DrawRegions(MapArgs args, List<DotSpatial.Data.Extent> regions, bool selected)
        {
            DrawRegions(args, regions);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="box"></param>
        public void LegendSymbolPainted(Graphics g, Rectangle box)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="affectedArea"></param>
        /// <param name="force"></param>
        /// <returns></returns>
        public bool ClearSelection(out Envelope affectedArea, bool force)
        {
            return ClearSelection(out affectedArea);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tolerant"></param>
        /// <param name="strict"></param>
        /// <param name="mode"></param>
        /// <param name="affectedArea"></param>
        /// <param name="clear"></param>
        /// <returns></returns>
        public bool Select(Envelope tolerant, Envelope strict, SelectionMode mode, out Envelope affectedArea, ClearStates clear)
        {
            return Select(tolerant, strict, mode, out affectedArea);
        }
        #endregion IMapLayer Interface
        //public BackgroundLayer(ITileSource tileSource, string name, int order)
        //    : base(tileSource)
        //{
        //    Name = name;
        //    Order = order;
        //    CRS = tileSource.Schema.Srs;
        //}
        public int Order { get; set; }


    }
}
