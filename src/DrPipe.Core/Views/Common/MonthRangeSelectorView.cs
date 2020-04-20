using System;
using System.Linq;
using System.Windows.Forms;
using DrPipe.Core.Models;

namespace DrPipe.Core.Views.Common
{
    public partial class MonthRangeSelectorView : UserControl
    {
        public MonthRangeSelectorView()
        {
            InitializeComponent();

            Years  = new int [] { 
                DateTime.Today.Year , 
                DateTime.Today.AddYears(-1).Year, 
                DateTime.Today.AddYears(-2).Year,
                DateTime.Today.AddYears(-3).Year,
                DateTime.Today.AddYears(-4).Year,
                DateTime.Today.AddYears(-5).Year,
            };

            Months = Enumerable.Range(1, 12).ToArray();

            cmbYear1.DataSource  = Years;
            cmbYear2.DataSource  = Years;
            cmbMonth1.DataSource = Months;
            cmbMonth2.DataSource = Months;

            cmbYear1.SelectedItem = DateTime.Today.Year;
            cmbYear2.SelectedItem = DateTime.Today.Year;

            cmbMonth1.SelectedItem = DateTime.Today.Month;
            cmbMonth2.SelectedItem = DateTime.Today.Month;
        }

        public int[] Years  { get; set; }
        public int[] Months { get; set; }

        public MonthRange GetResult()
        {
            return new MonthRange { 
                Year1  = (int)cmbYear1 .SelectedItem,
                Year2  = (int)cmbYear2 .SelectedItem,
                Month1 = (int)cmbMonth1.SelectedItem,
                Month2 = (int)cmbMonth2.SelectedItem,
            };
        }
    }
}
