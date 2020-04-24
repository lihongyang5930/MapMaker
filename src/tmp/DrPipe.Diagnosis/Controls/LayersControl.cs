using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using MindOne.Geographics.Layers;
using Syncfusion.Windows.Forms.Tools;

namespace DrPipe.Diagnosis.Controls
{
    public partial class LayersControl : UserControl
    {
        BackgroundLayerSet _backgroundLayerSet;

        #region Nodes
        TreeNodeAdv _배경         = new TreeNodeAdv { Checked = true, Text = "배경"         , ShowOptionButton = false, ShowCheckBox = true  };
        TreeNodeAdv _선적평가관로 = new TreeNodeAdv { Checked = true, Text = "선적평가관로" , ShowOptionButton = false, ShowCheckBox = true  };
        TreeNodeAdv _시설현장조사 = new TreeNodeAdv { Checked = true, Text = "시설현장조사" , ShowOptionButton = false, ShowCheckBox = true  };
        TreeNodeAdv _수질조사시점 = new TreeNodeAdv { Checked = true, Text = "수질조사시점" , ShowOptionButton = false, ShowCheckBox = true  };
        TreeNodeAdv _민원         = new TreeNodeAdv { Checked = true, Text = "민원"         , ShowOptionButton = false, ShowCheckBox = true  };
        TreeNodeAdv   _수질민원   = new TreeNodeAdv { Checked = true, Text = "수질민원"     , ShowOptionButton = false, ShowCheckBox = true  };
        TreeNodeAdv   _출수민원   = new TreeNodeAdv { Checked = true, Text = "출수민원"     , ShowOptionButton = false, ShowCheckBox = true  };
        TreeNodeAdv   _누수민원   = new TreeNodeAdv { Checked = true, Text = "누수민원"     , ShowOptionButton = false, ShowCheckBox = true  };
        TreeNodeAdv _밸브         = new TreeNodeAdv { Checked = true, Text = "밸브"         , ShowOptionButton = false, ShowCheckBox = true  };
        TreeNodeAdv   _감압밸브   = new TreeNodeAdv { Checked = true, Text = "감압밸브"     , ShowOptionButton = false, ShowCheckBox = true  };
        TreeNodeAdv   _공기밸브   = new TreeNodeAdv { Checked = true, Text = "공기밸브"     , ShowOptionButton = false, ShowCheckBox = true  };
        TreeNodeAdv   _이토밸브   = new TreeNodeAdv { Checked = true, Text = "이토밸브"     , ShowOptionButton = false, ShowCheckBox = true  };
        TreeNodeAdv   _역지밸브   = new TreeNodeAdv { Checked = true, Text = "역지밸브"     , ShowOptionButton = false, ShowCheckBox = true  };
        TreeNodeAdv   _제수밸브   = new TreeNodeAdv { Checked = true, Text = "제수밸브"     , ShowOptionButton = false, ShowCheckBox = true  };
        TreeNodeAdv _배수지       = new TreeNodeAdv { Checked = true, Text = "배수지"       , ShowOptionButton = false, ShowCheckBox = true  };
        TreeNodeAdv _소화전       = new TreeNodeAdv { Checked = true, Text = "소화전"       , ShowOptionButton = false, ShowCheckBox = true  };
        TreeNodeAdv _수압계       = new TreeNodeAdv { Checked = true, Text = "수압계"       , ShowOptionButton = false, ShowCheckBox = true  };
        TreeNodeAdv _유량계       = new TreeNodeAdv { Checked = true, Text = "유량계"       , ShowOptionButton = false, ShowCheckBox = true  };
        TreeNodeAdv _대수용가     = new TreeNodeAdv { Checked = true, Text = "대수용가"     , ShowOptionButton = false, ShowCheckBox = true  };
        TreeNodeAdv _수용가       = new TreeNodeAdv { Checked = true, Text = "수용가"       , ShowOptionButton = false, ShowCheckBox = true  };
        TreeNodeAdv _절점         = new TreeNodeAdv { Checked = true, Text = "절점"         , ShowOptionButton = false, ShowCheckBox = true  };
        TreeNodeAdv _관로         = new TreeNodeAdv { Checked = true, Text = "관로"         , ShowOptionButton = false, ShowCheckBox = true  };
        TreeNodeAdv   _관망해석   = new TreeNodeAdv { Checked = true, Text = "관망해석"     , ShowOptionButton = false, ShowCheckBox = true  };
        TreeNodeAdv   _상수관로   = new TreeNodeAdv { Checked = true, Text = "상수관로"     , ShowOptionButton = false, ShowCheckBox = true  };
        TreeNodeAdv   _급수관로   = new TreeNodeAdv { Checked = true, Text = "급수관로"     , ShowOptionButton = false, ShowCheckBox = true  };
        TreeNodeAdv _블록         = new TreeNodeAdv { Checked = true, Text = "블록"         , ShowOptionButton = false, ShowCheckBox = true  };
        TreeNodeAdv   _소블록     = new TreeNodeAdv { Checked = true, Text = "소블록"       , ShowOptionButton = true , ShowCheckBox = false };
        TreeNodeAdv   _중블록     = new TreeNodeAdv { Checked = true, Text = "중블록"       , ShowOptionButton = true , ShowCheckBox = false };
        TreeNodeAdv   _진단구역   = new TreeNodeAdv { Checked = true, Text = "진단구역"     , ShowOptionButton = true , ShowCheckBox = false };
        TreeNodeAdv _그리드       = new TreeNodeAdv { Checked = true, Text = "그리드"       , ShowOptionButton = false, ShowCheckBox = true  };
        #endregion
        public LayersControl()
        {
            InitializeComponent();
            treeView.ShowRootLines         = true;
            treeView.ShowLines             = true;
            treeView.ShowPlusMinus         = true;
            treeView.ShowCheckBoxes        = true;
            treeView.InteractiveCheckBoxes = true;
            treeView.ThemeName             = "Office2016Colorful";

            _민원.Nodes.Add(_수질민원);
            _민원.Nodes.Add(_출수민원);
            _민원.Nodes.Add(_누수민원);
            _밸브.Nodes.Add(_감압밸브);
            _밸브.Nodes.Add(_공기밸브);
            _밸브.Nodes.Add(_이토밸브);
            _밸브.Nodes.Add(_역지밸브);
            _밸브.Nodes.Add(_제수밸브);
            _관로.Nodes.Add(_관망해석);
            _관로.Nodes.Add(_상수관로);
            _관로.Nodes.Add(_급수관로);
            _블록.Nodes.Add(_소블록);
            _블록.Nodes.Add(_중블록);
            _블록.Nodes.Add(_진단구역);

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

            _배경.CheckStateChanged += OnBackgroundLayerNodeCheckStateChanged;
        }

        public bool IsBackgroundLayerVisible
        {
            get
            {
                return _배경.Checked;
            }
        }

        public event EventHandler SelectedBackgroundLayerChanged;

        public void SetBackgroundLayers(BackgroundLayerSet backgroundLayerSet)
        {
            _배경.Nodes.Clear();
            _backgroundLayerSet = backgroundLayerSet;
            if (_backgroundLayerSet != null)
            {
                foreach (var item in backgroundLayerSet)
                {
                    AddBackgroundLayer(item.Header, item.IsEnabled);
                }
            }
        }
        private void AddBackgroundLayer(string name, bool isEnabled)
        {
            var node = new TreeNodeAdv {
                Optioned            = isEnabled,
                Text                = name,
                ShowOptionButton    = true,
                ShowCheckBox        = false,
            };
            node.CheckStateChanged += OnBackgroundLayerNodeCheckStateChanged;
            var btn = node.OptionButton;
            _배경.Nodes.Add(node);
        }

        private void OnBackgroundLayerNodeCheckStateChanged(object sender, EventArgs e)
        {
            RefreshSelectedBackgroundLayer();
        }
        private void RefreshSelectedBackgroundLayer()
        {
            var selectedNode = _배경.Nodes.Cast<TreeNodeAdv>().Where(x => x.Optioned).SingleOrDefault();
            foreach (var item in _backgroundLayerSet)
            {
                item.IsEnabled 
                        = IsBackgroundLayerVisible && item.Header == selectedNode?.Text;
            }
            SelectedBackgroundLayerChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
