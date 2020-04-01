using DotSpatial.Controls;

using System.Windows.Forms;

namespace MMaker.Geographics.Controls
{
    public partial class LegendView : UserControl
    {
        public LegendView()
        {
            InitializeComponent();
            
        }

        public Legend Legend { get => _legend; set => _legend = value; }
    }
}
