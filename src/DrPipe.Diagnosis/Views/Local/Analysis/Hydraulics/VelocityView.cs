using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using DrPipe.Core.Services;
using DrPipe.Diagnosis.Models;
using Syncfusion.WinForms.DataGrid;

namespace DrPipe.Diagnosis.Views.Local.Analysis.Hydraulics
{
    public partial class VelocityView : UserControl
    {
        GridComboBoxColumn _pipeTypeComboBoxColumn;

        public VelocityView()
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
            numberFormat2.NumberGroupSizes = new int[] { 3 };

            masterDataGrid.Columns.Add(new GridTextColumn()    { HeaderText = "진단구역명"         , MappingName = nameof(PipeGroup.Zone) });
            masterDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "최소유속(m/sec)"    , MappingName = nameof(PipeGroup.MinVelocity), NumberFormatInfo   = numberFormat2 });
            masterDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "최대유속(m/sec)"    , MappingName = nameof(PipeGroup.MaxVelocity), NumberFormatInfo   = numberFormat2 });
            masterDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "평균유속(m/sec)"    , MappingName = nameof(PipeGroup.AvgVelocity), NumberFormatInfo   = numberFormat2 });
            masterDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "편차"               , MappingName = nameof(PipeGroup.StDevVelocity), NumberFormatInfo = numberFormat2 });
            masterDataGrid.AutoGenerateColumns = false;

            _pipeTypeComboBoxColumn = new GridComboBoxColumn() { HeaderText = "관종", MappingName = nameof(Pipe.PP_TYPE) };
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "관로ID"             , MappingName = nameof(Pipe.ID), NumberFormatInfo           = numberFormat  });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "관리번호"           , MappingName = nameof(Pipe.MGR_ID), NumberFormatInfo       = numberFormat  });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "최소유속(m/sec)"    , MappingName = nameof(Pipe.VELOCITY_MIN), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "최대유속(m/sec)"    , MappingName = nameof(Pipe.VELOCITY_MAX), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "평균유속(m/sec)"    , MappingName = nameof(Pipe.VELOCITY_AVG), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(_pipeTypeComboBoxColumn);
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "관경(mm)"           , MappingName = nameof(Pipe.PP_CIR), NumberFormatInfo = numberFormat  });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "관로길이(m)"        , MappingName = nameof(Pipe.PP_LEN), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "매설년수"           , MappingName = nameof(Pipe.NYEAR), NumberFormatInfo  = numberFormat  });
            detailDataGrid.AutoGenerateColumns = false;

            var detailsView = new GridViewDefinition();
            detailsView.RelationalColumn = nameof(PipeGroup.Pipes);
            detailsView.DataGrid         = detailDataGrid;

            masterDataGrid.DetailsViewDefinitions.Add(detailsView);
            //dataGrid.SelectionChanged   += OnPatternMasterDataGridSelectionChanged;
        }
    }
}
