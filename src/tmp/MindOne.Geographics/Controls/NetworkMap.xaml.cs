using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using BruTile;
using BruTile.Predefined;
using Epanet.Network;
using Mapsui;
using Mapsui.Layers;
using Mapsui.Styles;
using MindOne.Epanet;
using MindOne.Epanet.Models;
using MindOne.Geographics.Layers;
using Link    = Epanet.Network.Structures.Link;
using Node2   = Epanet.Network.Structures.Node;
using EnPoint = Epanet.Network.Structures.EnPoint;

namespace MindOne.Geographics.Controls
{
    public partial class NetworkMap : UserControl
    {
        BackgroundLayerSet _backgroundLayerSet;
        Legend _nodeLegend;
        Legend _linkLegend;
        Mapsui.Styles.Color _defaultColor;
        Dictionary<Mapsui.Providers.Feature, Node2> _nodes;
        Dictionary<Mapsui.Providers.Feature, Link> _links;
        Dictionary<System.Windows.Media.Color, SymbolStyle> _nodeStyles;
        Dictionary<System.Windows.Media.Color, VectorStyle> _linkStyles;

        public NetworkMap(BackgroundLayerSet backgroundLayerSet)
        {
            InitializeComponent();
            _backgroundLayerSet = backgroundLayerSet;
            _defaultColor = Mapsui.Styles.Color.Black;
            _nodes = new Dictionary<Mapsui.Providers.Feature, Node2>();
            _links = new Dictionary<Mapsui.Providers.Feature, Link>();
            _nodeStyles = new Dictionary<System.Windows.Media.Color, SymbolStyle>();
            _linkStyles = new Dictionary<System.Windows.Media.Color, VectorStyle>();
            Clear();

            _nodeLegend = new Legend() {
                VerticalAlignment   = System.Windows.VerticalAlignment.Top,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                Margin              = new System.Windows.Thickness(5, 5, 0, 0),
                Visibility          = System.Windows.Visibility.Collapsed,
            };
            _linkLegend = new Legend() {
                VerticalAlignment   = System.Windows.VerticalAlignment.Top,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                Margin              = new System.Windows.Thickness(5, 5, 0, 0),
                Visibility          = System.Windows.Visibility.Collapsed,
            };
            root.Children.Add(_nodeLegend);
            root.Children.Add(_linkLegend);
        }

        public void SetDefaultColor(System.Windows.Media.Color color)
        {
            _defaultColor.A = color.A;
            _defaultColor.B = color.B;
            _defaultColor.G = color.G;
            _defaultColor.R = color.R;
        }
        public void Clear()
        {
            _nodes.Clear();
            _links.Clear();
            mapControl.Map.Layers.Clear();
            InitializeBackgroundLayers();
        }
        private void InitializeBackgroundLayers()
        {
            // Zoom Level
            mapControl.Map.Layers.Add(
                new TileLayer(
                    new TileSource(null, new GlobalSphericalMercator(0, 30) )));

            if (_backgroundLayerSet != null)
            {
                foreach (var layer in _backgroundLayerSet.Layers)
                    mapControl.Map.Layers.Add(layer);

                if (_backgroundLayerSet.Layers.Any())
                {
                    NavigateTo(_backgroundLayerSet.Layers.First(), 2);
                }
            }
        }
        public void LoadInp(EpanetService service)
        {
            Clear();

            var nodeLayer = GetNodeLayer(service.Network.Nodes);
            var linkLayer = GetLinkLayer(service.Network.Links);
            nodeLayer.Style = GetNodeLayerStyle();
            linkLayer.Style = GetLinkLayerStyle();
            mapControl.Map.Layers.Add(linkLayer);
            mapControl.Map.Layers.Add(nodeLayer);

            if (!IsInViewport(nodeLayer) 
                && !IsInViewport(linkLayer))
            {
                NavigateTo(nodeLayer);
            }
        }
        public void Refresh()
        {
            mapControl.Refresh();
        }
        public void RefreshGraphics()
        {
            mapControl.RefreshGraphics();
        }

        public void SetNodeLegend(string title, string unit, System.Windows.Media.Color[] colors, string[] names)
        {
            _nodeLegend.SetLegend(title, unit, colors, names);
            _nodeLegend.Visibility = System.Windows.Visibility.Visible;
        }
        public void SetLinkLegend(string title, string unit, System.Windows.Media.Color[] colors, string[] names)
        {
            _linkLegend.SetLegend(title, unit, colors, names);
            _linkLegend.Visibility = System.Windows.Visibility.Visible;
        }
        public void CollapseNodeLegend()
        {
            _nodeLegend.Visibility = System.Windows.Visibility.Collapsed;
            foreach (var n in _nodes)
            {
                var feature = n.Key;
                feature.Styles.Clear();
            }
        }
        public void CollapseLinkLegend()
        {
            _linkLegend.Visibility = System.Windows.Visibility.Collapsed;
            foreach (var n in _links)
            {
                var feature = n.Key;
                feature.Styles.Clear();
            }
        }
        
        public void BrowseNode(System.Windows.Media.Color[] colors, double[] boundaryValues, Func<string, double> selector)
        {
            foreach (var n in _nodes)
            {
                var feature = n.Key;
                var node    = n.Value;
                var style   = default(IStyle);
                if (selector != null)
                {
                    var value = selector.Invoke( node.Name );
                    int i     = 0;
                    foreach (var b in boundaryValues)
                    {
                        if (value <= b)
                        {
                            break;
                        }
                        i++;
                    }

                    style = GetNodeFeatureStyle(colors[i]);
                }

                feature.Styles.Clear();
                if (style != null)
                    feature.Styles.Add(style);
            }
        }
        public void BrowseLink(System.Windows.Media.Color[] colors, double[] boundaryValues, Func<string, double> selector)
        {
            foreach (var n in _links)
            {
                var feature = n.Key;
                var link    = n.Value;
                var style   = default(IStyle);
                if (selector != null)
                {
                    var value = selector.Invoke( link.Name );
                    int i     = 0;
                    foreach (var b in boundaryValues)
                    {
                        if (value <= b)
                        {
                            break;
                        }
                        i++;
                    }

                    style = GetLinkFeatureStyle(colors[i]);
                }

                feature.Styles.Clear();
                if (style != null)
                    feature.Styles.Add(style);
            }
        }

        public bool IsInViewport(ILayer layer)
        {
            return mapControl.Viewport.Extent.Contains(layer.Envelope);
        }
        public void NavigateTo(ILayer layer)
        {
            mapControl.Navigator.NavigateTo(layer.Envelope.Centroid, mapControl.Viewport.Resolution);
        }
        public void NavigateTo(ILayer layer, double resolution)
        {
            mapControl.Navigator.NavigateTo(layer.Envelope.Centroid, resolution);
        }

        private WritableLayer GetNodeLayer(IEnumerable<Node2> nodes)
        {
            var layer = new WritableLayer();
            foreach (var node in nodes)
            {
                var feature = new Mapsui.Providers.Feature();
                feature.Geometry = ToMapsuiPoint(node);
                layer.Add(feature);
                _nodes.Add(feature, node);
            }
            return layer;
        }
        private WritableLayer GetLinkLayer(IEnumerable<Link> links)
        {
            var layer = new WritableLayer();
            foreach (var link in links)
            {
                var vertices = new List<Mapsui.Geometries.Point>();
                vertices.Add( ToMapsuiPoint(link.FirstNode) );
                foreach (var v in link.Vertices)
                {
                    vertices.Add( ToMapsuiPoint(v) );
                }
                vertices.Add( ToMapsuiPoint(link.SecondNode) );
                var lineString = new Mapsui.Geometries.LineString(vertices);
                var feature    = new Mapsui.Providers .Feature();
                feature.Geometry = lineString;
                layer.Add(feature);
                _links.Add(feature, link);
            }
            return layer;
        }

        private SymbolStyle GetNodeLayerStyle()
        {
            var s = new SymbolStyle();
            s.Fill        = new Mapsui.Styles.Brush( _defaultColor );
            s.SymbolScale = 0.3;
            s.SymbolType  = SymbolType.Ellipse;
            return s;
        }
        private VectorStyle GetLinkLayerStyle()
        {
            var s = new VectorStyle();
            s.Line          = new Mapsui.Styles.Pen();
            s.Line.PenStyle = PenStyle    .Solid;
            s.Line.Color    = _defaultColor;
            s.Line.Width    = 2;
            return s;
        }

        private SymbolStyle GetNodeFeatureStyle(System.Windows.Media.Color color)
        {
            if (!_nodeStyles.ContainsKey(color))
            {
                var s = GetNodeLayerStyle();
                s.Fill = new Mapsui.Styles.Brush(color.ToMapsui());
                _nodeStyles.Add(color, s);
            }
            return _nodeStyles[color];
        }
        private VectorStyle GetLinkFeatureStyle(System.Windows.Media.Color color)
        {
            if (!_linkStyles.ContainsKey(color))
            {
                var s = GetLinkLayerStyle();
                s.Line.Color = color.ToMapsui();
                _linkStyles.Add(color, s);
            }
            return _linkStyles[color];
        }

        private Mapsui.Geometries.Point ToMapsuiPoint(Node node)
        {
            var x = node.X;
            var y = node.Y;
            return ToMapsuiPoint(x, y);
        }
        private Mapsui.Geometries.Point ToMapsuiPoint(Epanet.Models.Point point)
        {
            var x = point.X;
            var y = point.Y;
            return ToMapsuiPoint(x, y);
        }
        private Mapsui.Geometries.Point ToMapsuiPoint(double x, double y)
        {
            // 시연용 샘플 좌표계 맞지 않는 것 보정
            x = x - 260;
            y = y +  35;
            return new Mapsui.Geometries.Point(x, y);
        }

        private Mapsui.Geometries.Point ToMapsuiPoint(Node2 node)
        {
            var x = node.Position.X;
            var y = node.Position.Y;
            return ToMapsuiPoint(x, y);
        }
        private Mapsui.Geometries.Point ToMapsuiPoint(EnPoint point)
        {
            var x = point.X;
            var y = point.Y;
            return ToMapsuiPoint(x, y);
        }
    }
}
