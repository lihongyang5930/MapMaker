using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using DrPipe.Core.Services;
using DrPipe.Diagnosis.Models;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;

namespace DrPipe.Diagnosis.Views.Local.Analysis.WaterQuality
{
    public partial class WeightView : UserControl
    {
        public WeightView()
        {
            InitializeComponent();
            InitializeDataGrid(dataGrid, new SfDataGrid());

            var dataSource = new [] { 
                new DataGridModel { Col01 = "잔류염소", Col02 = 0.11, Details = new [] { 
                    new DataGridModel { Col01 = "4.0초과"        , Col02 = 0    },
                    new DataGridModel { Col01 = "1.0이상~4.0미만", Col02 = 0.25 },
                    new DataGridModel { Col01 = "0.7이상~1.0미만", Col02 = 0.5  },
                    new DataGridModel { Col01 = "0.4이상~0.7미만", Col02 = 0.75 },
                    new DataGridModel { Col01 = "0.1이상~0.4미만", Col02 = 1    },
                    new DataGridModel { Col01 = "1.0미만"        , Col02 = 0    },
                }},
                new DataGridModel { Col01 = "일반세균", Col02 = 0.1, Details = new [] { 
                    new DataGridModel { Col01 = "100이상"        , Col02 = 0   },
                    new DataGridModel { Col01 = "0초과~100미만"  , Col02 = 0.5 },
                    new DataGridModel { Col01 = "0이하"          , Col02 = 1   },
                }},
                new DataGridModel { Col01 = "대장균군", Col02 = 0.12, Details = new [] { 
                    new DataGridModel { Col01 = "검출(0초과)"    , Col02 = 0   },
                    new DataGridModel { Col01 = "불검출(0)"      , Col02 = 1   },
                }},
                new DataGridModel { Col01 = "총대장균군", Col02 = 0.12, Details = new [] { 
                    new DataGridModel { Col01 = "검출(0초과)"    , Col02 = 0   },
                    new DataGridModel { Col01 = "불검출(0)"      , Col02 = 1   },
                }},
                new DataGridModel { Col01 = "철", Col02 = 0.04, Details = new [] { 
                    new DataGridModel { Col01 = "0.3이상"           , Col02 = 0    },
                    new DataGridModel { Col01 = "1.15이상~0.3미만"  , Col02 = 0.25 },
                    new DataGridModel { Col01 = "0.075이상~0.15미만", Col02 = 0.5  },
                    new DataGridModel { Col01 = "0.03이상~0.075미만", Col02 = 0.75 },
                    new DataGridModel { Col01 = "0.03미만"          , Col02 = 1    },
                }},
                new DataGridModel { Col01 = "구리", Col02 = 0.04, Details = new [] { 
                    new DataGridModel { Col01 = "1.0이상"          , Col02 = 0    },
                    new DataGridModel { Col01 = "0.6이상~1.0미만"  , Col02 = 0.25 },
                    new DataGridModel { Col01 = "0.3이상~0.6미만"  , Col02 = 0.5  },
                    new DataGridModel { Col01 = "0.1이상~0.3미만"  , Col02 = 0.75 },
                    new DataGridModel { Col01 = "0.1미만"          , Col02 = 1    },
                }},
                new DataGridModel { Col01 = "아연", Col02 = 0.03, Details = new [] { 
                    new DataGridModel { Col01 = "3.0이상"            , Col02 = 0    },
                    new DataGridModel { Col01 = "1.5이상~3.0미만"    , Col02 = 0.25 },
                    new DataGridModel { Col01 = "0.075이상~1.5미만"  , Col02 = 0.5  },
                    new DataGridModel { Col01 = "0.03이상~0.075미만" , Col02 = 0.75 },
                    new DataGridModel { Col01 = "0.03미만"           , Col02 = 1    },
                }},
                new DataGridModel { Col01 = "탁도", Col02 = 0.1, Details = new [] { 
                    new DataGridModel { Col01 = "0.5이상"            , Col02 = 0    },
                    new DataGridModel { Col01 = "0.4이상~0.5미만"    , Col02 = 0.25 },
                    new DataGridModel { Col01 = "0.25이상~0.4미만"   , Col02 = 0.5  },
                    new DataGridModel { Col01 = "0.10이상~0.25미만"  , Col02 = 0.75 },
                    new DataGridModel { Col01 = "0.10미만"           , Col02 = 1    },
                }},
                new DataGridModel { Col01 = "총트리할로메탄", Col02 = 0.1, Details = new [] { 
                    new DataGridModel { Col01 = "100이상"            , Col02 = 0    },
                    new DataGridModel { Col01 = "60이상~100미만"     , Col02 = 0.25 },
                    new DataGridModel { Col01 = "30이상~60미만"      , Col02 = 0.5  },
                    new DataGridModel { Col01 = "10이상~30미만"      , Col02 = 0.75 },
                    new DataGridModel { Col01 = "10미만"             , Col02 = 1    },
                }},
                new DataGridModel { Col01 = "할로아세틱에시드", Col02 = 0.1, Details = new [] { 
                    new DataGridModel { Col01 = "80이상"             , Col02 = 0    },
                    new DataGridModel { Col01 = "50이상~80미만"      , Col02 = 0.25 },
                    new DataGridModel { Col01 = "30이상~50미만"      , Col02 = 0.5  },
                    new DataGridModel { Col01 = "10이상~30미만"      , Col02 = 0.75 },
                    new DataGridModel { Col01 = "10미만"             , Col02 = 1    },
                }},
                new DataGridModel { Col01 = "암모니아성질소", Col02 = 0.03, Details = new [] { 
                    new DataGridModel { Col01 = "0.5이상"            , Col02 = 0    },
                    new DataGridModel { Col01 = "0.3이상~0.5미만"    , Col02 = 0.25 },
                    new DataGridModel { Col01 = "0.15이상~0.3미만"   , Col02 = 0.5  },
                    new DataGridModel { Col01 = "0.05이상~0.15미만"  , Col02 = 0.75 },
                    new DataGridModel { Col01 = "0.05미만"           , Col02 = 1    },
                }},
                new DataGridModel { Col01 = "염소이온", Col02 = 0.02, Details = new [] { 
                    new DataGridModel { Col01 = "250이상"            , Col02 = 0    },
                    new DataGridModel { Col01 = "150이상~0.5미만"    , Col02 = 0.25 },
                    new DataGridModel { Col01 = "75이상~0.3미만"   , Col02 = 0.5  },
                    new DataGridModel { Col01 = "30이상~0.15미만"  , Col02 = 0.75 },
                    new DataGridModel { Col01 = "30미만"           , Col02 = 1    },
                }},
                new DataGridModel { Col01 = "pH", Col02 = 0.05, Details = new [] { 
                    new DataGridModel { Col01 = "8.3이상"            , Col02 = 0 },
                    new DataGridModel { Col01 = "5.8초과~8.3미만"    , Col02 = 1 },
                    new DataGridModel { Col01 = "5.8이하"            , Col02 = 0 },
                }},
            };
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

            masterDataGrid.Columns.Add(new GridTextColumn()    { HeaderText = "평가항목" , AutoSizeColumnsMode = AutoSizeColumnsMode.AllCells,   MappingName = nameof(DataGridModel.Col01) });
            masterDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "가중치"   , AutoSizeColumnsMode = AutoSizeColumnsMode.AllCells,   MappingName = nameof(DataGridModel.Col02), NumberFormatInfo = numberFormat2 });
            masterDataGrid.AutoGenerateColumns = false;

            detailDataGrid.Columns.Add(new GridTextColumn()    { HeaderText = "범위"     , AutoSizeColumnsMode = AutoSizeColumnsMode.AllCells,   MappingName = nameof(DataGridModel.Col01) });
            detailDataGrid.Columns.Add(new GridNumericColumn() { HeaderText = "조건값"   , AutoSizeColumnsMode = AutoSizeColumnsMode.AllCells,   MappingName = nameof(DataGridModel.Col02), NumberFormatInfo = numberFormat2 });
            detailDataGrid.AutoGenerateColumns = false;

            var detailsView = new GridViewDefinition();
            detailsView.RelationalColumn = nameof(DataGridModel.Details);
            detailsView.DataGrid         = detailDataGrid;

            masterDataGrid.DetailsViewDefinitions.Add(detailsView);
        }
    }
}
