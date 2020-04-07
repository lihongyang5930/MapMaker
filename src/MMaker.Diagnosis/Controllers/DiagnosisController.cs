using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotSpatial.Controls;
using MMaker.Core;
using MMaker.Core.Controllers;
using MMaker.Diagnosis.Helper;
using MMaker.Geographics.Layers;

using Syncfusion.Windows.Forms.Tools;

namespace MMaker.Diagnosis.Controllers
{
    public class DiagnosisController : ControllerBase
    {
        private readonly AppDispatcher _dispatcher = new AppDispatcher();

        private BackgroundLayerSet layerSet;

        public DiagnosisController(IShell shell) : base()
        {
            this.MmakerShell = shell;

            _dispatcher.MmakerShell = this.MmakerShell;

            LayerHelper.MmakerShell = this.MmakerShell;
            MapHelper.MmakerShell = this.MmakerShell;
        }

        public override async Task Initialize()
        {
            MmakerShell.RibbonManager.InitializeMenu();

            foreach (var tab in MmakerShell.RibbonManager.RibbonControl.Header.MainItems.Cast<ToolStripTabItem>())
                foreach (var Ex in tab.Panel.Controls.Cast<ToolStripEx>())
                    _dispatcher.InitMenu(Ex.Items);

            // generate background layer (using kakaomap)
            var backgroundLayerFactory = new BackgroundLayerFactory();
            layerSet = await backgroundLayerFactory.GetKakaoMap();

            InitializeViews();

            // make 18 standards WTL layers
            MMaker.Core.AppStatic.ReSetLayers();
        }

        private void InitializeViews()
        {
            MmakerShell.LegendView = new Geographics.Controls.LegendView() { Visible = false };
            MmakerShell.MapView = new Geographics.Controls.MapView() { Visible = false };

            // [20200406] fdragons
            // make background layer (using kakaomap)
            BackgroundLayer backlayer = layerSet.Layers.ElementAt(0); // 0:map_2d, 1:map_skyview, 2:map_hybrid
            backlayer.IsVisible = true;
            MmakerShell.AppManager.Map.Layers.Add(backlayer);
        }

        internal AppDispatcher Dispatcher
        {
            get { return _dispatcher; }
        }
    }
}