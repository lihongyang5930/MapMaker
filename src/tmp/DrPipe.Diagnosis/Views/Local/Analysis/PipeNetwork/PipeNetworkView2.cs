using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MindOne.Epanet;
using MindOne.Geographics.Controls;
using Syncfusion.WinForms.DataGrid;
using DrPipe.Core.Services;
using MindOne.Geographics.Layers;

namespace DrPipe.Diagnosis.Views.Local.Analysis.PipeNetwork
{
    public partial class PipeNetworkView2 : UserControl
    {
        NetworkMap _networkMap;

        public PipeNetworkView2(BackgroundLayerSet backgroundLayerSet)
        {
            InitializeComponent();
            InitializeNetworkMap(backgroundLayerSet);
            InitializePipeDataGrid(dgPipe);
            InitializeJunctionDataGrid(dgJunction);
            Appearances.DataGrid(dgPipe);
            Appearances.DataGrid(dgJunction);
        }

        private void InitializeNetworkMap(BackgroundLayerSet backgroundLayerSet)
        {
            _networkMap = new NetworkMap(backgroundLayerSet);
            elementHost.Child = _networkMap;
        }
        private void InitializePipeDataGrid(SfDataGrid dataGrid)
        {
            dataGrid.Columns.Add(new GridTextColumn() { HeaderText = "관로구분"  , MappingName = "a" });
            dataGrid.Columns.Add(new GridTextColumn() { HeaderText = "관리번호"  , MappingName = "a" });
            dataGrid.Columns.Add(new GridTextColumn() { HeaderText = "EPANET ID" , MappingName = "a" });
            dataGrid.Columns.Add(new GridTextColumn() { HeaderText = "관경"      , MappingName = "a" });
            dataGrid.Columns.Add(new GridTextColumn() { HeaderText = "관로길이"  , MappingName = "a" });
            dataGrid.Columns.Add(new GridTextColumn() { HeaderText = "누수계수"  , MappingName = "a" });
            dataGrid.Columns.Add(new GridTextColumn() { HeaderText = "조도계수"  , MappingName = "a" });
            dataGrid.Columns.Add(new GridTextColumn() { HeaderText = "소손실계수", MappingName = "a" });
            dataGrid.Columns.Add(new GridTextColumn() { HeaderText = "상태"      , MappingName = "a" });
        }
        private void InitializeJunctionDataGrid(SfDataGrid dataGrid)
        {
            dataGrid.Columns.Add(new GridTextColumn()    { HeaderText = "EPANET ID"   , MappingName = "a" });
            dataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "X좌표"       , MappingName = "a" });
            dataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "Y좌표"       , MappingName = "a" });
            dataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "관저고"      , MappingName = "a" });
            dataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "용수수요량"  , MappingName = "a" });
            dataGrid.Columns.Add(new GridTextColumn()    { HeaderText = "용수수요패턴", MappingName = "a" });
        }

        public void Clear()
        {
            txtEpanetRpt.Text = string.Empty;
            _networkMap.Clear();
        }
        public void LoadInp(EpanetService service)
        {
            Clear();
            _networkMap.LoadInp(service);
        }

        public override void Refresh()
        {
            _networkMap.Refresh();
            base.Refresh();
        }
    }
}
