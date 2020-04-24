using System;
using System.Drawing;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Chart;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.WinForms.DataGrid;

namespace DrPipe.Core.Services
{
    public static class Appearances
    {
        public static Font DefaultFont { get; set; }
        public static void DataGrid(SfDataGrid dataGrid)
        {
            dataGrid.AutoGenerateColumns  = false;
            dataGrid.AllowResizingColumns = true;
            dataGrid.SelectionMode        = Syncfusion.WinForms.DataGrid.Enums.GridSelectionMode.Extended;
        }

        public static void TagControl(TabControlAdv tabControl)
        {
            foreach (TabPageAdv page in tabControl.TabPages)
            {
                
            }
        }

        public static void Chart(ChartControl chart)
        {
            chart.Series.Clear();
            chart.Skins = Skins.Metro;
            chart.BorderAppearance.SkinStyle = ChartBorderSkinStyle.None;
            chart.BorderAppearance.FrameThickness = new ChartThickness(-2, -2, 2, 2);
            chart.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            chart.ChartArea.PrimaryXAxis.HidePartialLabels = true;
            chart.ElementsSpacing = 5;
        }

        public static void MainRibbon(RibbonControlAdv ribbonControlAdv1)
        {
            SetDefaultFont(ribbonControlAdv1);
        }
        public static void MainRibbonButton(ToolStripButton button, string text, string imagePath)
        {
            MainRibbonToolStripItem(button, text, imagePath);
        }
        public static void MainRibbonButton(ToolStripButton button, string text)
        {
            MainRibbonToolStripItem(button, text, null);
        }
        public static void MainRibbonButton(ToolStripDropDownButton button, string text, string imagePath)
        {
            MainRibbonToolStripItem(button, text, imagePath);
            button.ShowDropDownArrow = false;
        }
        
        private static void MainRibbonToolStripItem(ToolStripItem button, string text, string imagePath = null)
        {
            var marginLeft   =  5;
            var marginRight  =  5;
            var marginTop    =  5;
            var marginBottom =  0;
            var width        = 64;
            var height       = 70;
            button.AutoSize              = true;
            button.ImageScaling          = ToolStripItemImageScaling.None;
            button.ImageTransparentColor = Color.Magenta;
            button.Size                  = new Size(width, height);
            //button.Margin                = new Padding(marginLeft, marginTop, marginRight, marginBottom);
            button.Text                  = text;
            button.TextImageRelation     = TextImageRelation.ImageAboveText;
            button.Font                  = DefaultFont;
            if (imagePath != null)
                button.Image = Image.FromFile(imagePath);
        }


        private static void SetDefaultFont(Control control)
        {
            control.Font = DefaultFont;
        }
    }
}
