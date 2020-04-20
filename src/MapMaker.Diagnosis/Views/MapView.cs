using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MindOne.Epanet;
using MindOne.Epanet.Models;
using MindOne.Geographics.Controls;
using MindOne.Geographics.Layers;

namespace MapMaker.Diagnosis.Views
{
    public partial class MapView : UserControl
    {
        MapControl   _map;

        public MapView(BackgroundLayerSet backgroundLayerSet)
        {
            InitializeComponent();
            _map = new MapControl(backgroundLayerSet);
            elementHost.Child = _map;
        }

        public void Clear()
        {
            _map.Clear();
        }
   
        public void SetDefaultColor(Color color)
        {
            _map.SetDefaultColor(ToWpfColor(color));
        }
      
        
        public override void Refresh()
        {
            _map.Refresh();
            base.Refresh();
        }

        private System.Windows.Media.Color[] ToWpfColors(System.Drawing.Color[] colors)
        {
            return colors.Select(ToWpfColor).ToArray();
        }
        private System.Windows.Media.Color ToWpfColor(System.Drawing.Color color)
        {
            return new System.Windows.Media.Color() { 
                A = color.A,
                R = color.R,
                G = color.G,
                B = color.B,
            };
        }
    }
}
