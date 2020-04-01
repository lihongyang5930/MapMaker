using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMaker.Core.Views
{
    public partial class BaseView : UserControl
    {
        public BaseView()
        {
            InitializeComponent();
        }

        public IShell MmakerShell { get; set; }
    }
}
