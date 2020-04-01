using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotSpatial.Controls;
using MindOne.Core.Models;
using MindOne.Core.Services;

using MMaker.Core.Helper;

using Syncfusion.Windows.Forms.Tools;

namespace MMaker.Core.Controllers
{
    public abstract class ControllerBase
    {
        private const string _dockingItemDefaultTitle = "MapMaker v2.0";

        public IShell MmakerShell { get; set; }
        public ViewService Views { get => MmakerShell?.Views; }
        public DialogService Dialog { get => MmakerShell?.Dialog; }
        public DockManager DockManager { get => MmakerShell?.DockManager; }
        public RibbonManager RibbonManager { get => MmakerShell?.RibbonManager; }
        public AppEnvironment AppEnvironment { get => MmakerShell?.AppEnvironment; }
        public AppManager AppManager { get => MmakerShell?.AppManager; }

        public abstract Task Initialize();

        public void SetComboBoxDataSource<TValue>(ComboBoxAdv comboBox, IEnumerable<NameValueItem<TValue>> dataSource)
        {
            comboBox.DisplayMember = nameof(NameValueItem<TValue>.Name);
            comboBox.ValueMember = nameof(NameValueItem<TValue>.Value);
            comboBox.DataSource = dataSource;
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
            var type = typeof(Encoding);
            var field = type.GetField("defaultEncoding",
                                BindingFlags.NonPublic | BindingFlags.Static);
            field.SetValue(null, encoding);
        }
    }
}