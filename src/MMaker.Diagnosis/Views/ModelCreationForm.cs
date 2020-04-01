using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMaker.Diagnosis.Views
{
    public partial class ModelCreationForm : MMaker.Core.Views.BaseForm
    {
        public ModelCreationForm()
        {
            InitializeComponent();
            this.btnGenerator.Click += BtnGenerator_Click;
        }

        private void BtnGenerator_Click(object sender, EventArgs e)
        {
            

        }
    }
}
