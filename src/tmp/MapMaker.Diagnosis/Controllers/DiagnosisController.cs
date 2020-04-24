using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapMaker.Core.Controllers;
using MapMaker.Diagnosis.Views;
using MindOne.Geographics.Layers;

namespace MapMaker.Diagnosis.Controllers
{
    public class DiagnosisController : ControllerBase
    {
        BackgroundLayerSet _backgroundLayer;
        MapView            _mapview;
        
        public override async Task Initialize()
        {
            var backgroundLayerFactory = new BackgroundLayerFactory();
            _backgroundLayer = await backgroundLayerFactory.GetKakaoMap();

            _mapview = new MapView(_backgroundLayer);
            Shell.DockManager.ShowDocument(_mapview, "지도", false);

            _backgroundLayer[0].IsEnabled = true;
            var color = _backgroundLayer[0].IsDark
                                    ? System.Drawing.Color.Snow
                                    : System.Drawing.Color.Black;
            _mapview.SetDefaultColor(color);
            _mapview.Refresh();

            InitializeViews();
        }

        private void InitializeViews()
        {
            
        }
    }
}
