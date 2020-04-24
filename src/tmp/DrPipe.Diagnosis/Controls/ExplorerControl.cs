using System.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace DrPipe.Diagnosis.Controls
{
    public partial class ExplorerControl : UserControl
    {
        #region Nodes
        TreeNodeAdv _배경         = new TreeNodeAdv { Checked = true, Text = "없음"         };
        TreeNodeAdv _선적평가관로 = new TreeNodeAdv { Checked = true, Text = "관로용도" };
        TreeNodeAdv _시설현장조사 = new TreeNodeAdv { Checked = true, Text = "관경" };
        TreeNodeAdv _수질조사시점 = new TreeNodeAdv { Checked = true, Text = "관종" };
        TreeNodeAdv _민원         = new TreeNodeAdv { Checked = true, Text = "매설년수"         };
        TreeNodeAdv _밸브         = new TreeNodeAdv { Checked = true, Text = "진단구역"         };
        TreeNodeAdv _배수지       = new TreeNodeAdv { Checked = true, Text = "진단구간"       };
        TreeNodeAdv _소화전       = new TreeNodeAdv { Checked = true, Text = "소화전"       };
        TreeNodeAdv _수압계       = new TreeNodeAdv { Checked = true, Text = "수압계"       };
        TreeNodeAdv _유량계       = new TreeNodeAdv { Checked = true, Text = "유량계"       };
        TreeNodeAdv _대수용가     = new TreeNodeAdv { Checked = true, Text = "대수용가"     };
        TreeNodeAdv _수용가       = new TreeNodeAdv { Checked = true, Text = "수용가"       };
        TreeNodeAdv _절점         = new TreeNodeAdv { Checked = true, Text = "절점"         };
        TreeNodeAdv _관로         = new TreeNodeAdv { Checked = true, Text = "관로"         };
        TreeNodeAdv _블록         = new TreeNodeAdv { Checked = true, Text = "블록"         };
        TreeNodeAdv _그리드       = new TreeNodeAdv { Checked = true, Text = "그리드"       };
        #endregion
        public ExplorerControl()
        {
            InitializeComponent();
            treeView.ShowRootLines         = true;
            treeView.ShowLines             = true;
            treeView.ShowPlusMinus         = true;
            treeView.ShowCheckBoxes        = false;
            treeView.ShowOptionButtons     = true;
            treeView.InteractiveCheckBoxes = true;
            treeView.ThemeName             = "Office2016Colorful";

            treeView.Nodes.Add(_배경);
            treeView.Nodes.Add(_선적평가관로);
            treeView.Nodes.Add(_시설현장조사);
            treeView.Nodes.Add(_수질조사시점);
            treeView.Nodes.Add(_민원        );
            treeView.Nodes.Add(_밸브        );
            treeView.Nodes.Add(_배수지      );
            treeView.Nodes.Add(_소화전      );
            treeView.Nodes.Add(_수압계      );
            treeView.Nodes.Add(_유량계      );
            treeView.Nodes.Add(_대수용가    );
            treeView.Nodes.Add(_수용가      );
            treeView.Nodes.Add(_절점        );
            treeView.Nodes.Add(_관로        );
            treeView.Nodes.Add(_블록        );
            treeView.Nodes.Add(_그리드      );
        }
    }
}
