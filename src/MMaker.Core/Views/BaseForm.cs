﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMaker.Core.Views
{
    public partial class BaseForm : Syncfusion.WinForms.Controls.SfForm
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        public IShell MmakerShell { get; set; }
    }
}
