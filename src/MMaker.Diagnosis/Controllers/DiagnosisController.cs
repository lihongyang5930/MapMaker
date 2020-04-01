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

        public DiagnosisController(IShell shell) : base()
        {
            this.MmakerShell = shell;

            _dispatcher.MmakerShell = this.MmakerShell;

            LayerHelper.MmakerShell = this.MmakerShell;
            MapHelper.MmakerShell = this.MmakerShell;
        }

        private BackgroundLayerSet layerSet;

        public override async Task Initialize()
        {
            MmakerShell.RibbonManager.InitializeMenu();

            foreach (var tab in MmakerShell.RibbonManager.RibbonControl.Header.MainItems.Cast<ToolStripTabItem>())
                foreach (var Ex in tab.Panel.Controls.Cast<ToolStripEx>())
                    _dispatcher.InitMenu(Ex.Items);

            MMaker.Core.AppStatic.ReSetLayers();

            var backgroundLayerFactory = new BackgroundLayerFactory();
            layerSet = await backgroundLayerFactory.GetKakaoMap();

            InitializeViews();
        }

        private void InitializeViews()
        {
            MmakerShell.LegendView = new Geographics.Controls.LegendView() { Visible = false };
            MmakerShell.MapView = new Geographics.Controls.MapView() { Visible = false };
            //MmakerShell.AppManager.Legend = AppManager.Legend as Legend;
            //MmakerShell.AppManager.Map = AppManager.Map as Map;

            //MmakerShell.AppManager.Map.Legend = MmakerShell.AppManager.Legend;

            //MmakerShell.DockManager.ShowDocument(MmakerShell.MapView, "지도", false);
            //MmakerShell.DockManager.InitializeDockLeft(MmakerShell.LegendView, "범례");
            //MmakerShell.DockManager.SetDockVisible(MmakerShell.LegendView, true);

            //BackgroundLayer backlayer = layerSet.Layers.ElementAt(0);
            //backlayer.LegendText = "배경지도";
            //backlayer.IsVisible = true;

            //MmakerShell.AppManager.Map.Layers.Add(backlayer);
        }

        internal AppDispatcher Dispatcher
        {
            get { return _dispatcher; }
        }
    }
}