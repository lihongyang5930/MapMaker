using System;
using System.Windows.Forms;

namespace DrPipe.Diagnosis.Views.Local.Analysis.PipeNetwork
{
    public partial class ReportView : UserControl
    {
        public ReportView()
        {
            InitializeComponent();
            textBox.ReadOnly = true;
            textBox.Text     = string.Empty;
        }

        public void SetText(string value)
        {
            textBox.Text = value;
        }
        public void AppendText(string value)
        {
            textBox.AppendText(Environment.NewLine + value);
        }
    }
}
