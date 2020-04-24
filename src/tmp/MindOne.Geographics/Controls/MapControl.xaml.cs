using BruTile;
using BruTile.Predefined;
using Mapsui;
using Mapsui.Layers;
using Mapsui.Styles;
using MindOne.Geographics.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MindOne.Geographics.Controls
{
    /// <summary>
    /// MapControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MapControl : UserControl
    {
        BackgroundLayerSet _backgroundLayerSet;
        Mapsui.Styles.Color _defaultColor;
        public MapControl()
        {
            InitializeComponent();
            
        }

        public MapControl(BackgroundLayerSet backgroundLayerSet) : this()
        {
            _backgroundLayerSet = backgroundLayerSet;
            _defaultColor = Mapsui.Styles.Color.Black;
            Clear();
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
            mapControl.Map.Layers.Clear();
            InitializeBackgroundLayers();
            Refresh();
        }

        public void Refresh()
        {
            mapControl.Refresh();
        }
        public void RefreshGraphics()
        {
            mapControl.RefreshGraphics();
        }
        private void InitializeBackgroundLayers()
        {
            // Zoom Level
            mapControl.Map.Layers.Add(
                new TileLayer(
                    new TileSource(null, new GlobalSphericalMercator(0, 19))));

            if (_backgroundLayerSet != null)
            {
                foreach (var layer in _backgroundLayerSet.Layers)
                {
                    mapControl.Map.Layers.Add(layer);
                    layer.Busy = true;
                }
                if (_backgroundLayerSet.Layers.Any())
                {
                    NavigateTo(_backgroundLayerSet.Layers.First(), 2);
                }
            }
        }

        public void NavigateTo(ILayer layer)
        {
            mapControl.Navigator.NavigateTo(layer.Envelope.Centroid, mapControl.Viewport.Resolution);
        }
        public void NavigateTo(ILayer layer, double resolution)
        {
            mapControl.Navigator.NavigateTo(layer.Envelope.Centroid, resolution);
        }
    }
}
