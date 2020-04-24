using System.Windows.Forms;

namespace DrPipe.Diagnosis.Views.Local.Analysis.Hydraulics
{
    public partial class CoefficientSetupView : UserControl
    {
        public CoefficientSetupView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 배경누수량(배수관)
        /// </summary>
        public double Coeff1
        {
            get
            {
                return sfNumericTextBox1.Value ?? 0;
            }
            set
            {
                sfNumericTextBox1.Value = value;
            }
        }

        /// <summary>
        /// 배경누수량(급수전)
        /// </summary>
        public double Coeff2
        {
            get
            {
                return sfNumericTextBox2.Value ?? 0;
            }
            set
            {
                sfNumericTextBox2.Value = value;
            }
        }

        /// <summary>
        /// 배경누수량(급수관)
        /// </summary>
        public double Coeff3
        {
            get
            {
                return sfNumericTextBox3.Value ?? 0;
            }
            set
            {
                sfNumericTextBox3.Value = value;
            }
        }

        /// <summary>
        /// 시설상태계수(ICF)
        /// </summary>
        public double Coeff4
        {
            get
            {
                return sfNumericTextBox4.Value ?? 0;
            }
            set
            {
                sfNumericTextBox4.Value = value;
            }
        }
    }
}
