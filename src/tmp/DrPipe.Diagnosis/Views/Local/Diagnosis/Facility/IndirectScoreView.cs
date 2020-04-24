using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.WinForms.DataGrid;

namespace DrPipe.Diagnosis.Views.Local.Diagnosis.Facility
{
    public partial class IndirectScoreView : UserControl
    {
        public IndirectScoreView()
        {
            InitializeComponent();

            //sfData1();
            //sfData2();

        }

        private void sfData1()
        {
            sfDataGrid1.Columns.Add(new GridCheckBoxColumn()    { MappingName = "Check", HeaderText = "", AllowCheckBoxOnHeader = true }); //, CheckBoxSize = new Size(13, 13) });
            sfDataGrid1.Columns.Add(new GridNumericColumn()     { MappingName = "Num", HeaderText = "숫자" });
            sfDataGrid1.Columns.Add(new GridTextColumn()        { MappingName = "Text1", HeaderText = "Test1" });
            sfDataGrid1.Columns.Add(new GridTextColumn()        { MappingName = "Text2", HeaderText = "Test2" });

            sfDataGrid1.DataSource = o();
        }

        private void sfData2()
        {
            sfDataGrid2.Columns.Add(new GridTextColumn()        { MappingName = "Text1", HeaderText = "평가항목" });
            sfDataGrid2.Columns.Add(new GridNumericColumn()     { MappingName = "Num", HeaderText = "가중치" });

            sfDataGrid2.DataSource = oo();

            

            GridViewDefinition orderDetailsView = new GridViewDefinition();
            orderDetailsView.RelationalColumn = "OrderDetails";

            SfDataGrid childGrid = new SfDataGrid();
            childGrid.AutoGenerateColumns = false;

            childGrid.Columns.Add(new GridTextColumn()           { MappingName = "ChildText", HeaderText = "조건값" });
            childGrid.Columns.Add(new GridNumericColumn()        { MappingName = "ChildNum", HeaderText = "값" });

            //childGrid.DataSource = ooo();

            orderDetailsView.DataGrid = childGrid;
            sfDataGrid2.DetailsViewDefinitions.Add(orderDetailsView);

        }

        private Test.DataTest[] o()
        {
            var dt = new[] {
                new Test.DataTest { Check = true,  Num = 1, Text1 = "a", Text2 = "0.1"  },
                new Test.DataTest { Check = false, Num = 2, Text1 = "b", Text2 = "0.2" }
            };
            return dt;
        }

        private Test.DataTest2[] oo()
        {
            var dt = new[] {
                new Test.DataTest2 { Text1 = "aa", Num = 11 },
                new Test.DataTest2 { Text1 = "bb", Num = 22 }
            };
            return dt;
        }

        private Test.DataTest22[] ooo()
        {
            var dt = new[] {
                new Test.DataTest22 { ChildText = "1200이상",          ChildNum = 1 },
                new Test.DataTest22 { ChildText = "700이상~1200 미만", ChildNum = 2 },
                new Test.DataTest22 { ChildText = "700이상~1200 미만", ChildNum = 3 }
            };
            return dt;
        }

        //private List<Test.DataTest22> ooo2()
        //{
        //    var dt = new List<Test.DataTest22>();

        //    dt.Add(GetDataTest22("1200이상", 1));
        //    dt.Add(GetDataTest22("700이상~1200 미만", 0.5));
        //    dt.Add(GetDataTest22("700미만", 0));

        //    return dt;
        //}

        private Test.DataTest22 GetDataTest22(string a, double b)
        {
            var _a = a;
            var _b = b;
            return new Test.DataTest22()
            {
                ChildText = _a,
                ChildNum  = _b
            };
        }
    }
}



namespace Test
{
    public class DataTest
    {
        public bool   Check { get; set; }
        public int    Num   { get; set; }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
    }

    public class DataTest2
    {
        public string  Text1 { get; set; }
        public double  Num   { get; set; }
    }

    public class DataTest22
    {
        public string ChildText { get; set; }
        public double ChildNum   { get; set; }
    }

}
