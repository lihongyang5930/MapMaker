using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrPipe.Core;
using DrPipe.Core.Services;
using DrPipe.Core.Views.Common;
using DrPipe.Diagnosis.Controllers;
using MindOne.Geographics.Layers;
using Syncfusion.Windows.Forms.Tools;

namespace DrPipe
{
    public partial class Shell : RibbonForm, IShell
    {
        string _appTitle;
        string _projectName;
        DiagnosisController _controller;

        public Shell(
            DrPipeEnvironment environment,
            DialogService dialog,
            ViewService views)
        {
            InitializeComponent();
            AppTitle          = "K-Water Dr.Pipe";
            Dialog            = dialog;
            Views             = views;
            DrPipeEnvironment = environment;
            DockManager       = new DockManager(dockingManager, this);
            RibbonManager     = new RibbonManager(ribbonControlAdv1);
            Appearances.MainRibbon(ribbonControlAdv1);
            Load += async (s, e) => await Initialize();
        }

        public ViewService Views { get; set; }
        public DialogService Dialog { get; set; }
        public DockManager DockManager { get; set; }
        public RibbonManager RibbonManager { get; set; }
        public DrPipeEnvironment DrPipeEnvironment { get; set; }

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

        public async Task Initialize()
        {
            _controller = new DiagnosisController();
            _controller.Shell = this;
            await _controller.Initialize();
        }
        
        public IDisposable PleaseWait()
        {
            return PleaseWait("잠시만 기다려 주세요...");
        }
        public IDisposable PleaseWait(string message)
        {
            var childForm = new WaitForm(message);
            childForm.StartPosition = FormStartPosition.Manual;
            childForm.Left   = (Left + Width  / 2) - (childForm.Width  / 2);
            childForm.Top    = (Top  + Height / 2) - (childForm.Height / 2);

            var locationChangedHandler = new EventHandler((s, e) => { 
                childForm.Left   = (Left + Width  / 2) - (childForm.Width  / 2);
                childForm.Top    = (Top  + Height / 2) - (childForm.Height / 2);
            });
            childForm.LocationChanged += locationChangedHandler;
            childForm.Show();
            childForm.BringToFront();

            var onClosed = new System.Action(() => {
                childForm.LocationChanged -= locationChangedHandler;
                childForm.Close();
            });
            return new Disposer(onClosed);
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
