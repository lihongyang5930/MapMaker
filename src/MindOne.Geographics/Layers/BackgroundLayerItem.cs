using System.ComponentModel;

namespace MindOne.Geographics.Layers
{
    public class BackgroundLayerItem : INotifyPropertyChanged
    {
        bool   _isEnabled;
        bool   _isDark;
        string _header;

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
        public bool IsDark
        {
            get => _isDark;
            set
            {
                if (value != _isDark)
                {
                    _isDark = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsDark)));
                }
            }
        }
        public string Header
        {
            get => _header;
            set
            {
                if (value != _header)
                {
                    _header = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Header)));
                }
            }
        }
        public string[] LayerNames { get; set; }
        public int Order { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
