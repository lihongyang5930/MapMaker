using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DrPipe.Core.Services;
using DrPipe.Diagnosis.Models;
using MindOne.DrPipe.Dpf.Models;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;

namespace DrPipe.Diagnosis.Views.Local.Analysis.Hydraulics
{
    public partial class RoughnessCoefficientView : UserControl
    {
        public RoughnessCoefficientView()
        {
            InitializeComponent();
            InitializeDataGrid(dataGrid1, dataGrid2);
            dataGrid1.DataSource = GetSampleDataSource();
        }

        public void SetDataSource(DBM_PIPE[] pipes)
        {
            var dataSource = pipes
                                .Select(x => new DataGridModel {
                                    Col01 = x.ID,
                                    Col02 = x.PP_TYPE,
                                    Col03 = 100,
                                    Col04 =   0,
                                })
                                .ToArray();
            dataGrid2.DataSource = dataSource;
        }

        private void InitializeDataGrid(SfDataGrid datagrid1, SfDataGrid datagrid2)
        {
            Appearances.DataGrid(datagrid1);
            Appearances.DataGrid(datagrid2);

            var numberFormat = new NumberFormatInfo();
            numberFormat.NumberDecimalDigits = 0;
            numberFormat.NumberGroupSizes    = new int[] { 3 };

            var numberFormat2 = new NumberFormatInfo();
            numberFormat2.NumberDecimalDigits = 2;
            numberFormat2.NumberGroupSizes = new int[] { 3 };

            var numberFormat3 = new NumberFormatInfo();
            numberFormat3.NumberDecimalDigits = 3;
            numberFormat3.NumberGroupSizes = new int[] { 3 };

            datagrid1.AllowEditing = false;
            datagrid1.Style.CellStyle.BackColor = System.Drawing.Color.FromArgb(byte.MaxValue, 239, 239, 239);
            datagrid1.Style.CellStyle.TextColor = System.Drawing.Color.FromArgb(byte.MaxValue,  70,  70,  70);

            datagrid1.Columns.Add(new GridTextColumn()    { HeaderText = "Material"     , AutoSizeColumnsMode = AutoSizeColumnsMode.AllCells,  MappingName = nameof(DataGridModel.Col01) });
            datagrid1.Columns.Add(new GridNumericColumn() { HeaderText = "C Factor log" , AutoSizeColumnsMode = AutoSizeColumnsMode.AllCells,  MappingName = nameof(DataGridModel.Col02), NumberFormatInfo = numberFormat });
            datagrid1.Columns.Add(new GridNumericColumn() { HeaderText = "C Factor high", AutoSizeColumnsMode = AutoSizeColumnsMode.AllCells,  MappingName = nameof(DataGridModel.Col03), NumberFormatInfo = numberFormat });
            datagrid1.AutoGenerateColumns = false;

            datagrid2.ShowErrorIcon = false;
            datagrid2.ValidationMode = GridValidationMode.None;
            datagrid2.Columns.Add(new GridTextColumn()    { HeaderText = "관로ID" , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(DataGridModel.Col01) });
            datagrid2.Columns.Add(new GridTextColumn()    { HeaderText = "관재질" , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(DataGridModel.Col02) });
            datagrid2.Columns.Add(new GridNumericColumn() { HeaderText = "보정전" , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(DataGridModel.Col03), NumberFormatInfo = numberFormat  });
            datagrid2.Columns.Add(new GridNumericColumn() { HeaderText = "보정후" , AutoSizeColumnsMode = AutoSizeColumnsMode.ColumnHeader,   MappingName = nameof(DataGridModel.Col04), NumberFormatInfo = numberFormat  });
            datagrid2.AutoGenerateColumns = false;
        }

        private DataGridModel[] GetSampleDataSource()
        {
            var dataSource = new [] {
                new DataGridModel { Col01 = "Asbestos-cement"                      , Col02 = 140, Col03 = 140 },
                new DataGridModel { Col01 = "Cast iron new"                        , Col02 = 130, Col03 = 130 },
                new DataGridModel { Col01 = "Cast iron 10 years"                   , Col02 = 107, Col03 = 113 },
                new DataGridModel { Col01 = "Cast iron 20 years"                   , Col02 =  89, Col03 = 100 },
                new DataGridModel { Col01 = "Cast iron 30 years"                   , Col02 =  75, Col03 =  90 },
                new DataGridModel { Col01 = "Cast iron 40 years"                   , Col02 =  64, Col03 =  83 },
                new DataGridModel { Col01 = "Cement-Mortar Lined Ductile Iron Pipe", Col02 = 140, Col03 = 140 },
                new DataGridModel { Col01 = "Concrete"                             , Col02 = 100, Col03 = 140 },
                new DataGridModel { Col01 = "Copper"                               , Col02 = 130, Col03 = 140 },
                new DataGridModel { Col01 = "Steel"                                , Col02 =  90, Col03 = 110 },
                new DataGridModel { Col01 = "Galvanized iron"                      , Col02 = 120, Col03 = 120 },
                new DataGridModel { Col01 = "Polyethylene"                         , Col02 = 140, Col03 = 140 },
                new DataGridModel { Col01 = "Polyvinyl chloride (PVC)"             , Col02 = 150, Col03 = 150 },
                new DataGridModel { Col01 = "Fibre-reinforced plastic (FRP)"       , Col02 = 150, Col03 = 150 },
            };
            return dataSource;
        }
    }
}
