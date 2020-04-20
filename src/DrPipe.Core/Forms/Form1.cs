using DrPipe.Core.Services;
using Syncfusion.Windows.Forms.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrPipe.Core.Forms
{
    public partial class Form1 : RibbonForm
    {
        public Form1()
        {
            InitializeComponent();

            Appearances.MainRibbonButton(toolStripButton4, "새프로젝트", @"Resources\images\app\새프로젝트.png");

            this.toolStripLabel1.Image = Image.FromFile(@"Resources\images\app\구역분할.png");

        }


        public UserControl EpanetView { get; set; }


        #region SampleTest Click Event
        private void ev1(object sender, EventArgs e)
        {
            var main = new MainForm();
            dockingManager1.SetEnableDocking(main, true);
        }

        private void ev2(object sender, EventArgs e)
        {
        }

        private void ev3(object sender, EventArgs e)
        {
            dockingManager1.SetDockLabel(EpanetView, "EPANET 2.1");
            dockingManager1.SetEnableDocking(EpanetView, true);
            dockingManager1.SetDockAbility(EpanetView, DockAbility.All);
        }
        #endregion
    }
}
