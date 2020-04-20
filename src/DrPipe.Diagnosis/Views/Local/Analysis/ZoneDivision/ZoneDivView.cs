using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DrPipe.Core.Services;
using DrPipe.Diagnosis.Models;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;

namespace DrPipe.Diagnosis.Views.Local.Analysis.ZoneDivision
{
    public partial class ZoneDivView : UserControl
    {
        public ZoneDivView()
        {
            InitializeComponent();
            InitializeDataGrid(dataGrid1, dataGrid2, new SfDataGrid());
            dataGrid1.DataSource = GetSampleDataSource();
        }

        private void InitializeDataGrid(SfDataGrid masterDataGrid, SfDataGrid detailDataGrid, SfDataGrid groupDataGrid)
        {
            Appearances.DataGrid(masterDataGrid);
            Appearances.DataGrid(detailDataGrid);
            Appearances.DataGrid(groupDataGrid);

            var numberFormat = new NumberFormatInfo();
            numberFormat.NumberDecimalDigits = 0;
            numberFormat.NumberGroupSizes    = new int[] { 3 };

            var numberFormat2 = new NumberFormatInfo();
            numberFormat2.NumberDecimalDigits = 2;
            numberFormat2.NumberGroupSizes = new int[] { 3 };

            var numberFormat3 = new NumberFormatInfo();
            numberFormat3.NumberDecimalDigits = 3;
            numberFormat3.NumberGroupSizes = new int[] { 3 };

            masterDataGrid.Columns.Add(new GridCheckBoxColumn(){ HeaderText = "선택"     , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(DataGridModel.Col01) });
            masterDataGrid.Columns.Add(new GridTextColumn()    { HeaderText = "분할기준" , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(DataGridModel.Col02) });
            masterDataGrid.Columns.Add(new GridTextColumn()    { HeaderText = "분할개수" , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(DataGridModel.Col03) });
            masterDataGrid.AutoGenerateColumns = false;
            masterDataGrid.SelectionChanged   += OnMasterDataGridSelectionChanged;

            groupDataGrid.Columns.Add(new GridTextColumn(){ HeaderText = "그룹명"     , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,  MappingName = nameof(DataGridModel.Col01) });
            groupDataGrid.AutoGenerateColumns = false;

            var detailsView = new GridViewDefinition();
            detailsView.RelationalColumn = "_";
            detailsView.DataGrid         = groupDataGrid;
            masterDataGrid.DetailsViewDefinitions.Add(detailsView);

            detailDataGrid.Columns.Add(new GridTextColumn()    { HeaderText = "No."      , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(DataGridModel.Col01) });
            detailDataGrid.Columns.Add(new GridTextColumn()    { HeaderText = "자료내용" , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(DataGridModel.Col02) });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "객체개수" , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(DataGridModel.Col03), NumberFormatInfo = numberFormat  });
            detailDataGrid.AutoGenerateColumns = false;
        }

        private void OnMasterDataGridSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridModel model = null;
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                model = e.AddedItems.First() as DataGridModel;
            }
            dataGrid2.DataSource = model.Details;
        }

        private DataGridModel[] GetSampleDataSource()
        {
            var dataSource = new [] {
                new DataGridModel { 
                        Col01 = false, Col02 = "관재질", Col03 = 0,
                        Details = new [] { 
                            new DataGridModel { Col01 = 1, Col02 = "DCIP", Col03 = 185 },
                            new DataGridModel { Col01 = 2, Col02 = "DIP" , Col03 =  65 },
                            new DataGridModel { Col01 = 3, Col02 = "GRP" , Col03 =   7 },
                            new DataGridModel { Col01 = 4, Col02 = "PE"  , Col03 = 150 },
                            new DataGridModel { Col01 = 5, Col02 = "SP"  , Col03 =  22 },
                }},
                new DataGridModel { 
                        Col01 = false, Col02 = "관경", Col03 = 0,
                        Details = new [] { 
                            new DataGridModel { Col01 =  1, Col02 =  "20", Col03 =   1 },
                            new DataGridModel { Col01 =  2, Col02 =  "25", Col03 =   1 },
                            new DataGridModel { Col01 =  3, Col02 =  "50", Col03 =   1 },
                            new DataGridModel { Col01 =  4, Col02 =  "75", Col03 =  46 },
                            new DataGridModel { Col01 =  5, Col02 =  "80", Col03 =  39 },
                            new DataGridModel { Col01 =  6, Col02 = "100", Col03 = 153 },
                            new DataGridModel { Col01 =  7, Col02 = "125", Col03 =   3 },
                            new DataGridModel { Col01 =  8, Col02 = "150", Col03 =  27 },
                            new DataGridModel { Col01 =  9, Col02 = "200", Col03 = 115 },
                            new DataGridModel { Col01 = 10, Col02 = "250", Col03 =  13 },
                            new DataGridModel { Col01 = 11, Col02 = "300", Col03 =  12 },
                            new DataGridModel { Col01 = 12, Col02 = "350", Col03 =   7 },
                            new DataGridModel { Col01 = 13, Col02 = "500", Col03 =  20 },
                }},

                new DataGridModel {
                        Col01 = false, Col02 = "매설년수", Col03 = 0,
                        Details = new [] {
                            new DataGridModel { Col01 =  1, Col02 = "9" , Col03 = 7 },
                            new DataGridModel { Col01 =  2, Col02 = "10", Col03 = 18 },
                            new DataGridModel { Col01 =  3, Col02 = "11", Col03 = 21 },
                            new DataGridModel { Col01 =  4, Col02 = "12", Col03 = 46 },
                            new DataGridModel { Col01 =  5, Col02 = "13", Col03 = 31 },
                            new DataGridModel { Col01 =  6, Col02 = "14", Col03 = 20 },
                            new DataGridModel { Col01 =  7, Col02 = "15", Col03 = 3 },
                            new DataGridModel { Col01 =  8, Col02 = "16", Col03 = 5 },
                            new DataGridModel { Col01 =  9, Col02 = "17", Col03 = 59 },
                            new DataGridModel { Col01 = 10, Col02 = "18", Col03 = 17 },
                            new DataGridModel { Col01 = 11, Col02 = "19", Col03 =  2},
                            new DataGridModel { Col01 = 12, Col02 = "20", Col03 =  1},
                            new DataGridModel { Col01 = 13, Col02 = "23", Col03 =  22},
                            new DataGridModel { Col01 = 14, Col02 = "24", Col03 =  44},
                            new DataGridModel { Col01 = 15, Col02 = "25", Col03 =  41},
                            new DataGridModel { Col01 = 16, Col02 = "30", Col03 =  1},
                            new DataGridModel { Col01 = 17, Col02 = "35", Col03 =  4},
                }},

                new DataGridModel {
                        Col01 = false, Col02 = "관로용도", Col03 = 0,
                        Details = new [] {
                            new DataGridModel { Col01 =  1, Col02 = "배수관" , Col03 = 436 },
                }},

                new DataGridModel {
                        Col01 = false, Col02 = "소블록", Col03 = 0,
                        Details = new [] {
                            new DataGridModel { Col01 =  1, Col02 = "소블록3", Col03 = 251 },
                            new DataGridModel { Col01 =  2, Col02 = "소블록4", Col03 = 179 },
                }},

               new DataGridModel {
                        Col01 = false, Col02 = "행정구역", Col03 = 0,
                        Details = new [] {
                            new DataGridModel { Col01 =  1, Col02 = "행정동", Col03 = 438 },
                }},

               new DataGridModel {
                        Col01 = false, Col02 = "진단구역", Col03 = 0,
                        Details = new [] {
                            new DataGridModel { Col01 =  1, Col02 = "소블록3", Col03 = 251 },
                            new DataGridModel { Col01 =  2, Col02 = "소블록4", Col03 = 179 },
                }},

               new DataGridModel {
                        Col01 = false, Col02 = "중블록", Col03 = 0,
                        Details = new [] {
                            new DataGridModel { Col01 =  "", Col02 = "", Col03 = "" },
                }},

               new DataGridModel {
                        Col01 = false, Col02 = "관로구분", Col03 = 0,
                        Details = new [] {
                            new DataGridModel { Col01 =  "1", Col02 = "상수관로", Col03 = 438 },
                }},

               new DataGridModel {
                        Col01 = false, Col02 = "토양종류", Col03 = 0,
                        Details = new [] {
                            new DataGridModel { Col01 =  "", Col02 = "", Col03 = "" },
                }},

               new DataGridModel {
                        Col01 = false, Col02 = "손익분석진단구간", Col03 = 0,
                        Details = new [] {
                            new DataGridModel { Col01 =  "", Col02 = "", Col03 = "" },
                }},

               new DataGridModel {
                        Col01 = false, Col02 = "전기방식", Col03 = 0,
                        Details = new [] {
                            new DataGridModel { Col01 =  "", Col02 = "", Col03 = "" },
                }},

               new DataGridModel {
                        Col01 = false, Col02 = "급수분기수", Col03 = 0,
                        Details = new [] {
                            new DataGridModel { Col01 =  "1" , Col02 = "0" , Col03 = 222 },
                            new DataGridModel { Col01 =  "2" , Col02 = "1" , Col03 = 55  },
                            new DataGridModel { Col01 =  "3" , Col02 = "2" , Col03 = 28  },
                            new DataGridModel { Col01 =  "4" , Col02 = "3" , Col03 = 21  },
                            new DataGridModel { Col01 =  "5" , Col02 = "4" , Col03 = 24  },
                            new DataGridModel { Col01 =  "6" , Col02 = "5" , Col03 = 15  },
                            new DataGridModel { Col01 =  "7" , Col02 = "6" , Col03 = 19  },
                            new DataGridModel { Col01 =  "8" , Col02 = "7" , Col03 = 12  },
                            new DataGridModel { Col01 =  "9" , Col02 = "8" , Col03 = 14  },
                            new DataGridModel { Col01 =  "10", Col02 = "9" , Col03 = 4   },
                            new DataGridModel { Col01 =  "11", Col02 = "10", Col03 = 5   },
                            new DataGridModel { Col01 =  "12", Col02 = "11", Col03 = 6   },
                            new DataGridModel { Col01 =  "13", Col02 = "12", Col03 = 2   },
                            new DataGridModel { Col01 =  "14", Col02 = "13", Col03 = 4   },
                            new DataGridModel { Col01 =  "15", Col02 = "14", Col03 = 2   },
                            new DataGridModel { Col01 =  "16", Col02 = "15", Col03 = 1   },
                            new DataGridModel { Col01 =  "17", Col02 = "17", Col03 = 2   },
                            new DataGridModel { Col01 =  "18", Col02 = "21", Col03 = 1   },
                            new DataGridModel { Col01 =  "19", Col02 = "27", Col03 = 1   },
                }},

               new DataGridModel {
                        Col01 = false, Col02 = "급수분기수", Col03 = 0,
                        Details = new [] {
                            new DataGridModel { Col01 =  "1" , Col02 = "0.456789" , Col03 = 1  },
                            new DataGridModel { Col01 =  "2" , Col02 = "0.986123" , Col03 = 1  },
                            new DataGridModel { Col01 =  "3" , Col02 = "0.312456" , Col03 = 1  },
                            new DataGridModel { Col01 =  "4" , Col02 = "0.152351" , Col03 = 1  },
                            new DataGridModel { Col01 =  "5" , Col02 = "0.351153" , Col03 = 1  },
                            new DataGridModel { Col01 =  "6" , Col02 = "0.456879" , Col03 = 1  },
                            new DataGridModel { Col01 =  "7" , Col02 = "0.639685" , Col03 = 1  },
                            new DataGridModel { Col01 =  "8" , Col02 = "0.78612"  , Col03 = 1  },
                            new DataGridModel { Col01 =  "9" , Col02 = "0.15634"  , Col03 = 1  },
                            new DataGridModel { Col01 =  "10", Col02 = "0.64817"  , Col03 = 1  },
                            new DataGridModel { Col01 =  "11", Col02 = "0.03312"  , Col03 = 1  },
                            new DataGridModel { Col01 =  "12", Col02 = "0.17486"  , Col03 = 1  },
                            new DataGridModel { Col01 =  "13", Col02 = "0.23215"  , Col03 = 1  },
                            new DataGridModel { Col01 =  "14", Col02 = "0.32013"  , Col03 = 1  },
                            new DataGridModel { Col01 =  "15", Col02 = "0.454786" , Col03 = 1  },
                            new DataGridModel { Col01 =  "16", Col02 = "0.54806"  , Col03 = 1  },
                            new DataGridModel { Col01 =  "17", Col02 = "0.70345"  , Col03 = 1  },
                            new DataGridModel { Col01 =  "18", Col02 = "0.101053" , Col03 = 1  },
                            new DataGridModel { Col01 =  "19", Col02 = "0.761085" , Col03 = 1   },
                }},

               new DataGridModel {
                        Col01 = false, Col02 = "내압+외압에 의한 인장", Col03 = 0,
                        Details = new [] {
                            new DataGridModel { Col01 =  "" , Col02 = "" , Col03 = "" },
                }},

                new DataGridModel {
                        Col01 = false, Col02 = "대블록", Col03 = 0,
                        Details = new [] {
                            new DataGridModel { Col01 =  "" , Col02 = "" , Col03 = "" },
                }},

            };
            return dataSource;
        }
    }
}
