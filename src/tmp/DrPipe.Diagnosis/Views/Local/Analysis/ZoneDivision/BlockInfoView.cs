using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MindOne.DrPipe.Dpf.Models;

namespace DrPipe.Diagnosis.Views.Local.Analysis.ZoneDivision
{
    public partial class BlockInfoView : UserControl
    {
        public BlockInfoView()
        {
            InitializeComponent();
        }

        public void SetData(IEnumerable<DBM_ZONE> zones)
        {

        }
    }
}
