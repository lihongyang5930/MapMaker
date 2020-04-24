using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrPipe.Core.Models;
using DrPipe.Core.Services;
using Syncfusion.Windows.Forms.Tools;

namespace DrPipe.Core.Controllers
{
    public abstract class ControllerBase
    {
        const string _dockingItemDefaultTitle = "Dr.Pipe";

        public IShell Shell { get; set; }
        public ViewService       Views             { get => Shell.Views; }
        public DialogService     Dialog            { get => Shell.Dialog; }
        public DockManager       DockManager       { get => Shell.DockManager; }
        public RibbonManager     RibbonManager     { get => Shell.RibbonManager; }
        public DrPipeEnvironment DrPipeEnvironment { get => Shell.DrPipeEnvironment; }

        public abstract Task Initialize();

        public void SetComboBoxDataSource<TValue>(ComboBoxAdv comboBox, IEnumerable<NameValueItem<TValue>> dataSource)
        {
            comboBox.DisplayMember = nameof(NameValueItem<TValue>.Name);
            comboBox.ValueMember   = nameof(NameValueItem<TValue>.Value);
            comboBox.DataSource    = dataSource;
            if (dataSource != null && dataSource.Any())
            {
                comboBox.SelectedIndex = 0;
            }
        }
        public void SetComboBoxDataSource(ComboBoxAdv comboBox, IEnumerable<object> dataSource)
        {
            comboBox.DataSource = dataSource;
            if (dataSource != null && dataSource.Any())
            {
                comboBox.SelectedIndex = 0;
            }
        }

        public void SetDefaultEncoding(Encoding encoding)
        {
            var type  = typeof(Encoding);
            var field = type.GetField(
                                "defaultEncoding", 
                                BindingFlags.NonPublic 
                                    | BindingFlags.Static);
            field.SetValue(null, encoding);
        }
    }
}
