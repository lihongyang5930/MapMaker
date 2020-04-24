using System;
using System.Linq;
using System.Windows.Forms;

namespace DrPipe.Core.Views.Common
{
    public partial class MonthSelectorView : UserControl
    {
        public MonthSelectorView()
        {
            InitializeComponent();

            Years  = new int [] { DateTime.Today.Year , DateTime.Today.AddYears (-1).Year , DateTime.Today.AddYears (-2).Year  };
            Months = Enumerable.Range(1, 12).ToArray();
        }

        public int[] Years  { get; set; }
        public int[] Months { get; set; }
    }
}
