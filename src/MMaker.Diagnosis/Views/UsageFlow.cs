using Syncfusion.WinForms.DataGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMaker.Diagnosis.Views
{
    public partial class UsageFlow : MMaker.Core.Views.BaseForm
    {
        public UsageFlow()
        {
            InitializeComponent();

            sfDataGrid1.Columns.Add(new GridTextColumn() { HeaderText = "수용가명", MappingName = "a" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { HeaderText = "수용가번호", MappingName = "a" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { HeaderText = "수용가주소", MappingName = "a" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { HeaderText = "업종", MappingName = "a" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { HeaderText = "구경", MappingName = "a" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { HeaderText = "가구수", MappingName = "a" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { HeaderText = "사용량", MappingName = "a" });
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

        }
    }
}
