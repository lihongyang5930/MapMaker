using DotSpatial.Controls;
using MindOne.Core.Services;
using MMaker.Core;
using MMaker.Core.Helper;
using MMaker.Diagnosis.Controllers;
using MMaker.Geographics.Controls;
using Syncfusion.Windows.Forms.Tools;
using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMaker
{
    public partial class MmakerShell : RibbonForm, IShell
    {
        // [20200330] fdragons
        [Export("Shell", typeof(ContainerControl))]
        private static ContainerControl Shell;

        string _appTitle;
        string _projectName;

        DiagnosisController _controller;

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

        public DockManager      DockManager { get; set; }
        public RibbonManager    RibbonManager { get; set; }
        public AppEnvironment   AppEnvironment { get; set; }
        public ViewService      Views { get; set; }
        public DialogService    Dialog { get; set; }
        public Form             MainForm => this;
        public AppManager       AppManager { get; set; }

        //[20200330] fdragons : comment out fallowing two lines for using DotSpatial components
        public MapView          MapView { get; set; }
        public LegendView       LegendView { get; set; }

        public MmakerShell(AppEnvironment environment, DialogService dialog, ViewService views)
        {
            //[20200319]fdragons - for Trace
            ConsoleTraceListener consoleTracer = new ConsoleTraceListener();
            Trace.Listeners.Add(consoleTracer);

            InitializeComponent();

            AppTitle = "K-water MapMaker v2.0.1";

            Dialog          = dialog;
            Views           = views;
            AppEnvironment  = environment;
            AppManager      = appManager;

            DockManager     = new DockManager(dockingManager, this);
            RibbonManager   = new RibbonManager(ribbonControlAdv1);

            Load += async (s, e) => await Initialize();

            if (DesignMode) return;
            Shell = this;

            //[20200330]fdragons - DotSpatial LoadExtension call
            AppManager.LoadExtensions();
        }

        public async Task Initialize()
        {
            this._controller = new DiagnosisController(this);
            await _controller.Initialize();

        }
        public IDisposable PleaseWait()
        {
            return PleaseWait("잠시만 기다려 주세요...");
        }

        public IDisposable PleaseWait(string message)
        {
            var childForm = new MindOne.Core.Views.WaitForm(message)
            {
                StartPosition = FormStartPosition.Manual
            };

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

        public void RefreshUI()
        {
            RefreshTitle();
        }

        /// <summary>
        /// [20200320]fdragons
        /// 프로그램 종료 처리
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            DialogResult ret = MessageBox.Show("시스템을"
                + "\n종료하시겠습니까 ?"
                , AppTitle, 
                MessageBoxButtons.YesNo);

            if(ret != DialogResult.Yes)
                e.Cancel = true;

            base.OnFormClosing(e);
        }
    }
}
