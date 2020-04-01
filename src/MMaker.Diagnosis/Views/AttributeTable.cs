using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Text;

namespace MMaker.Diagnosis.Views
{
    public partial class AttributeTable : MMaker.Core.Views.BaseForm
    {
        private DotSpatial.Symbology.IFeatureLayer _layer;
        private DotSpatial.Symbology.Forms.TableEditorControl _tableEditorControl;
        //DotSpatial.Data.IFeatureSet _layer;
        public AttributeTable()
        {
            InitializeComponent();
            _tableEditorControl = new DotSpatial.Symbology.Forms.TableEditorControl() { Dock = DockStyle.Fill};
            this.Controls.Add(_tableEditorControl);
        }

        public DotSpatial.Symbology.Forms.TableEditorControl tableEditor => this._tableEditorControl;

        public DotSpatial.Symbology.IFeatureLayer Layer
        {
            get { return _layer; }
            set
            {
                //if(_layer == null) _layer = value;
                //if (_layer.Equals(value)) return;
                _layer = value;
                OnLayerChanged();
            }
        }

        private void OnLayerChanged()
        {
            _tableEditorControl.FeatureLayer = _layer;
        }
    }
}
