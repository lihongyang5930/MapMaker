// Copyright (c) DotSpatial Team. All rights reserved.
// Licensed under the MIT license. See License.txt file in the project root for full license information.

using System.Windows.Forms;
using DotSpatial.Controls;
using DotSpatial.Controls.Docking;
using DotSpatial.Plugins.SimpleLegend.Properties;

namespace DotSpatial.Plugins.SimpleLegend
{
    /// <summary>
    /// Adds a simple legend to the dock manager.
    /// </summary>
    public class SimpleLegendPlugin : Extension
    {
        private Legend _legend;

        /// <inheritdoc />
        public override void Activate()
        {
            ShowLegend();
            base.Activate();
        }

        /// <inheritdoc />
        public override void Deactivate()
        {
            App.HeaderControl.RemoveAll();
            App.DockManager.Remove("kLegend");
            base.Deactivate();
        }   

        private void ShowLegend()
        {
            _legend = new Legend
            {
                Text = "Legend",
                Name = "legend1",
            };

            if (App.Map != null)
            {
                App.Map.Legend = _legend;
            }

            App.Legend = _legend;
            App.DockManager.Add(
                new DockablePanel("kLegend" 
                , "범례"
                , _legend
                , DockStyle.Left)
                {
                    SmallImage = Resources.legend_16x16
                });
        }
    }
}