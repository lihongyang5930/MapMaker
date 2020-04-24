using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DrPipe.Core.Services;
using DrPipe.Diagnosis.Models;
using MindOne.DrPipe.Dpf.Models;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;

namespace DrPipe.Diagnosis.Views.Local.Analysis.WaterQuality
{
    public partial class BasePurificationPlantView : UserControl
    {
        public BasePurificationPlantView()
        {
            InitializeComponent();
            InitializeDataGrid(dgMaster, dgDetail);
        }

        public void SetDataSource(IEnumerable<WQT_WATER_STAND> masters, IEnumerable<WQT_BASE_SITE> details)
        {
            var masterDataSource = masters.Select(x => new DataGridModel { Col01 = x.NAME, Col02 = x.DESCRIPTION }).ToArray();
            foreach (var d in masterDataSource)
            {
                var avg        = details.Select(x => GetValue(d.Col01.ToString(), x)).Where(x => x != null).Select(x => x.Value).DefaultIfEmpty().Average();
                var min        = details.Select(x => GetValue(d.Col01.ToString(), x)).Where(x => x != null).Select(x => x.Value).DefaultIfEmpty().Min();
                var max        = details.Select(x => GetValue(d.Col01.ToString(), x)).Where(x => x != null).Select(x => x.Value).DefaultIfEmpty().Max();
                var stddev     = details.Select(x => GetValue(d.Col01.ToString(), x)).Where(x => x != null).Select(x => x.Value).DefaultIfEmpty().StdDev();
                var 변동계수   = stddev / avg;
                var 수질위반율 = 0;
                d.Col03 = avg;
                d.Col04 = min;
                d.Col05 = max;
                d.Col06 = stddev;
                d.Col07 = 변동계수;
                d.Col08 = 수질위반율;
            }
            dgMaster.DataSource = masterDataSource;
            dgDetail.DataSource = details;
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

            masterDataGrid.Columns.Add(new GridTextColumn()     { HeaderText = "수질항목"   , AutoSizeColumnsMode = AutoSizeColumnsMode.AllCells,   MappingName = nameof(DataGridModel.Col01) });
            masterDataGrid.Columns.Add(new GridTextColumn()     { HeaderText = "수질기준"   , AutoSizeColumnsMode = AutoSizeColumnsMode.AllCells,   MappingName = nameof(DataGridModel.Col02) });
            masterDataGrid.Columns.Add(new GridNumericColumn()  { HeaderText = "평균값"     , AutoSizeColumnsMode = AutoSizeColumnsMode.AllCells,   MappingName = nameof(DataGridModel.Col03), NumberFormatInfo = numberFormat3 });
            masterDataGrid.Columns.Add(new GridNumericColumn()  { HeaderText = "최소값"     , AutoSizeColumnsMode = AutoSizeColumnsMode.AllCells,   MappingName = nameof(DataGridModel.Col04), NumberFormatInfo = numberFormat3 });
            masterDataGrid.Columns.Add(new GridNumericColumn()  { HeaderText = "최대값"     , AutoSizeColumnsMode = AutoSizeColumnsMode.AllCells,   MappingName = nameof(DataGridModel.Col05), NumberFormatInfo = numberFormat3 });
            masterDataGrid.Columns.Add(new GridNumericColumn()  { HeaderText = "표준편차"   , AutoSizeColumnsMode = AutoSizeColumnsMode.AllCells,   MappingName = nameof(DataGridModel.Col06), NumberFormatInfo = numberFormat3 });
            masterDataGrid.Columns.Add(new GridNumericColumn()  { HeaderText = "변동계수"   , AutoSizeColumnsMode = AutoSizeColumnsMode.AllCells,   MappingName = nameof(DataGridModel.Col07), NumberFormatInfo = numberFormat3 });
            masterDataGrid.Columns.Add(new GridNumericColumn()  { HeaderText = "수질위반율" , AutoSizeColumnsMode = AutoSizeColumnsMode.AllCells,   MappingName = nameof(DataGridModel.Col08), NumberFormatInfo = numberFormat3 });
            masterDataGrid.AutoGenerateColumns = false;
            masterDataGrid.SelectionChanged   += OnDataGridSelectionChanged;

            detailDataGrid.Columns.Add(new GridDateTimeColumn(){ HeaderText = "채수일자"                     , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.YYMM), Format="yyyy-MM-dd" });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "일반세균"                     , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R1  ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "총대장균군"                   , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R2  ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "대장균군"                     , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R3  ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "납"                           , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R4  ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "불소"                         , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R5  ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "비소"                         , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R6  ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "세레늄"                       , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R7  ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "수은"                         , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R8  ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "시안"                         , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R9  ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "크롬"                         , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R10 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "암모니아성질소"               , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R11 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "질산성질소"                   , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R12 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "카드뮴"                       , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R13 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "보론"                         , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R14 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "페놀"                         , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R15 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "다이아지논"                   , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R16 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "파라티온"                     , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R17 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "페니트로티온"                 , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R18 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "카바릴"                       , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R19 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "1,1,1-트리클로로에탄"         , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R20 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "테트라클로로에틸렌"           , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R21 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "트리클로로에틸렌"             , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R22 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "디클로로메탄"                 , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R23 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "벤젠"                         , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R24 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "툴루엔"                       , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R25 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "에틸벤젠"                     , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R26 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "크실렌"                       , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R27 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "1,1-디클로로에틸렌"           , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R28 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "사염화탄소"                   , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R29 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "1,2-디브로모-3-클로로프로판"  , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R30 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "잔류염소"                     , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R31 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "총트리할로메탄"               , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R32 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "클로로포름"                   , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R33 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "클로랄하이드레이트"           , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R34 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "디브로모아세토니트릴"         , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R35 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "디클로로아세토니트릴"         , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R36 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "트리클로로아세토니트릴"       , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R37 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "할로아세틱에시드"             , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R38 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "경도"                         , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R39 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "과망간칼륨소비량"             , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R40 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "냄새"                         , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R41 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "맛"                           , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R42 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "구리"                         , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R43 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "색도"                         , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R44 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "세제"                         , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R45 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "PH"                           , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R46 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "아연"                         , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R47 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "염소이온"                     , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R48 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "증발잔류물"                   , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R49 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "철"                           , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R50 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "망간"                         , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R51 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "탁도"                         , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R52 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "황산이온"                     , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R53 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "알루미늄"                     , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(WQT_BASE_SITE.R54 ), NumberFormatInfo = numberFormat2 });
            detailDataGrid.AutoGenerateColumns = false;
        }

        private void OnDataGridSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            return;
            //WQT_WATER_STAND master = null;
            //if (e.AddedItems != null && e.AddedItems.Count > 0)
            //{
            //    master = e.AddedItems.First() as WQT_WATER_STAND;
            //}

            //foreach (var c in dgDetail.Columns)
            //{
            //    if (c.MappingName == nameof(WQT_BASE_SITE.YYMM))
            //    {
            //        c.Visible = true;
            //        continue;
            //    }
            //    if (master == null)
            //    {
            //        c.Visible = false;
            //        continue;
            //    }
            //    c.Visible = c.HeaderText == master.NAME;
            //}
        }

        private double? GetValue(string name, WQT_BASE_SITE value)
        {
            switch (name)
            {
                case "일반세균"                     : return value.R1  ;
                case "총대장균군"                   : return value.R2  ;
                case "대장균군"                     : return value.R3  ;
                case "납"                           : return value.R4  ;
                case "불소"                         : return value.R5  ;
                case "비소"                         : return value.R6  ;
                case "세레늄"                       : return value.R7  ;
                case "수은"                         : return value.R8  ;
                case "시안"                         : return value.R9  ;
                case "크롬"                         : return value.R10 ;
                case "암모니아성질소"               : return value.R11 ;
                case "질산성질소"                   : return value.R12 ;
                case "카드뮴"                       : return value.R13 ;
                case "보론"                         : return value.R14 ;
                case "페놀"                         : return value.R15 ;
                case "다이아지논"                   : return value.R16 ;
                case "파라티온"                     : return value.R17 ;
                case "페니트로티온"                 : return value.R18 ;
                case "카바릴"                       : return value.R19 ;
                case "1,1,1-트리클로로에탄"         : return value.R20 ;
                case "테트라클로로에틸렌"           : return value.R21 ;
                case "트리클로로에틸렌"             : return value.R22 ;
                case "디클로로메탄"                 : return value.R23 ;
                case "벤젠"                         : return value.R24 ;
                case "툴루엔"                       : return value.R25 ;
                case "에틸벤젠"                     : return value.R26 ;
                case "크실렌"                       : return value.R27 ;
                case "1,1-디클로로에틸렌"           : return value.R28 ;
                case "사염화탄소"                   : return value.R29 ;
                case "1,2-디브로모-3-클로로프로판"  : return value.R30 ;
                case "잔류염소"                     : return value.R31 ;
                case "총트리할로메탄"               : return value.R32 ;
                case "클로로포름"                   : return value.R33 ;
                case "클로랄하이드레이트"           : return value.R34 ;
                case "디브로모아세토니트릴"         : return value.R35 ;
                case "디클로로아세토니트릴"         : return value.R36 ;
                case "트리클로로아세토니트릴"       : return value.R37 ;
                case "할로아세틱에시드"             : return value.R38 ;
                case "경도"                         : return value.R39 ;
                case "과망간칼륨소비량"             : return value.R40 ;
                case "냄새"                         : return value.R41 ;
                case "맛"                           : return value.R42 ;
                case "구리"                         : return value.R43 ;
                case "색도"                         : return value.R44 ;
                case "세제"                         : return value.R45 ;
                case "PH"                           : return value.R46 ;
                case "아연"                         : return value.R47 ;
                case "염소이온"                     : return value.R48 ;
                case "증발잔류물"                   : return value.R49 ;
                case "철"                           : return value.R50 ;
                case "망간"                         : return value.R51 ;
                case "탁도"                         : return value.R52 ;
                case "황산이온"                     : return value.R53 ;
                case "알루미늄"                     : return value.R54 ;
            }
            return null;
        }
    }
}
