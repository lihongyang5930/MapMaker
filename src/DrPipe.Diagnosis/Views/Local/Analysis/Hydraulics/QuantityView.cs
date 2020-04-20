using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using DrPipe.Core.Services;
using DrPipe.Diagnosis.Models;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;

namespace DrPipe.Diagnosis.Views.Local.Analysis.Hydraulics
{
    public partial class QuantityView : UserControl
    {
        public QuantityView()
        {
            InitializeComponent();
            InitializeDataGrid(dataGrid, new SfDataGrid());
        }

        public void SetDataSource(IEnumerable<DataGridModel> dataSource)
        {
            dataGrid.DataSource = dataSource;
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

            var numberFormat3 = new NumberFormatInfo();
            numberFormat3.NumberDecimalDigits = 3;
            numberFormat3.NumberGroupSizes = new int[] { 3 };

            //\r\n
            masterDataGrid.Columns.Add(new GridTextColumn()    { HeaderText = "날짜 "                               , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(DataGridModel.Col01) });
            masterDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "유입유량(m³/월)"                     , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(DataGridModel.Col02), NumberFormatInfo = numberFormat  });
            masterDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "사용량(m³/월)"                       , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(DataGridModel.Col03), NumberFormatInfo = numberFormat  });
            masterDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "평균수압(m)"                         , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(DataGridModel.Col04), NumberFormatInfo = numberFormat2, MaximumWidth = 150 });
            masterDataGrid.AutoGenerateColumns = false;

            detailDataGrid.Columns.Add(new GridTextColumn()    { HeaderText = "진단구역명"                          , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(DataGridModel.Col01) });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "상수관로연장(m)"                     , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(DataGridModel.Col02), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "급수전수(전)"                        , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(DataGridModel.Col03), NumberFormatInfo = numberFormat  });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "평균수압(m)"                         , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(DataGridModel.Col04), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "유입유량(m³/월)"                     , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(DataGridModel.Col05), NumberFormatInfo = numberFormat  });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "사용량(m³/월)"                       , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(DataGridModel.Col06), NumberFormatInfo = numberFormat  });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "급수전밀도"                          , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(DataGridModel.Col07), NumberFormatInfo = numberFormat3 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "유수율(%)"                           , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(DataGridModel.Col08), NumberFormatInfo = numberFormat3 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "무수율(≒누수율)(%)"                  , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(DataGridModel.Col09), NumberFormatInfo = numberFormat3 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "급수전당무수수량(≒누수량)(m³/일/전)" , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(DataGridModel.Col10), NumberFormatInfo = numberFormat3 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "관로연장당무수수량(m³/일/km)"        , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(DataGridModel.Col11), NumberFormatInfo = numberFormat2 });
            detailDataGrid.AutoGenerateColumns = false;

            var detailsView = new GridViewDefinition();
            detailsView.RelationalColumn = nameof(DataGridModel.Details);
            detailsView.DataGrid         = detailDataGrid;

            masterDataGrid.DetailsViewDefinitions.Add(detailsView);
            //dataGrid.SelectionChanged   += OnPatternMasterDataGridSelectionChanged;
        }
    }
}
