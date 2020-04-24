using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using DrPipe.Core.Services;
using DrPipe.Diagnosis.Models;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;

namespace DrPipe.Diagnosis.Views.Local.Analysis.Hydraulics
{
    public partial class PressureView : UserControl
    {
        GridComboBoxColumn _pipeTypeComboBoxColumn;

        public PressureView()
        {
            InitializeComponent();
            InitializeDataGrid(dataGrid, new SfDataGrid());
        }

        public void SetDataSource(IEnumerable<PipeGroup> dataSource)
        {
            dataGrid.DataSource = dataSource;
        }
        public void SetPipeTypeDataSource(string[] dataSource)
        {
            _pipeTypeComboBoxColumn.DataSource = dataSource;
        }
        private void InitializeDataGrid(SfDataGrid masterDataGrid, SfDataGrid detailDataGrid)
        {
            Appearances.DataGrid(masterDataGrid);
            Appearances.DataGrid(detailDataGrid);

            var numberFormat = new NumberFormatInfo();
            numberFormat.NumberDecimalDigits = 0;
            numberFormat.NumberGroupSizes    = new int[] { 3 };

            var numberFormat2 = new NumberFormatInfo();
            numberFormat2.NumberDecimalDigits = 2;
            numberFormat2.NumberGroupSizes    = new int[] { 3 };

            masterDataGrid.Columns.Add(new GridTextColumn()    { HeaderText = "진단구역명"              , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader, MappingName = nameof(PipeGroup.Zone) });
            masterDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "최소수압(kgf/cm²)"       , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader, MappingName = nameof(PipeGroup.MinPressure  ), NumberFormatInfo = numberFormat2 });
            masterDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "최대수압(kgf/cm²)"       , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader, MappingName = nameof(PipeGroup.MaxPressure  ), NumberFormatInfo = numberFormat2 });
            masterDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "평균수압(kgf/cm²)"       , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader, MappingName = nameof(PipeGroup.AvgPressure  ), NumberFormatInfo = numberFormat2 });
            masterDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "범위"                    , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader, MappingName = nameof(PipeGroup.StDevPressure), NumberFormatInfo = numberFormat2 });
            masterDataGrid.AutoGenerateColumns = false;

            _pipeTypeComboBoxColumn = new GridComboBoxColumn() { HeaderText = "관종"                    , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader, MappingName = nameof(Pipe.PP_TYPE) };
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "관로ID"                  , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader, MappingName = nameof(Pipe.ID), NumberFormatInfo = numberFormat });
            detailDataGrid.Columns.Add(new GridTextColumn()    { HeaderText = "관리번호"                , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader, MappingName = nameof(Pipe.MGR_ID) });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "최소수압(kgf/cm²)"       , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader, MappingName = nameof(Pipe.PRESSURE_MIN), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "최대수압(kgf/cm²)"       , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader, MappingName = nameof(Pipe.PRESSURE_MAX), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "평균수압(kgf/cm²)"       , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader, MappingName = nameof(Pipe.PRESSURE_AVG), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(_pipeTypeComboBoxColumn);
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "관경(mm)"                , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader, MappingName = nameof(Pipe.PP_CIR), NumberFormatInfo = numberFormat });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "관로길이(m)"             , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader, MappingName = nameof(Pipe.PP_LEN), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "매설년수"                , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader, MappingName = nameof(Pipe.NYEAR ), NumberFormatInfo  = numberFormat });
            detailDataGrid.AutoGenerateColumns = false;

            var detailsView = new GridViewDefinition();
            detailsView.RelationalColumn = nameof(PipeGroup.Pipes);
            detailsView.DataGrid         = detailDataGrid;

            masterDataGrid.DetailsViewDefinitions.Add(detailsView);
            //dataGrid.SelectionChanged   += OnPatternMasterDataGridSelectionChanged;
        }
    }
}
