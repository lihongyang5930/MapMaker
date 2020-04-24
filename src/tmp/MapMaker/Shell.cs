using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapMaker.Core;
using MapMaker.Core.Controllers;
using MapMaker.Core.Helper;
using MapMaker.Diagnosis.Controllers;
using MindOne.Core.Services;
using Syncfusion.Windows.Forms.Tools;

namespace MapMaker
{
    public partial class Shell : RibbonForm, IShell
    {
        string _appTitle;
        string _projectName;
        DiagnosisController _controller;

        public Shell(AppEnvironment environment, DialogService dialog, ViewService views)
        {
            InitializeComponent();
            AppTitle = "K-water MapMaker v2.0";

            Dialog = dialog;
            Views = views;
            appEnvironment = environment;
            DockManager = new DockManager(dockingManager, this);
            RibbonManager = new RibbonManager(ribbonControlAdv1);
            Appearances.MainRibbon(ribbonControlAdv1);
            Load += async (s, e) => await Initialize();
        }

        public string AppTitle
        {
            get => _appTitle;
            set
            {
                _appTitle = value;
                RefreshTitle();
            }
        }
        public string ProjectName
        {
            get => _projectName;
            set
            {
                _projectName = value;
                RefreshTitle();
            }
        }

        public DockManager DockManager { get; set; }
        public RibbonManager RibbonManager { get; set; }
        public AppEnvironment appEnvironment { get; set; }
        public DialogService Dialog { get; set; }
        public ViewService Views { get; set; }

        public async Task Initialize()
        {
            this.RibbonManager.InitializeMenu();

            _controller = new DiagnosisController() { Shell = this };
            await _controller.Initialize();
        }


        public IDisposable PleaseWait()
        {
            return PleaseWait("잠시만 기다려 주세요...");
        }
        public IDisposable PleaseWait(string message)
        {
            var childForm = new MindOne.Core.Views.WaitForm(message);
            childForm.StartPosition = FormStartPosition.Manual;
            childForm.Left = (Left + Width / 2) - (childForm.Width / 2);
            childForm.Top = (Top + Height / 2) - (childForm.Height / 2);

            var locationChangedHandler = new EventHandler((s, e) =>
            {
                childForm.Left = (Left + Width / 2) - (childForm.Width / 2);
                childForm.Top = (Top + Height / 2) - (childForm.Height / 2);
            });
            childForm.LocationChanged += locationChangedHandler;
            childForm.Show();
            childForm.BringToFront();

            var onClosed = new System.Action(() =>
            {
                childForm.LocationChanged -= locationChangedHandler;
                childForm.Close();
            });
            return new MindOne.Core.Services.Disposer(onClosed);

        }

        public void Invoke(System.Action action)
        {
            Invoke((MethodInvoker)(() =>
            {
                action.Invoke();
            }));
        }

        private void RefreshTitle()
        {
            if (string.IsNullOrWhiteSpace(ProjectName))
            {
                Text = AppTitle;
            }
            else
            {
                Text = $"{AppTitle}-{ProjectName}";
            }
        }
    }
}
