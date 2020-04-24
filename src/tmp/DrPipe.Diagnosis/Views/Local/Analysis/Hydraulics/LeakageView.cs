using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DrPipe.Core.Services;
using DrPipe.Diagnosis.Models;
using MindOne.DrPipe.Dpf.Models;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;

namespace DrPipe.Diagnosis.Views.Local.Analysis.Hydraulics
{
    public partial class LeakageView : UserControl
    {
        GridComboBoxColumn _pipeTypeComboBoxColumn;

        //Dictionary<object, Pipe> _파열누수량샘플값 = new Dictionary<object, Pipe>();


        public LeakageView()
        {
            InitializeComponent();
            InitializeDataGrid(dataGrid, new SfDataGrid());
        }
        public void SetDataSource(IEnumerable<PipeGroup> dataSource)
        {
            var 블록3 = dataSource.Where(x => x.Zone == "소블록3").Single();
            블록3.InputAvgPressure =   10.02;
            블록3.AvgPressure      =    0;
            블록3.InFlow           = 3193.55;
            블록3.Usage            = 2919.23;
            블록3.AnhydrouAmount   =  274.32;
            블록3.Col6             =    0.00;
            블록3.Col7             =    0.00;
            블록3.Col8             =    0.00;

            var 블록4 = dataSource.Where(x => x.Zone == "소블록4").Single();
            블록4.InputAvgPressure =    6.35;
            블록4.AvgPressure      =    0;
            블록4.InFlow           = 2580.65;
            블록4.Usage            = 2473.90;
            블록4.AnhydrouAmount   =  106.74;
            블록4.Col6             =    0.00;
            블록4.Col7             =    0.00;
            블록4.Col8             =    0.00;

            foreach (var pipeGroup in dataSource)
            {
                pipeGroup.Col9           = pipeGroup.Pipes.Where(x => x.LEAK_BASE .HasValue).Select(x => x.LEAK_BASE .Value).Sum();
                pipeGroup.RuptureLeakage = pipeGroup.Pipes.Where(x => x.LEAK_BREAK.HasValue).Select(x => x.LEAK_BREAK.Value).Sum();
                pipeGroup.Leakage        = pipeGroup.Pipes.Where(x => x.LEAK_SUM  .HasValue).Select(x => x.LEAK_SUM  .Value).Sum();
            }

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

            masterDataGrid.AutoGenerateColumns = false;
            masterDataGrid.Columns.Add(new GridTextColumn()    { HeaderText = "진단구역"         , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader, MappingName = nameof(PipeGroup.Zone             ) });
            masterDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "평균표고(m)"      , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader, MappingName = nameof(PipeGroup.InputAvgPressure ), NumberFormatInfo = numberFormat2 });
            masterDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "평균수압(m)"      , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader, MappingName = nameof(PipeGroup.AvgPressure      ), NumberFormatInfo = numberFormat2 });
            masterDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "유입유량(m³/일)"  , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader, MappingName = nameof(PipeGroup.InFlow           ), NumberFormatInfo = numberFormat2 });
            masterDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "사용량(m³/일)"    , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader, MappingName = nameof(PipeGroup.Usage            ), NumberFormatInfo = numberFormat2 });
            masterDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "무수수량(m³/일)"  , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader, MappingName = nameof(PipeGroup.AnhydrouAmount   ), NumberFormatInfo = numberFormat2 });
            masterDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "배수관"           , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader, MappingName = nameof(PipeGroup.Col6             ), NumberFormatInfo = numberFormat2 });
            masterDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "급수시설"         , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader, MappingName = nameof(PipeGroup.Col7             ), NumberFormatInfo = numberFormat2 });
            masterDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "옥내"             , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader, MappingName = nameof(PipeGroup.Col8             ), NumberFormatInfo = numberFormat2 });
            masterDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "배경누수량(m³/일)", AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader, MappingName = nameof(PipeGroup.Col9             ), NumberFormatInfo = numberFormat2 });
            masterDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "파열누수량(m³/일)", AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader, MappingName = nameof(PipeGroup.RuptureLeakage   ), NumberFormatInfo = numberFormat2 });
            masterDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "누수량(m³/일)"    , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader, MappingName = nameof(PipeGroup.Leakage          ), NumberFormatInfo = numberFormat2 });

            var stackedHeaderRow = new StackedHeaderRow();
            stackedHeaderRow.StackedColumns.Add(new StackedColumn() {
                HeaderText   = "배경누수량(m³/일)",
                ChildColumns = $"{nameof(PipeGroup.Col6)},{nameof(PipeGroup.Col7)},{nameof(PipeGroup.Col8)}",
            });
            masterDataGrid.StackedHeaderRows.Add(stackedHeaderRow);

            detailDataGrid.AutoGenerateColumns = false;
            _pipeTypeComboBoxColumn = new GridComboBoxColumn() { HeaderText = "관재질"          , MappingName = nameof(Pipe.PP_TYPE) };
            detailDataGrid.Columns.Add(new GridTextColumn()    { HeaderText = "관로ID"          , MappingName = nameof(Pipe.ID) });
            detailDataGrid.Columns.Add(new GridTextColumn()    { HeaderText = "관리번호"        , MappingName = nameof(Pipe.MGR_ID ) });
            detailDataGrid.Columns.Add(_pipeTypeComboBoxColumn);
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "관경"            , MappingName = nameof(Pipe.PP_CIR    ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "관로길이"        , MappingName = nameof(Pipe.PP_LEN    ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "매설년수"        , MappingName = nameof(Pipe.NYEAR     ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "급수관연장"      , MappingName = nameof(Pipe.Col1      ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "급수전수"        , MappingName = nameof(Pipe.Col2      ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "배경누수량"      , MappingName = nameof(Pipe.LEAK_BASE ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "파열누수량"      , MappingName = nameof(Pipe.LEAK_BREAK), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "누수량"          , MappingName = nameof(Pipe.LEAK_SUM  ), NumberFormatInfo = numberFormat2 });
            

            var detailsView = new GridViewDefinition();
            detailsView.RelationalColumn = nameof(PipeGroup.Pipes);
            detailsView.DataGrid         = detailDataGrid;

            masterDataGrid.DetailsViewDefinitions.Add(detailsView);
            //dataGrid.SelectionChanged   += OnPatternMasterDataGridSelectionChanged;
        }

        public void Execute()
        {
        }

        public bool TestExecuted { get; set; }

        /// <summary>
        /// 시연용 샘플
        /// </summary>
        public void Execute(DBM_PIPE[] pipes)
        {
            var dataSource = dataGrid.DataSource as IEnumerable<PipeGroup>;

            var 블록3 = dataSource.Where(x => x.Zone == "소블록3").Single();
            if (블록3.AvgPressure == 15)
            {
                블록3.InputAvgPressure =   10.02;
                블록3.AvgPressure      =   15;
                블록3.InFlow           = 3193.55;
                블록3.Usage            = 2919.23;
                블록3.AnhydrouAmount   =  274.32;
                블록3.Col6             =    7.66;
                블록3.Col7             =   26.50;
                블록3.Col8             =    8.09;
            }

            var 블록4 = dataSource.Where(x => x.Zone == "소블록4").Single();
            if (블록4.AvgPressure == 0)
            {
                블록4.InputAvgPressure =    6.35;
                블록4.AvgPressure      =    0;
                블록4.InFlow           = 2580.65;
                블록4.Usage            = 2473.90;
                블록4.AnhydrouAmount   =  106.74;
                블록4.Col6             =    0.00;
                블록4.Col7             =    0.00;
                블록4.Col8             =    0.00;
            }

            foreach (var pipeGroup in dataSource)
            {
                foreach (var pipe in pipeGroup.Pipes)
                {
                    var sample = pipes.Where(x => x.ID == pipe.ID).Single();
                    pipe.LEAK_BASE  = sample.LEAK_BASE ;
                    pipe.LEAK_BREAK = sample.LEAK_BREAK;
                    pipe.LEAK_SUM   = sample.LEAK_SUM  ;
                }
                pipeGroup.Col9           = pipeGroup.Pipes.Where(x => x.LEAK_BASE .HasValue).Select(x => x.LEAK_BASE .Value).Sum();
                pipeGroup.RuptureLeakage = pipeGroup.Pipes.Where(x => x.LEAK_BREAK.HasValue).Select(x => x.LEAK_BREAK.Value).Sum();
                pipeGroup.Leakage        = pipeGroup.Pipes.Where(x => x.LEAK_SUM  .HasValue).Select(x => x.LEAK_SUM  .Value).Sum();
            }
            dataGrid.Refresh();
            TestExecuted = true;
        }
    }
}
