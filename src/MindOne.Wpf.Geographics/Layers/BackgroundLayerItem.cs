using System.ComponentModel;

namespace MindOne.Wpf.Geographics.Layers
{
    public class BackgroundLayerItem : INotifyPropertyChanged
    {
        bool   _isEnabled;
        string _name;

        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                if (value != _isEnabled)
                {
                    _isEnabled = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsEnabled)));
                }
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                if (value != _name)
                {
                    _name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
                }
            }
        }
        public string[] LayerNames { get; set; }
        public int Order { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
