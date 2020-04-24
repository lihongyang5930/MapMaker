using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrPipe.Core.Controllers;
using DrPipe.Core.Models;
using DrPipe.Diagnosis.Controls;
using DrPipe.Diagnosis.Models;
using DrPipe.Diagnosis.Views.Local.Analysis.Hydraulics;
using DrPipe.Diagnosis.Views.Local.Analysis.PipeNetwork;
using DrPipe.Diagnosis.Views.Local.Analysis.WaterQuality;
using DrPipe.Diagnosis.Views.Local.Analysis.ZoneDivision;
using DrPipe.Diagnosis.Views.Local.Diagnosis.Facility;
using MindOne.DrPipe.Dpf;
using MindOne.DrPipe.Dpf.Models;
using MindOne.Epanet;
using MindOne.Epanet.Models;
using MindOne.Geographics.Layers;
using Syncfusion.Windows.Forms.Chart;
using Syncfusion.Windows.Forms.Tools;

namespace DrPipe.Diagnosis.Controllers
{
    public class DiagnosisController : ControllerBase
    {
        // 시연용 샘플 파일
        //string _sampleDpfFileName;
        //string _sampleInpFileName;

        BackgroundLayerSet _backgroundLayerSet;
        MonthRange         _leakagePeriod;
        string             _selectedZone;

        PipeNetworkView    _pipeNetworkView;
        EpanetService      _epanetService;
        LayersControl      _layersView;
        BrowserView        _browserView;
        ReportView         _reportView;
        Dictionary<NodeProperty, EpanetLegend> _nodeLegends;
        Dictionary<LinkProperty, EpanetLegend> _linkLegends;

        LeakageView              _leakageView;
        CoefficientSetupView     _coeffView;
        PatternView              _patternView;
        BlockInfoView            _blockInfoView;
        ResidualChlorineView     _residualChlorineView;
        RoughnessCoefficientView _roughnessCoefficientView;

        IndirectScoreView _indirectScoreView;


        bool _isTimeStepPlayForward;
        CancellationTokenSource _timeStepPlayCancellationTokenSource;
        string[] _quantityBrowserIndices;
        string[] _pipeTypes;
        PipeGroup[] _pipeGroups;

        public DiagnosisController()
        {
        }

        public bool IsLayersVisible
        {
            get => DockManager.GetDockVisible(Views.GetView<LayersControl>());
            set
            {
                if (IsLayersVisible != value)
                {
                    RibbonManager.LayersCheckBox.Checked = value;
                    DockManager  .SetDockVisible(Views.GetView<LayersControl>(), value);
                }
            }
        }
        public bool IsBrowserVisible
        {
            get => DockManager.GetDockVisible(Views.GetView<BrowserView>());
            set
            {
                if (IsBrowserVisible != value)
                {
                    RibbonManager.BrowserCheckBox.Checked = value;
                    DockManager.SetDockVisible(Views.GetView<BrowserView>(), value);
                }
            }
        }
        public bool IsReportVisible
        {
            get => DockManager.GetDockVisible(Views.GetView<ReportView>());
            set
            {
                if (IsReportVisible != value)
                {
                    RibbonManager.ReportCheckBox.Checked = value;
                    DockManager.SetDockVisible(Views.GetView<ReportView>(), value);
                }
            }
        }

        public bool IsBlockInfoVisible
        {
            get => DockManager.GetDockVisible(Views.GetView<BlockInfoView>());
            set
            {
                DockManager.SetDockVisible(Views.GetView<BlockInfoView>(), value);
            }
        }

        public bool IsSimulated { get; private set; }
        public TimeSpan CurrentTimeStep { get; private set; }

        public MonthRange LeakagePeriod
        {
            get => _leakagePeriod;
            set
            {
                _leakagePeriod = value;
                RibbonManager.SetLeakagePeriodButton.Text = value?.ToString() ?? "        ";
            }
        }
        public string SelectedZone
        {
            get => _selectedZone;
            set
            {
                if (_selectedZone != value)
                {
                    _selectedZone = value;
                    RibbonManager.ZonesComboBox.ComboBox.SelectedItem = value;
                }
            }
        }

        public override async Task Initialize()
        {
            //_sampleDpfFileName = Path.Combine(DrPipeEnvironment.ProcessDirName, @"samples\sample.dpf");
            //_sampleInpFileName = Path.Combine(DrPipeEnvironment.ProcessDirName, @"samples\sample.inp");
            Test(Path.Combine(DrPipeEnvironment.ProcessDirName, @"samples\sample.dpf"));

            var backgroundLayerFactory    = new BackgroundLayerFactory();
            //var vworldApiKey          = "04F7E2CE-E526-39CD-9AE1-A55239A5D4D5"; // vworld.kr, id: mindone, pw: E-matrix!23
            //var backgroundLayerSet  = await backgroundLayerFactory.GetVWorld(vworldApiKey);
            //var backgroundLayerSet  = await backgroundLayerFactory.GetKWater();
            _backgroundLayerSet  = await backgroundLayerFactory.GetKakaoMap();

            InitializeViews();
            InitializeLegends();

            RibbonManager.LayersCheckBox .CheckedChanged += (s, e) => IsLayersVisible = ((ToolStripCheckBox)s).Checked;
            RibbonManager.BrowserCheckBox.CheckedChanged += (s, e) => IsBrowserVisible = ((ToolStripCheckBox)s).Checked;
            RibbonManager.ReportCheckBox .CheckedChanged += (s, e) => IsReportVisible = ((ToolStripCheckBox)s).Checked;

            RibbonManager.ZonesComboBox  .SelectedIndexChanged += (s, e) => {
                var cmb = (ToolStripComboBoxEx)s;
                SelectedZone = cmb.ComboBox.SelectedItem?.ToString();
            };

            RibbonManager.OpenProjectButton         .Click += async (s, e) => await OpenDpf();

            RibbonManager.OpenPiepNetworkButton.Click += (s, e) => {
                Shell.DockManager.ShowDocument(_pipeNetworkView, "관망해석", true);
            };

            RibbonManager.OpenPatternButton         .Click += (s, e) => OpenPattern();
            RibbonManager.OpenResidualChlorineButton.Click += (s, e) => OpenResidualChlorine();
            RibbonManager.OpenLeakageButton         .Click += (s, e) => OpenLeakage();
            RibbonManager.ExecuteLeakageButton      .Click += (s, e) => {
                // 시연용 코드
                // 누수량 배분된 dpf파일 읽기
                if (_leakageView.TestExecuted)
                    return;

                var defaultEncoding = Encoding.Default;
                var utf8Encoding    = Encoding.UTF8;
                SetDefaultEncoding(utf8Encoding);
                var dpfService = new DpfService();
                dpfService.GbakPath    = DrPipeEnvironment.FirebirdGbakFileName;
                dpfService.ClientPath  = DrPipeEnvironment.FirebirdClientFileName;

                var dpfPath = Path.Combine(DrPipeEnvironment.ProcessDirName, @"samples\sample.l_dpf");
                var fdbPath = Path.Combine(DrPipeEnvironment.TempDirectory, Path.GetFileName(dpfPath) + ".fdb");
                if (!File.Exists(fdbPath))
                {
                    dpfService.GbakCreate(dpfPath, fdbPath);
                }
                var connectionString = dpfService.GetConnectionString(fdbPath);
                var db    = new DpfContext(connectionString);
                var pipes = db.DBM_PIPE.Where(x => x.PP_CLASS == "상수관로").ToArray();
                SetDefaultEncoding(defaultEncoding);
                _leakageView.Execute(pipes);
                db.Dispose();
            };

            RibbonManager.RunSimulationButton       .Click += (s, e) => Run();
            RibbonManager.RunEpanetWButton          .Click += (s, e) => StartEpanetWProcess();

            RibbonManager.ZonesDivButton.Click += (s, e) => {
                var view = Views.GetView<ZoneDivView>();
                Views.ShowDialog(view, "진단구간 분할");
            };
            RibbonManager.OpenQuantityButton.Click += (s, e) => {
                var view = Views.GetView<QuantityView>();
                DockManager.ShowDocument(view, "수량변동");
            };
            RibbonManager.OpenPressureButton.Click += (s, e) => {
                var view = Views.GetView<PressureView>();
                DockManager.ShowDocument(view, "수압변동");
            };
            RibbonManager.OpenVelocityButton.Click += (s, e) => {
                var view = Views.GetView<VelocityView>();
                DockManager.ShowDocument(view, "유속변동");
            };
            RibbonManager.OpenLeakageCoeffButton.Click += (s, e) => OpenCoefficientSetup();
            RibbonManager.SetLeakagePeriodButton.Click += (s, e) => {
                var period = Views.SelectMonth();
                if (period != null)
                {
                    LeakagePeriod = period;
                }
            };

            RibbonManager.OpenBasePurificationPlant.Click += (s, e) => {
                var doc  = Views.GetView<BasePurificationPlantView>();
                var side = Views.GetView<WeightView>();
                IsLayersVisible = false;
                DockManager.ShowDocument(doc, "기초진단-정수장");
                DockManager.InitializeDockLeft(side, "가중치", 300);
                DockManager.SetDockVisible(side, true);
            };

            _epanetService            = new EpanetService();
            _pipeNetworkView          = new PipeNetworkView(_backgroundLayerSet);
            _layersView               = Shell.Views.GetView<LayersControl>();
            _browserView              = Shell.Views.GetView<BrowserView>();
            _reportView               = Shell.Views.GetView<ReportView>();
            _leakageView              = Shell.Views.GetView<LeakageView>();
            _roughnessCoefficientView = Shell.Views.GetView<RoughnessCoefficientView>();
            _coeffView                = Shell.Views.GetView<CoefficientSetupView>();
            _patternView              = Shell.Views.GetView<PatternView>();
            _blockInfoView            = Shell.Views.GetView<BlockInfoView>();
            _indirectScoreView        = Shell.Views.GetView<IndirectScoreView>();

            _coeffView.Coeff1  =  9.6d;
            _coeffView.Coeff2  =  0.6d;
            _coeffView.Coeff3  = 16.0d;
            _coeffView.Coeff4  =  4.0d;

            _browserView.cmbTimeSteps       .Enabled = false;
            _browserView.cmbNodeValues      .Enabled = false;
            _browserView.cmbLinkValues      .Enabled = false;
            _browserView.btnFirstTimeStep   .Enabled = false;
            _browserView.btnBackTimeStep    .Enabled = false;
            _browserView.btnStopTimeStep    .Enabled = false;
            _browserView.btnForwardTimeStep .Enabled = false;
            _browserView.pressurePanel      .Enabled = false;
            _browserView.quantityPanel      .Enabled = false;
            _browserView.velocityPanel      .Enabled = false;

            _browserView.cmbTimeSteps .SelectedIndexChanged += OnCmbTimeStepsSelectedIndexChanged;
            _browserView.cmbNodeValues.SelectedIndexChanged += OnCmbNodeValuesSelectedIndexChanged;
            _browserView.cmbLinkValues.SelectedIndexChanged += OnCmbLinkValuesSelectedIndexChanged;
            _browserView.btnFirstTimeStep  .Click += OnBtnFirstTimeStepClick;
            _browserView.btnBackTimeStep   .Click += OnBtnBackTimeStepClick;
            _browserView.btnStopTimeStep   .Click += OnBtnStopTimeStepClick;
            _browserView.btnForwardTimeStep.Click += OnBtnForwardTimeStepClick;
            _browserView.btnRefresh        .Click += OnBrowserBtnRefreshClick;
            _browserView.quantityPanel.Visible = false;
            _browserView.pressurePanel.Visible = false;
            _browserView.velocityPanel.Visible = false;
            _browserView.chartControl .Visible = false;

            _browserView.txtPressure1.Value = 1.53m;
            _browserView.txtPressure2.Value = 4.03m;
            _browserView.txtVelocity .Value = 0.10m;
            _browserView.txtPressure1.ValueChanged += (s, e) => Browse();
            _browserView.txtPressure2.ValueChanged += (s, e) => Browse();
            _browserView.txtVelocity .ValueChanged += (s, e) => Browse();

            _reportView.SetText(string.Empty);
            _layersView.SelectedBackgroundLayerChanged += OnSelectedBackgroundLayerChanged;

            var nodeValues = new List<NameValueItem<NodeProperty?>>();
            nodeValues.Add(new NameValueItem<NodeProperty?>("No View"        , null));
            nodeValues.Add(new NameValueItem<NodeProperty?>("Elevation"      , NodeProperty.EN_ELEVATION));
            nodeValues.Add(new NameValueItem<NodeProperty?>("Base Demand"    , NodeProperty.EN_BASEDEMAND));
            nodeValues.Add(new NameValueItem<NodeProperty?>("Initial Quality", NodeProperty.EN_INITQUAL));
            nodeValues.Add(new NameValueItem<NodeProperty?>("Demand"         , NodeProperty.EN_DEMAND));
            nodeValues.Add(new NameValueItem<NodeProperty?>("Head"           , NodeProperty.EN_HEAD));
            nodeValues.Add(new NameValueItem<NodeProperty?>("Pressure"       , NodeProperty.EN_PRESSURE));
            nodeValues.Add(new NameValueItem<NodeProperty?>("Quality"        , NodeProperty.EN_QUALITY));
            SetComboBoxDataSource(_browserView.cmbNodeValues, nodeValues);

            var linkValues = new List<NameValueItem<LinkProperty?>>();
            linkValues.Add(new NameValueItem<LinkProperty?>("No View"        , null));
            linkValues.Add(new NameValueItem<LinkProperty?>("Length"         , LinkProperty.EN_LENGTH));
            linkValues.Add(new NameValueItem<LinkProperty?>("Diameter"       , LinkProperty.EN_DIAMETER));
            linkValues.Add(new NameValueItem<LinkProperty?>("Roughness"      , LinkProperty.EN_ROUGHNESS));
            linkValues.Add(new NameValueItem<LinkProperty?>("Bulk Coeff."    , LinkProperty.EN_KBULK));
            linkValues.Add(new NameValueItem<LinkProperty?>("Wall Coeff."    , LinkProperty.EN_KWALL));
            linkValues.Add(new NameValueItem<LinkProperty?>("Flow"           , LinkProperty.EN_FLOW));
            linkValues.Add(new NameValueItem<LinkProperty?>("Velocity"       , LinkProperty.EN_VELOCITY));
            linkValues.Add(new NameValueItem<LinkProperty?>("Unit Headloss"  , LinkProperty.EN_HEADLOSS));
            //linkValues.Add("Friction Factor");
            //linkValues.Add("Reaction Rate"  );
            //linkValues.Add("Quality"        );
            SetComboBoxDataSource(_browserView.cmbLinkValues, linkValues);

            _quantityBrowserIndices = new[] {
                "급수전밀도",
                "유수율",
                "무수율(≒누수율)",
                "급수전당무수수량(≒누수량)",
            };
            SetComboBoxDataSource(_browserView.cmbIndices, _quantityBrowserIndices);
            _browserView.cmbIndices.SelectedIndexChanged += OnCmbQuantityIndicesSelectedIndexChanged;

            _patternView.SetPatternCategories(new [] { "절점 수요량 패턴", "배수지 수위패턴" });
            _patternView.btnExport.Click += OnPatternBtnExportClick;
            _patternView.btnImport.Click += OnPatternBtnImportClick;
            _patternView.btnSave  .Click += OnPatternBtnSaveClick;

            DockManager.DockControlActivated += OnDockControlActivated;

            LeakagePeriod = new MonthRange ()
            {
                Year1  = DateTime.Today.Year,
                Month1 = DateTime.Today.Month,
                Year2  = DateTime.Today.Year,
                Month2 = DateTime.Today.Month,
            };

            _roughnessCoefficientView.btnExcelImport.Click += (s, e) => {
                Shell.Dialog.OpenXlsx();
            };
            _roughnessCoefficientView.btnExport.Click += (s, e) => {
                Shell.Dialog.SaveInpFile("epanet_inp_file.inp");
            };
            _roughnessCoefficientView.btnGisImport.Click += (s, e) => {
                Shell.Dialog.OpenInpFile();
            };
            _roughnessCoefficientView.btnSave.Click += (s, e) => { };
            RibbonManager.OpenProjectButton.Enabled = true;
        }

        private void InitializeViews()
        {
            var layersView    = Shell.Views.GetView<LayersControl>();
            var browserView   = Shell.Views.GetView<BrowserView>();
            var reportView    = Shell.Views.GetView<ReportView>();
            var blockInfoView = Shell.Views.GetView<BlockInfoView>();

            layersView.SetBackgroundLayers(_backgroundLayerSet);

            Shell.DockManager.InitializeDockLeft  (layersView   , "레이어"      );
            Shell.DockManager.InitializeDockRight (browserView  , "탐색"        );
            Shell.DockManager.InitializeDockBottom(reportView   , "리포트"      );
            Shell.DockManager.InitializeDockLeft  (blockInfoView, "진단구역정보");

            RibbonManager.OpenBasePipe.Click += (s, e) => {
                var view = Views.GetView<Views.Local.Diagnosis.WaterQuality.BasePipeView>();
                Views.ShowDialog(view, "관로");
            };
            RibbonManager.OpenGeneralDataInput.Click += (s, e) => {
                var view = Views.GetView<Views.Local.Diagnosis.WaterQuality.GeneralDataInputView>();
                Views.ShowDialog(view, "조사자료 입력");
            };
            RibbonManager.OpenGeneralInfringement.Click += (s, e) => {
                var view = Views.GetView<Views.Local.Diagnosis.WaterQuality.GeneralInfringementView>();
                Views.ShowDialog(view, "수질기준위반 평가");
            };
            RibbonManager.OpenGeneralSafe.Click += (s, e) => {
                var view = Views.GetView<Views.Local.Diagnosis.WaterQuality.GeneralSafeView>();
                Views.ShowDialog(view, "수질안전성 평가");
            };
            RibbonManager.OpenGeneralVolatility.Click += (s, e) => {
                var view = Views.GetView<Views.Local.Diagnosis.WaterQuality.GeneralVolatilityView>();
                Views.ShowDialog(view, "수질변동성 평가");
            };

            RibbonManager.OpenIndirectScore.Click += (s, e) => {
                var view = Views.GetView<IndirectScoreView>();
                Views.ShowDialog(view, "점수 평가법");
            };
            RibbonManager.OpenIndirectPhysical.Click += (s, e) => {
                var view = Views.GetView<DirectSiteDataInputView>();
                Views.ShowDialog(view, "물리적 모델");
            };
            RibbonManager.OpenIndirectProfitAndLoss.Click += (s, e) => {
                var view = Views.GetView<IndirectProfitAndLossView>();
                Views.ShowDialog(view, "손익분기분석");
            };
            RibbonManager.OpenDirectSelected.Click += (s, e) => {
                var view = Views.GetView<DirectSelectedView>();
                Views.ShowDialog(view, "대상관로 선정");
            };
            RibbonManager.OpenDirectSiteDataInput.Click += (s, e) => {
                MessageBox.Show("대상관로를 선정하십시오.");
            };
            RibbonManager.OpenDirectPrecision.Click += (s, e) => {
                MessageBox.Show("대상관로를 선정하십시오.");
            };


            RibbonManager.OpenZoneImprovement.Click += (s, e) => {
                var view = Views.GetView<Views.Local.Diagnosis.GeneralDecisionMaking.ZoneImprovementView>();
                Views.ShowDialog(view, "면적(구역) 개량 우선순위");
            };
            RibbonManager.OpenSectionImprovement.Click += (s, e) => {
                var view = Views.GetView<Views.Local.Diagnosis.GeneralDecisionMaking.SectionImprovementView>();
                Views.ShowDialog(view, "선적(구간) 개량 우선순위");
            };
            RibbonManager.OpenDataBaseButton.Click += (s, e) => {
                var view = Views.GetView<Views.Common.DataBaseView>();
                Views.ShowDialog(view, "진단DB");
            };
        }

        #region EventHandlers
        private void OnDockControlActivated(object sender, DockActivationChangedEventArgs e)
        {
            if (e.Control is PipeNetworkView)
            {

            }
            if (e.Control is LeakageView)
            {

            }
            if (e.Control is QuantityView)
            {
                RibbonManager.BrowserCheckBox.Checked = true;
                _browserView.cmbNodeValues.SelectedIndex = 0;
                _browserView.cmbLinkValues.SelectedIndex = 6;
                _browserView.quantityPanel.Visible = true;
                _browserView.pressurePanel.Visible = false;
                _browserView.velocityPanel.Visible = false;
                _browserView.chartControl .Visible = true;
                Browse();
            }
            if (e.Control is PressureView)
            {
                RibbonManager.BrowserCheckBox.Checked = true;
                _browserView.cmbNodeValues.SelectedIndex = 6;
                _browserView.cmbLinkValues.SelectedIndex = 0;
                _browserView.quantityPanel.Visible = false;
                _browserView.pressurePanel.Visible = true;
                _browserView.velocityPanel.Visible = false;
                _browserView.chartControl .Visible = true;
                Browse();
            }
            if (e.Control is VelocityView)
            {
                RibbonManager.BrowserCheckBox.Checked = true;
                _browserView.cmbNodeValues.SelectedIndex = 0;
                _browserView.cmbLinkValues.SelectedIndex = 7;
                _browserView.quantityPanel.Visible = false;
                _browserView.pressurePanel.Visible = false;
                _browserView.velocityPanel.Visible = true;
                _browserView.chartControl .Visible = true;
                Browse();
            }
        }
        private void OnCmbNodeValuesSelectedIndexChanged(object sender, EventArgs e)
        {
            var cmb      = (ComboBoxAdv)sender;
            var item     = cmb.SelectedItem as NameValueItem<NodeProperty?>;
            var value    = item?.Value;
            var legend   = GetLegend(value);
            var selector = GetSelector(value);
            _pipeNetworkView.SetNodeLegend(legend, selector);
            Browse();
        }
        private void OnCmbLinkValuesSelectedIndexChanged(object sender, EventArgs e)
        {
            var cmb      = (ComboBoxAdv)sender;
            var item     = cmb.SelectedItem as NameValueItem<LinkProperty?>;
            var value    = item?.Value;
            var legend   = GetLegend(value);
            var selector = GetSelector(value);
            _pipeNetworkView.SetLinkLegend(legend, selector);
            Browse();
        }
        private void OnBrowserBtnRefreshClick(object sender, EventArgs e)
        {
            Browse();
        }
        private void OnCmbTimeStepsSelectedIndexChanged(object sender, EventArgs e)
        {
            var cmb      = (ComboBoxAdv)sender;
            var item     = cmb.SelectedItem as TimeSpanNameValueItem;
            var timeStep = item.Value;
            CurrentTimeStep = timeStep;

            _pipeNetworkView.SetTimeStep(CurrentTimeStep);
            Browse();
        }
        private void OnCmbQuantityIndicesSelectedIndexChanged(object sender, EventArgs e)
        {
            Browse();
        }
        private void OnBtnFirstTimeStepClick(object sender, EventArgs e)
        {
            _browserView.cmbTimeSteps.SelectedIndex = 0;
        }
        private async void OnBtnBackTimeStepClick(object sender, EventArgs e)
        {
            _isTimeStepPlayForward = false;
            await PlayTimeSteps();
        }
        private void OnBtnStopTimeStepClick(object sender, EventArgs e)
        {
            _timeStepPlayCancellationTokenSource.Cancel();
        }
        private async void OnBtnForwardTimeStepClick(object sender, EventArgs e)
        {
            _isTimeStepPlayForward = true;
            await PlayTimeSteps();
        }
        private void OnSelectedBackgroundLayerChanged(object sender, EventArgs e)
        {
            var view = sender as LayersControl;
            if (view != null)
            {
                if (_backgroundLayerSet.SelectedItem != null)
                {
                    var color = _backgroundLayerSet.SelectedItem.IsDark
                                    ? System.Drawing.Color.Snow
                                    : System.Drawing.Color.Black;
                    _pipeNetworkView.SetDefaultColor(color);
                }
                _pipeNetworkView.Refresh();
            }
        }
        private void OnPatternBtnImportClick(object sender, EventArgs e)
        {
            Dialog.OpenPattern();
        }
        private void OnPatternBtnExportClick(object sender, EventArgs e)
        {
            Dialog.SavePattern("pattern1.pat");
        }
        private void OnPatternBtnSaveClick(object sender, EventArgs e)
        {
        }
        #endregion

        public async Task OpenDpf()
        {
            var dpfPath = Shell.Dialog.OpenDrPipeProject();
            if (dpfPath != null)
                await OpenDpf(dpfPath);
        }
        public async Task OpenDpf(string dpfPath)
        {
            using (Shell.PleaseWait())
            {
                // 시연용 - dpf파일을 열었을 때 INP 파일도 같이 열리도록 함.
                var inpPath = Path.ChangeExtension(dpfPath, "inp");
                OpenInp(inpPath);

                // --------------------------
                await OpenFirebirdDatabase(dpfPath);
                InitializeLeakageDataSource();
                InitializeQuantityDataSource();
                InitializePressureDataSource();
                InitializeVelocityDataSource();

                Shell.DockManager.ShowDocument(_pipeNetworkView, "관망해석", false);

                IsLayersVisible = true;
                //IsBlockInfoVisible = true;
                Shell.ProjectName  = Path.GetFileName(dpfPath);

                RibbonManager.LayersCheckBox              .Enabled = true;
                RibbonManager.BrowserCheckBox             .Enabled = true;
                RibbonManager.ReportCheckBox              .Enabled = true;
                RibbonManager.OpenPatternButton           .Enabled = true;
                RibbonManager.OpenResidualChlorineButton  .Enabled = true;
                RibbonManager.BlocksDivButton             .Enabled = true;
                RibbonManager.AreaDivButton               .Enabled = true;
                RibbonManager.ZonesComboBox               .Enabled = true;
                RibbonManager.ZonesDivButton              .Enabled = true;
                RibbonManager.ZonesComboBox               .Enabled = true;
                RibbonManager.RunSimulationButton         .Enabled = true;
                RibbonManager.RunEpanetWButton            .Enabled = true;
                RibbonManager.OpenLeakageButton           .Enabled = true;
                RibbonManager.OpenLeakageCoeffButton      .Enabled = true;
                RibbonManager.SetLeakagePeriodButton      .Enabled = true;
                RibbonManager.ExecuteLeakageButton        .Enabled = true;
            }
        }

        #region Test 사용XXXXXXX
        private void Test(string dpfPath)
        {
            return;
            var defaultEncoding = Encoding.Default;
            var utf8Encoding    = Encoding.UTF8;

            SetDefaultEncoding(utf8Encoding);

            var dpfService = new DpfService();
            dpfService.GbakPath    = DrPipeEnvironment.FirebirdGbakFileName;
            dpfService.ClientPath  = DrPipeEnvironment.FirebirdClientFileName;

            var fdbPath = Path.Combine(DrPipeEnvironment.TempDirectory, Path.GetFileName(dpfPath) + ".fdb");
            File.Delete(fdbPath);

            dpfService.GbakCreate(dpfPath, fdbPath);

            var connectionString = dpfService.GetConnectionString(fdbPath);
            var db = new DpfContext(connectionString);

            var CODE_TABLE                 = db.CODE_TABLE.Take(10)                 .ToArray();
            var CVA_LEAKAGE                = db.CVA_LEAKAGE.Take(10)                .ToArray();
            var CVA_PRESS                  = db.CVA_PRESS.Take(10)                  .ToArray();
            var CVA_WQTY                   = db.CVA_WQTY.Take(10)                   .ToArray();
            //var DBINFO                   = db.DBINFO                     .Take(10).ToArray();
            var DBMG_C_PATH                = db.DBMG_C_PATH.Take(10)                .ToArray();
            var DBMG_C_PATH2               = db.DBMG_C_PATH2.Take(10)               .ToArray();
            var DBMG_C_VALUE               = db.DBMG_C_VALUE.Take(10)               .ToArray();
            var DBMG_C_VALUE2              = db.DBMG_C_VALUE2.Take(10)              .ToArray();
            var DBMG_MEASURE               = db.DBMG_MEASURE.Take(10)               .ToArray();
            var DBMG_MEASURE_AS            = db.DBMG_MEASURE_AS.Take(10)            .ToArray();
            var DBMG_MEASURE_PS            = db.DBMG_MEASURE_PS.Take(10)            .ToArray();
            var DBMG_MEASURE_RAWDATA       = db.DBMG_MEASURE_RAWDATA.Take(10)       .ToArray();
            var DBM_BIZ_SITE_AS            = db.DBM_BIZ_SITE_AS.Take(10)            .ToArray();
            var DBM_BLOCKB                 = db.DBM_BLOCKB.Take(10)                 .ToArray();
            var DBM_BLOCKM                 = db.DBM_BLOCKM.Take(10)                 .ToArray();
            var DBM_BLOCKS                 = db.DBM_BLOCKS.Take(10)                 .ToArray();
            var DBM_CVRI                   = db.DBM_CVRI.Take(10)                   .ToArray();
            var DBM_CVRO                   = db.DBM_CVRO.Take(10)                   .ToArray();
            var DBM_CVRU                   = db.DBM_CVRU.Take(10)                   .ToArray();
            var DBM_FIREPLUG               = db.DBM_FIREPLUG.Take(10)               .ToArray();
            var DBM_FLOWGAUGE              = db.DBM_FLOWGAUGE.Take(10)              .ToArray();
            var DBM_FLOWGAUGE_EX           = db.DBM_FLOWGAUGE_EX.Take(10)           .ToArray();
            var DBM_FLOWGAUGE_FLOW_HIST    = db.DBM_FLOWGAUGE_FLOW_HIST.Take(10)    .ToArray();
            var DBM_GROUP_INFO             = db.DBM_GROUP_INFO.Take(10)             .ToArray();
            var DBM_JOINT_TYPE             = db.DBM_JOINT_TYPE.Take(10)             .ToArray();
            var DBM_LAYER_EX               = db.DBM_LAYER_EX.Take(10)               .ToArray();
            var DBM_NODE                   = db.DBM_NODE.Take(10)                   .ToArray();
            var DBM_PIPE                   = db.DBM_PIPE.Take(10)                   .ToArray();
            var DBM_PIPE_EX                = db.DBM_PIPE_EX.Take(10)                .ToArray();
            var DBM_PRESSGAUGE             = db.DBM_PRESSGAUGE.Take(10)             .ToArray();
            var DBM_PRESSGAUGE_EX          = db.DBM_PRESSGAUGE_EX.Take(10)          .ToArray();
            var DBM_PUMP                   = db.DBM_PUMP.Take(10)                   .ToArray();
            var DBM_RESV                   = db.DBM_RESV.Take(10)                   .ToArray();
            var DBM_STATION                = db.DBM_STATION.Take(10)                .ToArray();
            var DBM_VALVE                  = db.DBM_VALVE.Take(10)                  .ToArray();
            var DBM_VALVEROOM              = db.DBM_VALVEROOM.Take(10)              .ToArray();
            var DBM_WATERGAUGE             = db.DBM_WATERGAUGE.Take(10)             .ToArray();
            var DBM_WATERGAUGE_DEMAND_HI   = db.DBM_WATERGAUGE_DEMAND_HIST.Take(10) .ToArray();
            var DBM_ZONE                   = db.DBM_ZONE.Take(10)                   .ToArray();
            var DEFAULT_VALUE              = db.DEFAULT_VALUE.Take(10)              .ToArray();
            var DIAGNOSIS_ITEMS            = db.DIAGNOSIS_ITEMS.Take(10)            .ToArray();
            var DSS_ENVI                   = db.DSS_ENVI.Take(10)                   .ToArray();
            var EPAG_NODE                  = db.EPAG_NODE.Take(10)                  .ToArray();
            var EPA_LINK                   = db.EPA_LINK.Take(10)                   .ToArray();
            var EPA_LINK_GRID              = db.EPA_LINK_GRID.Take(10)              .ToArray();
            var EPA_LINK_TIME_SERIES       = db.EPA_LINK_TIME_SERIES.Take(10)       .ToArray();
            var EPA_NODE                   = db.EPA_NODE.Take(10)                   .ToArray();
            var EPA_NODE_GRID              = db.EPA_NODE_GRID.Take(10)              .ToArray();
            var EPA_NODE_TIME_SERIES       = db.EPA_NODE_TIME_SERIES.Take(10)       .ToArray();
            var JOIN_TABLE                 = db.JOIN_TABLE.Take(10)                 .ToArray();
            var JOIN_TABLE2                = db.JOIN_TABLE2.Take(10)                .ToArray();
            var NET_KPRESSURE              = db.NET_KPRESSURE.Take(10)              .ToArray();
            var NET_QUANTITY               = db.NET_QUANTITY.Take(10)               .ToArray();
            var NET_REVIEW_VALVE           = db.NET_REVIEW_VALVE.Take(10)           .ToArray();
            var NET_REVIEW_VALVE_CV        = db.NET_REVIEW_VALVE_CV.Take(10)        .ToArray();
            var NET_REVIEW_VALVE_FLOWC     = db.NET_REVIEW_VALVE_FLOWC.Take(10)     .ToArray();
            var PCA_DETAIL_DIAGNOSIS       = db.PCA_DETAIL_DIAGNOSIS.Take(10)       .ToArray();
            var PCA_LIFE_SIMUL             = db.PCA_LIFE_SIMUL.Take(10)             .ToArray();
            var PCA_MEDIA                  = db.PCA_MEDIA.Take(10)                  .ToArray();
            var PCA_REFORM                 = db.PCA_REFORM.Take(10)                 .ToArray();
            var STORE_DATA                 = db.STORE_DATA.Take(10)                 .ToArray();
            var WQT_BASE_PIPE              = db.WQT_BASE_PIPE.Take(10)              .ToArray();
            var WQT_BASE_SITE              = db.WQT_BASE_SITE.Take(10)              .ToArray();
            var WQT_GENERAL                = db.WQT_GENERAL.Take(10)                .ToArray();
            var WQT_GENERAL_ITEM           = db.WQT_GENERAL_ITEM.Take(10)           .ToArray();
            var WQT_GENERAL_NODE           = db.WQT_GENERAL_NODE.Take(10)           .ToArray();
            var WQT_WATER_STAND            = db.WQT_WATER_STAND.Take(10)            .ToArray();

            SetDefaultEncoding(defaultEncoding);

            //foreach (var a in WQT_WATER_STAND)
            //{
            //    var s = $"{a.NAME} {a.STAND} {a.UNIT} {a.DESCRIPTION} {a.SAMEWORD}";
            //    MessageBox.Show(s);
            //}
            Console.WriteLine();
        }
        #endregion

        private Task OpenFirebirdDatabase(string dpfPath)
        {
            var defaultEncoding = Encoding.Default;
            var utf8Encoding    = Encoding.UTF8;

            return Task.Factory.StartNew(() => {
                try
                {
                    // Firebird Client에서 한글을 읽기 위해서는
                    // Encoding.Default = UTF8로 맞추어 주어야 함..
                    SetDefaultEncoding(utf8Encoding);

                    var dpfService = new DpfService();
                    dpfService.GbakPath    = DrPipeEnvironment.FirebirdGbakFileName;
                    dpfService.ClientPath  = DrPipeEnvironment.FirebirdClientFileName;

                    var fdbPath = Path.Combine(DrPipeEnvironment.TempDirectory, Path.GetFileName(dpfPath) + ".fdb");
                    File.Delete(fdbPath);

                    dpfService.GbakCreate(dpfPath, fdbPath);

                    var connectionString = dpfService.GetConnectionString(fdbPath);
                    var db = new DpfContext(connectionString);
                    //var nodes            = db.DBM_NODE.Distinct().ToArray();
                    var zones           = db.DBM_ZONE.ToArray();
                    var storeData       = db.STORE_DATA.ToArray();

                    _pipeTypes = new [] {
                        "DCIP",
                        "DIP",
                        "GRP",
                        "PE",
                        "SP",
                    };

                    var patterns = storeData
                                        .Where  (x => x.MODULENAME == "수요패턴분석")
                                        .Select (ToPattern)
                                        .ToArray();


                    var zoneNameList = zones.Select(x => x.NAME).ToList();
                    zoneNameList.Insert(0, "전체");
                    SetComboBoxDataSource(RibbonManager.ZonesComboBox.ComboBox, zoneNameList);

                    var pipes = db.DBM_PIPE.Where(x => x.PP_CLASS == "상수관로").ToArray();

                    OpenPipeGroups(pipes.ToArray());

                    var waterStands    = db.WQT_WATER_STAND.ToArray();
                    var waterBaseSites = db.WQT_BASE_SITE.ToArray();

                    var demands2 = db.DBM_WATERGAUGE.ToArray();
                    var demands  = db.DBM_WATERGAUGE_DEMAND_HIST.ToArray();

                    Shell.Invoke(() => {
                        var patternView   = Views.GetView<PatternView>();
                        var roughnessView = Views.GetView<RoughnessCoefficientView>();
                        patternView.SetPatterns(patterns);
                        roughnessView.SetDataSource(pipes);
                        InitializePurificationPlantDataSource(waterStands, waterBaseSites);
                    });

                    //수요패턴분석
                    // ETC1: 절점 수요량 패턴
                    // ETC1: 배수지 수위패턴
                    //foreach (var pat in patterns)
                    //{
                    //    var ppp     = new Models.Pattern { Category = pat.ETC1, Name = pat.NAME };
                    //    var strData = Encoding.UTF8.GetString(pat.DATA);
                    //    var parts   = strData.Split(new [] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    //    var values  = parts.Select(x => Convert.ToDouble(x)).ToArray();
                    //    //"0.83\r\n0.85\r\n0.84\r\n0.72\r\n0.68\r\n0.75\r\n0.97\r\n1.06\r\n0.94\r\n1.04\r\n1.13\r\n1.10\r\n1.15\r\n1.23\r\n1.04\r\n0.96\r\n0.93\r\n0.98\r\n0.99\r\n1.05\r\n1.31\r\n1.40\r\n1.06\r\n0.98\r\n"
                    //}

                    //foreach (var d in storeData)
                    //{
                    //    if (d.DATA != null)
                    //    {
                    //        var s = defaultEncoding.GetString(d.DATA);
                    //    }
                    //}
                }
                catch
                {
                    SetDefaultEncoding(defaultEncoding);
                    throw;
                }
                finally
                {
                    SetDefaultEncoding(defaultEncoding);
                }
            });
        }

        private void OpenPipeGroups(IEnumerable<DBM_PIPE> waterPipes)
        {
            _pipeGroups = waterPipes.GroupByZone().ToArray();
        }
        private void InitializeLeakageDataSource()
        {
            var view = Views.GetView<LeakageView>();
            view.SetPipeTypeDataSource(_pipeTypes);
            view.SetDataSource(_pipeGroups);
        }
        private void InitializeQuantityDataSource()
        {
            var details = new [] {
                new DataGridModel {
                    Col01 = "소블록3"   ,
                    Col02 = 13298.8     ,
                    Col03 = 803         ,
                    Col04 = 0.00        ,
                    Col05 = 99000       ,
                    Col06 = 90496       ,
                    Col07 = 0.060       ,
                    Col08 = 91.410      ,
                    Col09 = 8.590       ,
                    Col10 = 5.353       ,
                    Col11 = 21.32       ,
                },
                new DataGridModel {
                    Col01 = "소블록4"   ,
                    Col02 = 13091.3     ,
                    Col03 = 567         ,
                    Col04 = 0.00        ,
                    Col05 = 88000       ,
                    Col06 = 76691       ,
                    Col07 = 0.043       ,
                    Col08 = 95.864      ,
                    Col09 = 4.136       ,
                    Col10 = 0.195       ,
                    Col11 = 8.43        ,
                },
            };
            var master = new [] {
                new DataGridModel { Col01 = "2019-08", Col02 = 179000, Col03 = 167187, Col04 = 2.5, Details = details },
            };

            var view = Views.GetView<QuantityView>();
            view.SetDataSource(master);
        }
        private void InitializePressureDataSource()
        {
            var view = Views.GetView<PressureView>();
            view.SetPipeTypeDataSource(_pipeTypes);
            view.SetDataSource(_pipeGroups);
        }
        private void InitializeVelocityDataSource()
        {
            var view = Views.GetView<VelocityView>();
            view.SetPipeTypeDataSource(_pipeTypes);
            view.SetDataSource(_pipeGroups);
        }
        private void InitializePurificationPlantDataSource(IEnumerable<WQT_WATER_STAND> masters, IEnumerable<WQT_BASE_SITE> details)
        {
            var view = Views.GetView<BasePurificationPlantView>();
            view.SetDataSource(masters, details);
        }

        #region Epanet
        public void OpenInp()
        {
            var inpPath = Shell.Dialog.OpenInpFile();
            if (inpPath != null)
                OpenInp(inpPath);
        }
        public void OpenInp(string inpPath)
        {
            _epanetService.Clear();
            _epanetService.InpPath = inpPath;
            if (_epanetService.InpPath == null)
                return;
            _epanetService.Open();
            _pipeNetworkView.LoadInp(_epanetService);
            IsSimulated = false;
        }
        public void Run()
        {
            _timeStepPlayCancellationTokenSource?.Cancel();

            var tmp = Path.GetTempFileName();
            _epanetService.Reset();
            _epanetService.ReportFilePath = tmp;
            _epanetService.Run();

            _pipeNetworkView.LoadInp(_epanetService);

            var report = GetReport();
            _reportView.AppendText(report);
            File.Delete(tmp);

            var  timeSteps = _epanetService.Native
                                .TimeSteps
                                .Select(x => new TimeSpanNameValueItem
                                {
                                    Name  = GetHoursString(x),
                                    Value = x
                                })
                                .ToArray();
            SetComboBoxDataSource(_browserView.cmbTimeSteps, timeSteps);
            Browse();

            IsSimulated = true;
            _browserView.cmbTimeSteps       .Enabled = true;
            _browserView.cmbNodeValues      .Enabled = true;
            _browserView.cmbLinkValues      .Enabled = true;
            _browserView.btnFirstTimeStep   .Enabled = true;
            _browserView.btnBackTimeStep    .Enabled = true;
            _browserView.btnStopTimeStep    .Enabled = false;
            _browserView.btnForwardTimeStep. Enabled = true;
            _browserView.pressurePanel      .Enabled = true;
            _browserView.quantityPanel      .Enabled = true;
            _browserView.velocityPanel      .Enabled = true;
            IsReportVisible = true;
            RibbonManager.OpenQuantityButton.Enabled = true;
            RibbonManager.OpenPressureButton.Enabled = true;
            RibbonManager.OpenVelocityButton.Enabled = true;
        }
        public void Browse()
        {
            if (IsSimulated)
            {
                _pipeNetworkView.Browse(_epanetService);
                RefreshHydraulicDiagnosis();
            }
        }
        public string GetReport()
        {
            var path = _epanetService?.ReportFilePath;
            if (string.IsNullOrWhiteSpace(path))
                return string.Empty;
            if (!File.Exists(path))
                return string.Empty;
            return File.ReadAllText(path, Encoding.GetEncoding(949));
        }
        public async Task PlayTimeSteps()
        {
            if (!IsSimulated)
                return;
            if (_timeStepPlayCancellationTokenSource != null)
                return;

            _browserView.cmbTimeSteps      .Enabled = false;
            _browserView.btnForwardTimeStep.Enabled = false;
            _browserView.btnBackTimeStep   .Enabled = false;
            _browserView.btnStopTimeStep   .Enabled = true;

            var source = _browserView.cmbTimeSteps.DataSource as TimeSpanNameValueItem[];
            var length = source.Length;
            var index  = _browserView.cmbTimeSteps.SelectedIndex;

            _timeStepPlayCancellationTokenSource = new CancellationTokenSource();
            while (!_timeStepPlayCancellationTokenSource.IsCancellationRequested)
            {
                if (_browserView.IsDisposed)
                    return;

                _browserView.cmbTimeSteps.SelectedIndex = index;

                if (_isTimeStepPlayForward)
                {
                    index = index + 1;
                    if (index >= length)
                        index = 0;
                }
                else
                {
                    index = index - 1;
                    if (index < 0)
                        index = length - 1;
                }
                await Task.Delay(500);
            }
            _timeStepPlayCancellationTokenSource = null;
            _browserView.cmbTimeSteps      .Enabled = true;
            _browserView.btnForwardTimeStep.Enabled = true;
            _browserView.btnBackTimeStep   .Enabled = true;
            _browserView.btnStopTimeStep   .Enabled = false;
        }
        private void RefreshHydraulicDiagnosis()
        {
            if (_browserView.pressurePanel.Visible)
            {
                var v0 = _browserView.txtPressure1.Value;
                var v1 = _browserView.txtPressure2.Value;
                int i0 = 0;
                int i1 = 0;
                int i2 = 0;
                var chart  = _browserView.chartControl;
                var series = new ChartSeries();
                series.Type = ChartSeriesType.Pie;
                for (int i = 1; i < _epanetService.Native.NodesCount; i++)
                {
                    var node = _epanetService.Native.GetNodeByIndex(i);
                    var p    = (decimal)node.GetValue(CurrentTimeStep).Pressure;

                    // meter => kgf/cm2
                    p = p * 0.099974399331066m;

                    if (p < v0)
                    {
                        Interlocked.Increment(ref i0);
                    }
                    else
                    if (p > v1)
                    {
                        Interlocked.Increment(ref i2);
                    }
                    else
                    {
                        Interlocked.Increment(ref i1);
                    }
                }
                series.Points.Add($"미달", i0);
                series.Points.Add($"적정", i1);
                series.Points.Add($"초과", i2);
                series.Styles[0].Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Tomato);
                series.Styles[1].Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.LightSeaGreen);
                series.Styles[2].Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.CornflowerBlue);
                chart.ShowLegend = false;
                chart.Series.Clear();
                chart.Series.Add(series);
                _browserView.SetLegends(
                    new [] { "미달", "적정", "초과" },
                    new [] { i0, i1, i2 },
                    new [] { System.Drawing.Color.Tomato, System.Drawing.Color.LightSeaGreen, System.Drawing.Color.CornflowerBlue });
            }
            else
            if (_browserView.quantityPanel.Visible)
            {
                var value    = _browserView.cmbIndices.SelectedItem?.ToString();
                var chart    = _browserView.chartControl;
                if (value == null)
                    return;
                var series = new ChartSeries();
                if (value == _quantityBrowserIndices[0]) // 급수전밀도
                {
                    series.Points.Add("소블록3", 0.060);
                    series.Points.Add("소블록4", 0.043);
                }
                if (value == _quantityBrowserIndices[1]) // 유수율
                {
                    series.Points.Add("소블록3", 91.410);
                    series.Points.Add("소블록4", 95.864);
                }
                if (value == _quantityBrowserIndices[2]) // 무수율(≒누수율)
                {
                    series.Points.Add("소블록3", 8.590);
                    series.Points.Add("소블록4", 4.136);
                }
                if (value == _quantityBrowserIndices[3]) // 급수전당무수수량(≒누수량)
                {
                    series.Points.Add("소블록3", 0.353);
                    series.Points.Add("소블록4", 0.195);
                }
                chart.ShowLegend = false;
                chart.Series.Clear();
                chart.Series.Add(series);
                _browserView.DisableLegends();
            }
            else
            if (_browserView.velocityPanel.Visible)
            {
                var v       = _browserView.txtVelocity.Value;
                int i0      = 0;
                int i1      = 0;
                var chart   = _browserView.chartControl;
                var series  = new ChartSeries();
                series.Type = ChartSeriesType.Pie;
                for (int i = 1; i < _epanetService.Native.LinksCount; i++)
                {
                    var node = _epanetService.Native.GetLinkByIndex(i);
                    var p    = (decimal)node.GetValue(CurrentTimeStep).Velocity;
                    if (p < v)
                    {
                        Interlocked.Increment(ref i0);
                    }
                    else
                    {
                        Interlocked.Increment(ref i1);
                    }
                }
                series.Points.Add("미달", i0);
                series.Points.Add("적정", i1);
                series.Styles[0].Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Tomato);
                series.Styles[1].Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.LightSeaGreen);
                chart.ShowLegend = false;
                chart.Series.Clear();
                chart.Series.Add(series);
                _browserView.SetLegends(
                    new [] { "미달", "적정" },
                    new [] { i0, i1 },
                    new [] { System.Drawing.Color.Tomato, System.Drawing.Color.LightSeaGreen });
            }
        }

        private void InitializeLegends()
        {
            _nodeLegends = new Dictionary<NodeProperty, EpanetLegend>();
            _linkLegends = new Dictionary<LinkProperty, EpanetLegend>();

            var colors5 = new [] {
                System.Drawing.Color.Navy,
                System.Drawing.Color.DodgerBlue,
                System.Drawing.Color.ForestGreen,
                System.Drawing.Color.Tomato,
                System.Drawing.Color.Red,
            };

            _nodeLegends.Add(
                NodeProperty.EN_ELEVATION,
                new EpanetLegend(
                    "Elevation",
                    "m",
                    colors5,
                    new[] {
                        25d,
                        50d,
                        75d,
                        100d,
                    }));

            _nodeLegends.Add(
                NodeProperty.EN_BASEDEMAND,
                new EpanetLegend(
                    "Base Demand",
                    "CMD",
                    colors5,
                    new[] {
                        25d,
                        50d,
                        75d,
                        100d,
                    }));
            _nodeLegends.Add(
                NodeProperty.EN_INITQUAL,
                new EpanetLegend(
                    "Initial Quality",
                    "",
                    colors5,
                    new[] {
                        0.25d,
                        0.50d,
                        0.75d,
                        1.00d,
                    }));
            _nodeLegends.Add(
                NodeProperty.EN_DEMAND,
                new EpanetLegend(
                    "Demand",
                    "CMD",
                    colors5,
                    new[] {
                        25d,
                        50d,
                        75d,
                        100d,
                   }));
            _nodeLegends.Add(
                NodeProperty.EN_HEAD,
                new EpanetLegend(
                    "Head",
                    "m",
                    colors5,
                    new[] {
                        25d,
                        50d,
                        75d,
                        100d,
                   }));
            _nodeLegends.Add(
                NodeProperty.EN_PRESSURE,
                new EpanetLegend(
                    "Pressure",
                    "m",
                    colors5,
                    new[] {
                        25d,
                        50d,
                        75d,
                        100d,
                    }));
            _nodeLegends.Add(
                NodeProperty.EN_QUALITY,
                new EpanetLegend(
                    "Quality",
                    "",
                    colors5,
                    new[] {
                        0.25d,
                        0.50d,
                        0.75d,
                        1.00d,
                    }));
            _linkLegends.Add(
                LinkProperty.EN_LENGTH,
            new EpanetLegend(
                    "Length",
                    "m",
                    colors5,
                    new[] {
                         100d,
                         500d,
                        1000d,
                        5000d,
                   }));
            _linkLegends.Add(
                LinkProperty.EN_DIAMETER,
            new EpanetLegend(
                    "Diameter",
                    "mm",
                    colors5,
                    new[] {
                         6d,
                        12d,
                        24d,
                        36d,
                    }));
            _linkLegends.Add(
                LinkProperty.EN_ROUGHNESS,
                 new EpanetLegend(
                    "Roughness",
                    "",
                    colors5,
                    new[] {
                         50d,
                         75d,
                        100d,
                        125d,
                    }));
            _linkLegends.Add(
                LinkProperty.EN_KBULK,
                new EpanetLegend(
                    "Bulk Coeff.",
                    "",
                    colors5,
                    new[] {
                        0.25d,
                        0.50d,
                        0.75d,
                        1.00d,
                    }));
            _linkLegends.Add(
                LinkProperty.EN_KWALL,
                new EpanetLegend(
                    "Wall Coeff.",
                    "",
                    colors5,
                    new[] {
                        0.25d,
                        0.50d,
                        0.75d,
                        1.00d,
                    }));
            _linkLegends.Add(
                LinkProperty.EN_FLOW,
                new EpanetLegend(
                    "Flow",
                    "CMD",
                    colors5,
                    new[] {
                        25d,
                        50d,
                        75d,
                        100d,
                    }));
            _linkLegends.Add(
                LinkProperty.EN_VELOCITY,
                new EpanetLegend(
                    "Velocity",
                    "m/s",
                    colors5,
                    new[] {
                        0.01d,
                        0.10d,
                        1.00d,
                        2.00d,
                    }));
            _linkLegends.Add(
                LinkProperty.EN_HEADLOSS,
                new EpanetLegend(
                    "Unit Headloss",
                    "m/km",
                    colors5,
                    new[] {
                        0.03d,
                        0.05d,
                        0.08d,
                        0.10d,
                    }));
        }
        private EpanetLegend GetLegend(NodeProperty? value)
        {
            if (value != null && _nodeLegends.ContainsKey(value.Value))
                return _nodeLegends[value.Value];
            return null;
        }
        private EpanetLegend GetLegend(LinkProperty? value)
        {
            if (value != null && _linkLegends.ContainsKey(value.Value))
                return _linkLegends[value.Value];
            return null;
        }

        private Func<NodeValue, double> GetSelector(NodeProperty? value)
        {
            if (value.HasValue)
            {
                return x => x[value.Value];
            }
            return null;
        }
        private Func<LinkValue, double> GetSelector(LinkProperty? value)
        {
            if (value.HasValue)
            {
                return x => x[value.Value];
            }
            return null;
        }

        private string GetHoursString(TimeSpan timeSpan)
        {
            return string.Format("{0}:{1:mm} hrs", ((int)timeSpan.TotalHours).ToString("D2"), timeSpan);
        }
        #endregion

        #region EpanetW Process
        public void StartEpanetWProcess()
        {
            var process                 = new Process();
            process.StartInfo           = new ProcessStartInfo();
            process.StartInfo.FileName  = Shell.DrPipeEnvironment.EpanetFileName;
            process.StartInfo.Arguments = _epanetService.InpPath;
            process.EnableRaisingEvents = true;
            process.Exited             += OnEpanetWProcessExited;
            process.ErrorDataReceived  += OnEpanetWProcessErrorDataReceived;
            process.OutputDataReceived += OnEpanetWProcessOutputDataReceived;
            process.Start();
        }
        private void OnEpanetWProcessExited(object sender, EventArgs e)
        {
            var process = (Process)sender;
            var path    = process.StartInfo.Arguments;
            if (_epanetService.InpPath == path)
            {
                var message = "외부 EPANET2 프로세스가 종료되었습니다." + Environment.NewLine
                            + "새로고침 하시겠습니까?";
                var result = Shell.Dialog.ShowMessageBox(message, MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    Shell.Invoke(() => OpenInp(path));
                }
            }
        }
        private void OnEpanetWProcessOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            var process = (Process)sender;
            _reportView.AppendText( "Output " + e.Data);
        }
        private void OnEpanetWProcessErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            var process = (Process)sender;
            _reportView.AppendText( "Error " + e.Data);
        }
        #endregion

        #region 누수량 분석
        public void OpenLeakage()
        {
            var view = Views.GetView<LeakageView>();
            DockManager.ShowDocument(view, "누수량분석");
        }
        public void OpenCoefficientSetup()
        {
            var view   = Views.GetView<CoefficientSetupView>();
            var result = Views.ShowFixedDialog(view, "계수 설정");
            if (result == DialogResult.OK)
            {
                var icf = view.Coeff4;
            }
        }
        #endregion

        #region 수요 패턴
        public void OpenPattern()
        {
            Shell.Views.ShowDialog(_patternView, "수요패턴");
            //Shell.DockManager.ShowDocument(_patternView, "수요패턴");
        }

        private Pattern ToPattern(STORE_DATA storeData)
        {
            var data   = Encoding
                            .UTF8
                            .GetString(storeData.DATA)
                            .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => Convert.ToDouble(x)).ToArray();
            var values = Enumerable
                            .Range(0, data.Length)
                            .Select(i => new PatternValue(i + 1, data[i]))
                            .ToArray();
            return new Pattern
            {
                Category = storeData.ETC1,
                Name    = storeData.NAME,
                Values  = values
            };
        }
        #endregion

        #region 수질 진단
        public void OpenResidualChlorine()
        {
            //Shell.Views.ShowDialog(Shell.Views.GetView<ResidualChlorineView>(), "수질 진단");
            Shell.Views.ShowDialog(Shell.Views.GetView<RoughnessCoefficientView>(), "조도계수");
        }
        #endregion

        #region 시설진단 - 관 상태 간접평가 - 점수평가법
        public void OpenIndirectScore()
        {
            Shell.DockManager.ShowDocument(_indirectScoreView, "점수평가법");
        }
        #endregion
    }
}
