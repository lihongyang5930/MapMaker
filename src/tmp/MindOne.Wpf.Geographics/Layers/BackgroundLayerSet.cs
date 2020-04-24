using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using MindOne.Wpf.Geographics.CoordinateSystems;

namespace MindOne.Wpf.Geographics.Layers
{
    public class BackgroundLayerSet : List<BackgroundLayerItem>
    {
        public BackgroundLayerSet(IEnumerable<BackgroundLayer> layers)
        {
            CRS    = CRSUtil.Simplify(layers.FirstOrDefault()?.TileSource?.Schema?.Srs);
            Layers = layers;
        }
        public string CRS { get; private set; }
        public IEnumerable<BackgroundLayer> Layers { get; private set; }

        public void Add(string displayName, params string[] layerNames)
        {
            var layers      = Layers.Where(x => layerNames.Contains(x.Name)).ToArray();
            var item        = new BackgroundLayerItem();
            item.PropertyChanged += OnItemPropertyChanged;
            item.Name       = displayName;
            item.LayerNames = layerNames;
            item.Order      = Count;
            item.IsEnabled  = Count == 0;
            Add(item);
        }

        private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(BackgroundLayerItem.IsEnabled))
            {
                var item = (BackgroundLayerItem)sender;
                if (item.IsEnabled)
                {
                    foreach (var layer in Layers)
                    {
                        var isEnabled = item.IsEnabled && item.LayerNames.Contains(layer.Name);
                        layer.Enabled = isEnabled;
                    }
                }
            }
        }
    }
}
