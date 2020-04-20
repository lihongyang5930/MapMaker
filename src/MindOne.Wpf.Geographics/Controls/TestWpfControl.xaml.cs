using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using Epanet.Native.Ver21;
using Mapsui.Layers;
using Mapsui.Styles;
using MindOne.Wpf.Geographics.CoordinateSystems;
using Brush = Mapsui.Styles.Brush;
using Color = Mapsui.Styles.Color;
using Pen = Mapsui.Styles.Pen;
using Style = Mapsui.Styles.Style;

namespace MindOne.Wpf.Geographics.Controls
{
    /// <summary>
    /// TestWpfControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TestWpfControl : UserControl
    {
        IStyle _linkF025Style = new VectorStyle() { Line = new Mapsui.Styles.Pen { Color = Colors.DodgerBlue .ToMapsui() } };
        IStyle _linkF050Style = new VectorStyle() { Line = new Mapsui.Styles.Pen { Color = Colors.Green      .ToMapsui() } };
        IStyle _linkF075Style = new VectorStyle() { Line = new Mapsui.Styles.Pen { Color = Colors.GreenYellow.ToMapsui() } };
        IStyle _linkF100Style = new VectorStyle() { Line = new Mapsui.Styles.Pen { Color = Colors.Gold       .ToMapsui() } };
        IStyle _linkF999Style = new VectorStyle() { Line = new Mapsui.Styles.Pen { Color = Colors.Tomato     .ToMapsui() } };

        IStyle _nodeP00Style  = new SymbolStyle() { Fill = new Mapsui.Styles.Brush( Colors.Gray       .ToMapsui() ), SymbolScale = 0.3, SymbolType = SymbolType.Ellipse  };
        IStyle _nodeP20Style  = new SymbolStyle() { Fill = new Mapsui.Styles.Brush( Colors.DodgerBlue .ToMapsui() ), SymbolScale = 0.3, SymbolType = SymbolType.Ellipse  };
        IStyle _nodeP40Style  = new SymbolStyle() { Fill = new Mapsui.Styles.Brush( Colors.ForestGreen.ToMapsui() ), SymbolScale = 0.3, SymbolType = SymbolType.Ellipse  };
        IStyle _nodeP70Style  = new SymbolStyle() { Fill = new Mapsui.Styles.Brush( Colors.Tomato     .ToMapsui() ), SymbolScale = 0.3, SymbolType = SymbolType.Ellipse  };
        IStyle _nodeP99Style  = new SymbolStyle() { Fill = new Mapsui.Styles.Brush( Colors.Red        .ToMapsui() ), SymbolScale = 0.3, SymbolType = SymbolType.Ellipse  };


        public TestWpfControl()
        {
            InitializeComponent();

            Loaded += async (s, e) => { 
                //
                //return;
                var factory = new MindOne.Wpf.Geographics.Layers.BackgroundLayerFactory();
                var layers  = await factory.GetKakaoMap();

                foreach (var l in layers.Layers)
                {
                    l.Enabled = true;
                    mapControl.Map.CRS = l.CRS;
                    mapControl.Map.Layers.Add(l);


                     // 거제도
                    //var latitude   = GeoAngle.CreateLatitude ( 34, 53,  0.12);
                    //var longitude  = GeoAngle.CreateLongitude(128, 37, 44.31);
                    //var center     = new LatLon(latitude, longitude);
                    //var coordinate = CRSUtil.FromLatLon(l.CRS, center);
                    //
                    //mapControl.Navigator.NavigateTo(new Mapsui.Geometries.Point(coordinate.X, coordinate.Y), 11);
                    //mapControl.Refresh();
                    break;
                }


               await Load();
            };
            
        }

        private async Task Load()
        {
            var service     = new EpanetService();
            service.InpPath = @"Samples\INP(Dr-누수량배분-연결요소수정).inp";
            service.Run();

            var nodeLayer = new WritableLayer() { Style = GetNodeLayerStyle() };
            var linkLayer = new WritableLayer() { Style = GetLinkLayerStyle() };

            foreach (var node in service.Nodes)
            {
                var point   = new Mapsui.Geometries.Point(node.X, node.Y);
                var feature = new Mapsui.Providers .Feature();
                feature.Geometry = point;
                nodeLayer.Add(feature);
            }

            foreach (var link in service.Links)
            {
                var vertices = new List<Mapsui.Geometries.Point>();
                vertices.Add(new Mapsui.Geometries.Point(link.Node1.X, link.Node1.Y));
                foreach (var v in link.Vertices)
                {
                    vertices.Add(new Mapsui.Geometries.Point(v.X, v.Y));
                }
                vertices.Add(new Mapsui.Geometries.Point(link.Node2.X, link.Node2.Y));
                var lineString = new Mapsui.Geometries.LineString(vertices);
                var feature    = new Mapsui.Providers .Feature();
                feature.Geometry = lineString;
                linkLayer.Add(feature);
            }

            mapControl.Map.Layers.Add(nodeLayer);
            mapControl.Map.Layers.Add(linkLayer);

            var p = (Mapsui.Geometries.Point)nodeLayer.GetFeatures().First().Geometry;
            mapControl.Navigator.NavigateTo(p, 11);

            await Animation(service, nodeLayer);
        }

        private async Task Animation(EpanetService service, WritableLayer nodeLayer)
        {
            while (true)
            {
                foreach (var t in service.TimeSteps)
                {
                    await Task.Delay(200);
                    foreach (var n in service.Nodes)
                    {
                        var value = n.GetValue(t);
                        var f     = nodeLayer
                                        .GetFeatures()
                                        .Where(x => ((Mapsui.Geometries.Point)x.Geometry).X == n.X)
                                        .Where(x => ((Mapsui.Geometries.Point)x.Geometry).Y == n.Y)
                                        .FirstOrDefault();
                        if (f == null)
                            continue;
                        f.Styles.Clear();
                        if (value.Pressure <= 0)
                        {
                            f.Styles.Add(_nodeP00Style);
                        }
                        else
                        if (value.Pressure <= 20)
                        {
                            f.Styles.Add(_nodeP20Style);
                        }
                        else
                        if (value.Pressure <= 40)
                        {
                            f.Styles.Add(_nodeP40Style);
                        }
                        else
                        if (value.Pressure <= 70)
                        {
                            f.Styles.Add(_nodeP70Style);
                        }
                        else
                        {
                            f.Styles.Add(_nodeP99Style);
                        }
                    }
                    //txtTimeStep.Text = t.ToString();
                    mapControl.Refresh();
                }
            }
            
        }

        private IStyle GetNodeLayerStyle()
        {
            var s = new SymbolStyle();
            s.Fill        = new Mapsui.Styles.Brush( Colors.Black.ToMapsui() );
            s.SymbolScale = 0.3;
            s.SymbolType  = SymbolType.Ellipse;
            return s;
        }
        private IStyle GetLinkLayerStyle()
        {
            var s = new VectorStyle();
            s.Line          = new Mapsui.Styles.Pen();
            s.Line.PenStyle = PenStyle    .Solid;
            s.Line.Color    = Colors.Black.ToMapsui();
            s.Line.Width    = 1.0;
            return s;
        }
    }

    public static class MapsuiStylesExtensions
    {
        public static IStyle Copy(this IStyle source)
        {
            if (source is SymbolStyle symbolStyle)
            {
                var result = new SymbolStyle();
                return Copy(symbolStyle, result);
            }
            if (source is VectorStyle vectorStyle)
            {
                var result = new VectorStyle();
                return Copy(vectorStyle, result);
            }
            if (source is Style style)
            {
                var result = new Style();
                return Copy(style, result);
            }
            throw new NotImplementedException();
        }
        private static SymbolStyle Copy(SymbolStyle source, SymbolStyle dest)
        {
            dest.BitmapId       = source.BitmapId;
            dest.SymbolScale    = source.SymbolScale;
            dest.SymbolOffset   = source.SymbolOffset.Copy();
            dest.SymbolRotation = source.SymbolRotation;
            dest.RotateWithMap  = source.RotateWithMap;
            dest.UnitType       = source.UnitType;
            dest.SymbolType     = source.SymbolType;
            Copy((VectorStyle)source, dest);
            return dest;
        }
        private static VectorStyle Copy(this VectorStyle source, VectorStyle dest)
        {
            dest.Line    = source.Line.Copy();
            dest.Outline = source.Line.Copy();
            dest.Fill    = source.Fill.Copy();
            Copy((Style)source, dest);
            return dest;
        }
        private static Style Copy(Style source, Style dest)
        {
            dest.MinVisible = source.MinVisible;
            dest.MaxVisible = source.MaxVisible;
            dest.Enabled    = source.Enabled;
            dest.Opacity    = source.Opacity;
            return dest;
        }

        public static Pen Copy(this Pen pen)
        {
            if (pen == null)
                return null;
            return new Pen { 
                Width            = pen.Width,
                Color            = pen.Color.Copy(),
                PenStyle         = pen.PenStyle,
                DashArray        = pen.DashArray,
                PenStrokeCap     = pen.PenStrokeCap,
                StrokeJoin       = pen.StrokeJoin,
                StrokeMiterLimit = pen.StrokeMiterLimit
            };
        }
        public static Brush Copy(this Brush brush)
        {
            if (brush == null)
                return null;
            return new Brush { 
                Color       = brush.Color.Copy(),
                Background  = brush.Background.Copy(),
                BitmapId    = brush.BitmapId,
                FillStyle   = brush.FillStyle
            };
        }
        public static Color Copy(this Color color)
        {
            if (color == null)
                return null;
            return new Color(color.R, color.G, color.B, color.A);
        }
        public static Offset Copy(this Offset offset)
        {
            return new Offset(offset.X, offset.Y, offset.IsRelative);
        }

        public static Color ToMapsui(this System.Windows.Media.Color color)
        {
            return new Color(color.R, color.G,color.B, color.A);
        }
        public static Brush ToMapsui(this System.Windows.Media.SolidColorBrush brush)
        {
            var c = brush.Color.ToMapsui();
            var b = new Brush(c);
            return b;
        }
    }
}
