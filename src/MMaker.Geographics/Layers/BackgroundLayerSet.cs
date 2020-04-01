using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace MMaker.Geographics.Layers
{
    public class BackgroundLayerSet : List<BackgroundLayerItem>
    {
        public BackgroundLayerSet(IEnumerable<BackgroundLayer> layers)
        {
            //CRS    = CRSUtil.Simplify(layers.FirstOrDefault()?.TileSource?.Schema?.Srs);
            Layers = layers;
        }
        public string CRS { get; private set; }
        public IEnumerable<BackgroundLayer> Layers { get; private set; }

        public BackgroundLayerItem SelectedItem
        {
            get
            {
                foreach (var item in this)
                    if (item.IsEnabled)
                        return item;
                return null;
            }
        }

        public void Add(string displayName, params string[] layerNames)
        {
            Add(displayName, false, layerNames);
        }
        public void Add(string displayName, bool isDark, params string[] layerNames)
        {
            var layers      = Layers.Where(x => layerNames.Contains(x.LegendText)).ToArray();
            var item        = new BackgroundLayerItem();
            item.PropertyChanged += OnItemPropertyChanged;
            item.Header     = displayName;
            item.LayerNames = layerNames;
            item.Order      = Count;
            item.IsEnabled  = Count == 0;
            item.IsDark     = isDark;
            Add(item);
            UpdateLayerEnabled();
        }
        private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(BackgroundLayerItem.IsEnabled))
            {
                UpdateLayerEnabled();
            }
        }
        private void UpdateLayerEnabled()
        {
            var enabledItem = this.Where(x => x.IsEnabled).FirstOrDefault();
            foreach (var layer in Layers)
            {
                var isEnabled = enabledItem != null && enabledItem.IsEnabled && enabledItem.LayerNames.Contains(layer.LegendText);
                layer.IsVisible = isEnabled;
            }
        }
    }
}
