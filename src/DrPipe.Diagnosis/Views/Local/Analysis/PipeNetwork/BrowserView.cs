using System.Drawing;
using System.Windows.Forms;
using DrPipe.Core.Services;
using Syncfusion.Drawing;
using Syncfusion.Windows.Forms.Chart;

namespace DrPipe.Diagnosis.Views.Local.Analysis.PipeNetwork
{
    public partial class BrowserView : UserControl
    {
        public BrowserView()
        {
            InitializeComponent();
            Appearances.Chart(chartControl);
            chartControl.ShowLegend = false;
            chartControl.BackInterior = new BrushInfo(Color.Transparent);
            chartControl.Series.Clear();
            chartControl.Series.Add(new ChartSeries());

            legendPanel.Visible = false;
        }
        public void DisableLegends()
        {
            legendPanel.Visible = false;
        }
        public void SetLegends(string[] labels, int[] counts, Color[] colors)
        {
            legendPanel.Visible = true;

            var labelControls = new [] { lblLegend1, lblLegend2, lblLegend3 };
            var countControls = new [] { lblCount1 , lblCount2 , lblCount3 };

            for (int i = 0; i < labelControls.Length; i++)
            {
                if (labels.Length > i)
                {
                    labelControls[i].Visible = true;
                    labelControls[i].Text    = labels[i];
                }
                else
                {
                    labelControls[i].Visible = false;
                }
            }

            for (int i = 0; i < countControls.Length; i++)
            {
                if (counts.Length > i)
                {
                    countControls[i].Visible   = true;
                    countControls[i].Text      = counts[i].ToString();
                    countControls[i].BackColor = colors[i];
                }
                else
                {
                    countControls[i].Visible = false;
                }
            }
        }

    }
}
