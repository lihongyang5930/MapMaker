using System.Windows.Forms;
using DrPipe.Core.Extensions;
using Syncfusion.Windows.Forms.Tools;

namespace DrPipe.Core.Services
{
    public class RibbonManager
    {
        public RibbonManager(RibbonControlAdv ribbonControl)
        {
            RibbonControl = ribbonControl;
            InitializeRibbonControl();
        }

        public RibbonControlAdv RibbonControl { get; private set; }
        
        /// <summary>
        /// 프로젝트
        /// </summary>
        public ToolStripButton OpenProjectButton { get; private set; }

        /// <summary>
        /// 보기
        /// </summary>
        public ToolStripButton   OpenPiepNetworkButton { get; private set; }
        public ToolStripCheckBox LayersCheckBox { get; private set; }
        public ToolStripCheckBox BrowserCheckBox { get; private set; }
        public ToolStripCheckBox ReportCheckBox { get; private set; }


        // 수요패턴
        public ToolStripButton OpenPatternButton { get; private set; }
        public ToolStripButton OpenResidualChlorineButton { get; private set; }

        public ToolStripButton BlocksDivButton { get; private set; }
        public ToolStripButton AreaDivButton   { get; private set; }
        public ToolStripButton ZonesDivButton { get; private set; }
        public ToolStripComboBoxEx ZonesComboBox { get; private set; }

        public ToolStripButton OpenQuantityButton { get; private set; }
        public ToolStripButton OpenPressureButton { get; private set; }
        public ToolStripButton OpenVelocityButton { get; private set; }

        public ToolStripMenuItem OpenBasePurificationPlant { get; private set; }
        public ToolStripMenuItem OpenBasePipe { get; private set; }


        public ToolStripMenuItem OpenGeneralDataInput       { get; private set; }
        public ToolStripMenuItem OpenGeneralInfringement { get; private set; }
        public ToolStripMenuItem OpenGeneralSafe            { get; private set; }
        public ToolStripMenuItem OpenGeneralVolatility  { get; private set; }

        public ToolStripMenuItem Open관벽반응계수 { get; private set; }

        public ToolStripMenuItem OpenIndirectScore			 { get; private set; }
        public ToolStripMenuItem OpenIndirectPhysical		 { get; private set; }
        public ToolStripMenuItem OpenIndirectProfitAndLoss  { get; private set; }

        public ToolStripMenuItem OpenDirectSelected          { get; private set; }
        public ToolStripMenuItem OpenDirectSiteDataInput    { get; private set; }
        public ToolStripMenuItem OpenDirectPrecision        { get; private set; }

        public ToolStripButton OpenZoneImprovement    { get; private set; }
        public ToolStripButton OpenSectionImprovement { get; private set; }

        public ToolStripButton OpenDataBaseButton { get; private set; }

        public ToolStripButton OpenLeakageButton      { get; private set; }
        public ToolStripButton OpenLeakageCoeffButton { get; private set; }
        public ToolStripButton SetLeakagePeriodButton { get; private set; }
        public ToolStripButton ExecuteLeakageButton { get; private set; }

        public ToolStripButton RunSimulationButton { get; private set; }
        public ToolStripButton RunEpanetWButton { get; private set; }

        public void InitializeRibbonControl()
        {
            RibbonControl.AutoSize = true;
            RibbonControl.CaptionMinHeight = 15;
            RibbonControl.MenuButtonVisible = false;

            var rc = RibbonControl;

            var rcTab1                                  = rc.AddTab("Project");

            var     rcTab1Grp1                          = rcTab1.AddGroup("파일");
            var     NewProjectButton                    = rcTab1Grp1.AddButton("새 작업"  , @"Resources\images\app\32_새작업.png");
                    OpenProjectButton                   = rcTab1Grp1.AddButton("열기"     , @"Resources\images\app\32_열기.png");
            var     SaveProjectBtuuon                   = rcTab1Grp1.AddButton("저장"     , @"Resources\images\app\32_저장.png");

            var     rcTab1Grp2                          = rcTab1.AddGroup("보기");
            var     rcTab1Grp2Pan1                      = rcTab1Grp2.AddPanel();
                    LayersCheckBox                      = rcTab1Grp2Pan1.AddCheckBox("레이어");
                    BrowserCheckBox                     = rcTab1Grp2Pan1.AddCheckBox("탐색");
                    ReportCheckBox                      = rcTab1Grp2Pan1.AddCheckBox("리포트");
                    OpenPiepNetworkButton               = rcTab1Grp2.AddButton("관망지도", @"Resources\images\app\32_관망해석.png");
                    OpenDataBaseButton                  = rcTab1Grp2.AddButton("진단DB", @"Resources\images\app\32_DB진단.png");
                    RunEpanetWButton                    = rcTab1Grp2.AddButton("EPANET2", @"Resources\images\app\32_EPANET2.png");

            var     rcTab1Grp3                          = rcTab1.AddGroup("구역분할");
                    BlocksDivButton                     = rcTab1Grp3.AddButton("블록분할", @"Resources\images\app\32_구역분할.png");
                    AreaDivButton                       = rcTab1Grp3.AddButton("진단구역 분할", @"Resources\images\app\32_그리드생성.png");
                    ZonesDivButton                      = rcTab1Grp3.AddButton("진단구간 분할", @"Resources\images\app\32_INP병합.png");
            var     rcTab1Grp3Pan1                      = rcTab1Grp3.AddPanel();
            var     rcTab1Grp3Pan1Lb1                   = rcTab1Grp3Pan1.AddLabel("진단구역", 0, 0, 0, 0);
                    ZonesComboBox                       = rcTab1Grp3Pan1.AddComboBox();
                    ZonesComboBox.DropDownStyle         = ComboBoxStyle.DropDownList;

            var rcTab2                                  = rc.AddTab("Analysis");
            var     rcTab2Grp1                          = rcTab2.AddGroup("수리분석");
                    OpenLeakageButton                   = rcTab2Grp1.AddButton("누수량\r\n분석", @"Resources\images\app\32_계량기사용량검색.png");
            var     rcTab2Grp1Pan1                      = rcTab2Grp1.AddPanel();
            //var     rcTab2Grp1Pan11                     = rcTab2Grp1Pan1.AddPanel();
            var     rcTab2Grp3Pan11Lb1                  = rcTab2Grp1Pan1.AddLabel("분석기간", 0, 0, 0, 0);
                    SetLeakagePeriodButton              = rcTab2Grp1Pan1.AddButton("");
            var     OpenLeakageCoeffButton2             = rcTab2Grp1Pan1.AddButton("파열누수 이력 정보");
            var     rcTab2Grp1Pan2                      = rcTab2Grp1.AddPanel();
                    OpenLeakageCoeffButton              = rcTab2Grp1Pan2.AddButton("계수설정");
            var     OpenLeakageCoeffButton3             = rcTab2Grp1Pan2.AddButton("사용량+유입유량 입력");
                    ExecuteLeakageButton                = rcTab2Grp1.AddButton("누수량\r\n분석 실행", @"Resources\images\app\32_누수실행1.png");

                    rcTab2Grp1.AddSeparator();
                    OpenPatternButton                   = rcTab2Grp1.AddButton("수요패턴", @"Resources\images\app\32_수요패턴요구.png");
                    OpenResidualChlorineButton          = rcTab2Grp1.AddButton("조도계수", @"Resources\images\app\32_환경부고시안평가.png");

            var     rcTab2Grp2                          = rcTab2.AddGroup("수질분석");
            var     잔류염소감쇠능tButton               = rcTab2Grp2.AddButton("잔류염소\r\n감쇠능", @"Resources\images\app\32_광역상수레이어코드표.png");

            var     rcTab2Grp3                          = rcTab2.AddGroup("밸브생성옵션");
            var     rcTab2Grp3Pan1                      = rcTab2Grp3.AddPanel();
            var     rdoValve1                           = rcTab2Grp3Pan1.AddRadioButton("밸브 없음");
            var     rdoValve2                           = rcTab2Grp3Pan1.AddRadioButton("밸브 생성");
            var     rdoValve3                           = rcTab2Grp3Pan1.AddRadioButton("밸브위치 절점생성");
            var     rcTab2Grp4                          = rcTab2.AddGroup("INP생성옵션");
            var     rcTab2Grp4Pan1                      = rcTab2Grp4.AddPanel();
            var     rcTab2Grp4Pan1Lb1                   = rcTab2Grp4Pan1.AddLabel("사용량일자", 0, 0, 0, 0);
            var     cboDemandDates                      = rcTab2Grp4Pan1.AddComboBox();
            var     chkIncludeSupplyPipe                = rcTab2Grp4Pan1.AddCheckBox("급수관로 포함");
                    RunSimulationButton                 = rcTab2Grp4.AddButton("실행", @"Resources\images\app\32_실행.png");
            var     rcTab2Grp5                          = rcTab2.AddGroup("EPANET");



            var rcTab3                                  = rc.AddTab("Dianosis");
            var     rcTab3Grp1                              = rcTab3.AddGroup("수리진단");
                    OpenQuantityButton                      = rcTab3Grp1.AddButton("수량진단", @"Resources\images\app\32_수리분석.png");
                    OpenPressureButton                      = rcTab3Grp1.AddButton("수압진단", @"Resources\images\app\32_수질진단.png");
                    OpenVelocityButton                      = rcTab3Grp1.AddButton("유속진단", @"Resources\images\app\32_수리진단.png");

            var     rcTab3Grp2                              = rcTab3.AddGroup("수질진단");
            var     openQualityBaseButton                   = rcTab3Grp2.AddDropDownButton("기초진단", @"Resources\images\app\32_자료조인.png");
                    OpenBasePurificationPlant               = openQualityBaseButton.AddDropDownItem("정수장");
                    OpenBasePipe                            = openQualityBaseButton.AddDropDownItem("관로");

            var     btn1                                    = rcTab3Grp2.AddDropDownButton("일반진단", @"Resources\images\app\32_필드매핑코드표.png");
                    OpenGeneralDataInput                    = btn1.AddDropDownItem("조사자료 입력");
                    OpenGeneralInfringement                 = btn1.AddDropDownItem("수질기준위반 평가");
                    OpenGeneralSafe                         = btn1.AddDropDownItem("수질안전성 평가");
                    OpenGeneralVolatility                   = btn1.AddDropDownItem("수질변동성 평가");

            var     btn2                                    = rcTab3Grp2.AddDropDownButton("수질예측", @"Resources\images\app\32_시설진단.png");
                    Open관벽반응계수                        = btn2.AddDropDownItem("관벽반응계수 보정");


            var     rcTab3Grp3                              = rcTab3.AddGroup("시설진단");
            var     openIndirectButton                      = rcTab3Grp3.AddDropDownButton("관 상태\r\n간접평가", @"Resources\images\app\32_광역상수레이어코드표.png");
                    OpenIndirectScore                       = openIndirectButton.AddDropDownItem("점수 평가법");
                    OpenIndirectPhysical                    = openIndirectButton.AddDropDownItem("물리적 모델");
                    OpenIndirectProfitAndLoss               = openIndirectButton.AddDropDownItem("손익분기분석");

            var     openDirectButton                        = rcTab3Grp3.AddDropDownButton("관 상태\r\n직접평가", @"Resources\images\app\32_지역상수레이어코드표.png");
                    OpenDirectSelected                      = openDirectButton.AddDropDownItem("대상관로 선정");
                    OpenDirectSiteDataInput                 = openDirectButton.AddDropDownItem("현장조사자료 입력");
                    OpenDirectPrecision                     = openDirectButton.AddDropDownItem("정밀진단");

            var     rcTab3Grp4                              = rcTab3.AddGroup("종합의사결정");
                    OpenZoneImprovement                     = rcTab3Grp4.AddButton("면적(구역)\r\n개량 우선순위", @"Resources\images\app\32_면적우선개량순위.png");
                    OpenSectionImprovement                  = rcTab3Grp4.AddButton("선적(구간)\r\n개량 우선순위", @"Resources\images\app\32_선적우선개량순위.png");




            //var rb                               = RibbonControl;
            //var   rbTab1                         = rb.AddTab("관망해석");
            //var       rbTab1Grp1                 = rbTab1.AddGroup("프로젝트");
            //var           rbBtnNewProject        = rbTab1Grp1.AddButton("새 작업", @"Resources\images\app\32_새작업.png");
            //              OpenProjectButton      = rbTab1Grp1.AddButton("열기"   , @"Resources\images\app\32_열기.png");
            //var           rbBtnSaveProject       = rbTab1Grp1.AddButton("저장"   , @"Resources\images\app\32_저장.png");
            //var       rbTab1Grp2                 = rbTab1.AddGroup("도구");
            //var           rbTab1Grp2Pan1         = rbTab1Grp2.AddPanel();
            //                  LayersCheckBox     = rbTab1Grp2Pan1.AddCheckBox("레이어");
            //                  BrowserCheckBox    = rbTab1Grp2Pan1.AddCheckBox("탐색"  );
            //                  ReportCheckBox     = rbTab1Grp2Pan1.AddCheckBox("리포트");
            //                     rbTab1Grp2.AddSeparator();
            //                     OpenPatternButton = rbTab1Grp2.AddButton("수요패턴"             , @"Resources\images\app\32_수요패턴요구.png");
            //                     OpenResidualChlorineButton = rbTab1Grp2.AddButton("조도계수",  @"Resources\images\app\32_환경부고시안평가.png");

            //var       rbTab1Grp7                 = rbTab1.AddGroup("진단구역");
            //BlocksDivButton = rbTab1Grp7.AddButton("블록분할"     , @"Resources\images\app\32_구역분할.png");
            //AreaDivButton   = rbTab1Grp7.AddButton("진단구역 분할",  @"Resources\images\app\32_그리드생성.png");
            //ZonesDivButton  = rbTab1Grp7.AddButton("진단구간 분할",  @"Resources\images\app\32_INP병합.png");
            //var           rbTab1Grp7Pan1         = rbTab1Grp7.AddPanel();
            //var           rbTab1Grp7Pan1Lb1      = rbTab1Grp7Pan1.AddLabel("진단구역", 0, 0, 0, 0);
            //              ZonesComboBox          = rbTab1Grp7Pan1.AddComboBox();
            //ZonesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            //var       rbTab1Grp6                 = rbTab1.AddGroup("누수량분석");
            //              OpenLeakageButton      = rbTab1Grp6.AddButton("누수량분석",  @"Resources\images\app\32_계량기사용량검색.png");
            //              OpenLeakageCoeffButton = rbTab1Grp6.AddButton("계수설정",  @"Resources\images\app\32_광역상수레이어코드표.png");
            //              ExecuteLeakageButton   = rbTab1Grp6.AddButton("분석실행", @"Resources\images\app\32_누수실행1.png");
            //var           rbTab1Grp6Pan1         = rbTab1Grp6.AddPanel();
            //var               rbTab1Grp6Pan11    = rbTab1Grp6Pan1.AddPanel();
            //var               rbTab1Grp6Pan11Lb1 = rbTab1Grp6Pan11.AddLabel("분석기간", 0, 0, 0, 0);
            //                  SetLeakagePeriodButton = rbTab1Grp6Pan11.AddButton("");

            //var       rbTab1Grp3                 = rbTab1.AddGroup("밸브생성옵션");
            //var           rbTab1Grp3Pan1         = rbTab1Grp3.AddPanel();
            //var               rdoValve1          = rbTab1Grp3Pan1.AddRadioButton("밸브 없음");
            //var               rdoValve2          = rbTab1Grp3Pan1.AddRadioButton("밸브 생성");
            //var               rdoValve3          = rbTab1Grp3Pan1.AddRadioButton("밸브위치 절점생성");
            //var       rbTab1Grp4                 = rbTab1.AddGroup("INP생성옵션");
            //var           rbTab1Grp4Pan1         = rbTab1Grp4.AddPanel();
            //var           rbTab1Grp4Pan1Lb1      = rbTab1Grp4Pan1.AddLabel("사용량일자", 0, 0, 0, 0);
            //var           cboDemandDates         = rbTab1Grp4Pan1.AddComboBox();
            //var           chkIncludeSupplyPipe   = rbTab1Grp4Pan1.AddCheckBox("급수관로 포함");
            //var       rbTab1Grp5                 = rbTab1.AddGroup("EPANET");
            //              RunSimulationButton    = rbTab1Grp5.AddButton("실행"   ,  @"Resources\images\app\32_실행.png");
            //              RunEpanetWButton       = rbTab1Grp5.AddButton("EPANET2",  @"Resources\images\app\32_EPANET2.png");


            //var   rbTab2                         = rb.AddTab("진단 및 평가");
            //var        rbTab2Grp1                = rbTab2.AddGroup("수리진단");
            //                 OpenQuantityButton = rbTab2Grp1.AddButton("수량진단", @"Resources\images\app\32_수리분석.png");
            //                 OpenPressureButton = rbTab2Grp1.AddButton("수압진단", @"Resources\images\app\32_수질진단.png");
            //                 OpenVelocityButton = rbTab2Grp1.AddButton("유속진단", @"Resources\images\app\32_수리진단.png");

            //var        rbTab2Grp2                = rbTab2.AddGroup("수질진단");
            //var  openQualityBaseButton  = rbTab2Grp2.AddDropDownButton("기초진단", @"Resources\images\app\32_자료조인.png");
            //  OpenBasePurificationPlant = openQualityBaseButton.AddDropDownItem("정수장");
            //  OpenBasePipe              = openQualityBaseButton.AddDropDownItem("관로");

            //var  btn1  = rbTab2Grp2.AddDropDownButton("일반진단", @"Resources\images\app\32_필드매핑코드표.png");
            //    OpenGeneralDataInput    = btn1.AddDropDownItem("조사자료 입력");
            //    OpenGeneralInfringement = btn1.AddDropDownItem("수질기준위반 평가");
            //    OpenGeneralSafe         = btn1.AddDropDownItem("수질안전성 평가");
            //    OpenGeneralVolatility   = btn1.AddDropDownItem("수질변동성 평가");

            //var  btn2  = rbTab2Grp2.AddDropDownButton("수질예측", @"Resources\images\app\32_시설진단.png");
            //    Open관벽반응계수 = btn2.AddDropDownItem("관벽반응계수 보정");


            //var        rbTab2Grp3                = rbTab2.AddGroup("시설진단");
            //var         openIndirectButton = rbTab2Grp3.AddDropDownButton("관 상태\r\n간접평가", @"Resources\images\app\32_광역상수레이어코드표.png");
            //        OpenIndirectScore           = openIndirectButton.AddDropDownItem("점수 평가법");
            //        OpenIndirectPhysical        = openIndirectButton.AddDropDownItem("물리적 모델");
            //        OpenIndirectProfitAndLoss   = openIndirectButton.AddDropDownItem("손익분기분석");

            //var         openDirectButton = rbTab2Grp3.AddDropDownButton("관 상태\r\n직접평가", @"Resources\images\app\32_지역상수레이어코드표.png");
            //        OpenDirectSelected      = openDirectButton.AddDropDownItem("대상관로 선정");
            //        OpenDirectSiteDataInput = openDirectButton.AddDropDownItem("현장조사자료 입력");
            //        OpenDirectPrecision     = openDirectButton.AddDropDownItem("정밀진단");


            //var        rbTab2Grp4                = rbTab2.AddGroup("종합의사결정");
            //             OpenZoneImprovement    = rbTab2Grp4.AddButton("면적(구역)\r\n개량 우선순위" , @"Resources\images\app\32_면적우선개량순위.png");
            //             OpenSectionImprovement = rbTab2Grp4.AddButton("선적(구간)\r\n개량 우선순위", @"Resources\images\app\32_선적우선개량순위.png");

            //var rbTab2Grp5 = rbTab2.AddGroup("");
            //              OpenDataBase = rbTab2Grp5.AddButton("진단DB", @"Resources\images\app\32_DB진단.png");

            // 테스트 김주성 추가
            //var        rbTab1Grp998                 = rbTab2.AddGroup("관 상태 간접평가");
            //var            rbBtnOpenIndirectScore   = rbTab1Grp998.AddButton("점수평가법", @"Resources\images\app\시설진단.png");
            //var            rbTab1Grp998Pan1         = rbTab1Grp998.AddPanel();
            //var                 rbTab1Grp998Pan1Lb1 = rbTab1Grp998Pan1.AddLabel("분석기준년도", 0, 0, 0, 0);
            //var                 cboYear             = rbTab1Grp998Pan1.AddComboBox();
            //var            rbTab1Grp998Pan2 = rbTab1Grp998.AddPanel();
            //var                 버튼1               = rbTab1Grp998Pan2.AddButton("구간분할 버튼");
            //var                 버튼2               = rbTab1Grp998Pan2.AddButton("평가실행 버튼");


            LayersCheckBox              .Enabled = false;
            BrowserCheckBox             .Enabled = false;
            ReportCheckBox              .Enabled = false;
            OpenProjectButton           .Enabled = false;
            //OpenPatternButton           .Enabled = false;
            OpenResidualChlorineButton  .Enabled = false;
            BlocksDivButton             .Enabled = false;
            AreaDivButton               .Enabled = false;
            ZonesComboBox               .Enabled = false;
            ZonesDivButton              .Enabled = false;
            OpenQuantityButton          .Enabled = false;
            OpenPressureButton          .Enabled = false;
            OpenVelocityButton          .Enabled = false;
            OpenLeakageButton           .Enabled = false;
            OpenLeakageCoeffButton      .Enabled = false;
            SetLeakagePeriodButton      .Enabled = false;
            ExecuteLeakageButton        .Enabled = false;
            RunSimulationButton         .Enabled = false;
            RunEpanetWButton            .Enabled = false;
        }
    }
}
