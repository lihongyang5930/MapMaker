using MindOne.Core.Extensions;
using MindOne.Core.Services;

using Syncfusion.Windows.Forms.Tools;

namespace MMaker.Core.Helper
{
    public class RibbonManager
    {
        public RibbonControlAdv RibbonControl { get; private set; }

        public RibbonManager(RibbonControlAdv ribbonControl)
        {
            RibbonControl = ribbonControl;
            Appearances.MainRibbon(ribbonControl);
        }

        public void InitializeMenu()
        {
            RibbonControl.AutoSize = true;
            RibbonControl.CaptionMinHeight = 15;

            foreach (ToolStripTabItem tab in this.RibbonControl.Header.MainItems)
            {
                if (tab.Name == "rbFile")
                {
                    var group = tab.AddGroup("프로젝트 관리");
                    var tool = group.AddButton(name: "mnuCloseProject", text: "새프로젝트", image: MMaker.Core.Properties.Resources.icon_new_map);
                    tool = group.AddButton(name: "mnuLoadProject", text: "프로젝트 열기", image: MMaker.Core.Properties.Resources.img_folder_open32);
                    tool = group.AddButton(name: "mnuSaveProject", text: "프로젝트 저장", image: MMaker.Core.Properties.Resources.icon_save);
                    tool = group.AddButton(name: "mnuSaveProjectAs", text: "다른이름으로 저장", image: MMaker.Core.Properties.Resources.icon_save_as);
                    group = tab.AddGroup("레이어 관리");
                    tool = group.AddButton(name: "mnuAddVector", text: "레이어 불러오기", image: MMaker.Core.Properties.Resources.icon_layer_add);
                    group = tab.AddGroup("시스템 종료");
                    tool = group.AddButton(name: "mnuCloseApp", text: "종료", image: MMaker.Core.Properties.Resources.icon_quit);
                }
                else if (tab.Name == "rbGenerator")
                {
                    var group = tab.AddGroup("분석도구");
                    var tool = group.AddButton(name: "mnuGrid", text: "GRID 생성", image: MMaker.Core.Properties.Resources._32_그리드생성);
                    tool = group.AddButton(name: "mnuInValidate", text: "검증/보정", image: MMaker.Core.Properties.Resources._32_관망도편집);
                    tool = group.AddButton(name: "mnuUsageFlow", text: "사용량 등록", image: MMaker.Core.Properties.Resources._32_계량기사용량검색);
                    tool = group.AddButton(name: "mnuMakeInp", text: "수리모델 생성", image: MMaker.Core.Properties.Resources._32_INP생성);
                    tool = group.AddButton(name: "mnuAttribute", text: "속성정보", image: MMaker.Core.Properties.Resources._32_테이블);
                }
                else if (tab.Name == "rbMap")
                {
                    var group = tab.AddGroup("편집도구");
                    var tool = group.AddButton(name: "mnuEditStart", text: "편집시작", image: MMaker.Core.Properties.Resources.icon_pan1);
                    tool = group.AddButton(name: "mnuEditCancel", text: "편집취소", image: MMaker.Core.Properties.Resources.icon_pan1);
                    tool = group.AddButton(name: "mnuEditSave", text: "편집저장", image: MMaker.Core.Properties.Resources.icon_pan1);

                    group = tab.AddGroup("지도제어");
                    tool = group.AddButton(name: "mnuZoomIn", text: "확대", image: MMaker.Core.Properties.Resources.icon_zoom_in);
                    tool = group.AddButton(name: "mnuZoomOut", text: "축소", image: MMaker.Core.Properties.Resources.icon_zoom_out);
                    tool = group.AddButton(name: "mnuZoomMax", text: "전체보기", image: MMaker.Core.Properties.Resources.icon_zoom_max_extents);
                    tool = group.AddButton(name: "mnuZoomToLayer", text: "레이어로 확대", image: MMaker.Core.Properties.Resources.icon_zoom_to_layer);
                    tool = group.AddButton(name: "mnuPan", text: "이동", image: MMaker.Core.Properties.Resources.icon_pan1);

                    //group = tab.AddGroup("지도도구");
                    //var panel = group.AddPanel();
                    //    tool = panel.AddRadioButton(name: "mnuas1", text: "생활1");
                    //    tool = panel.AddRadioButton(name: "mnuas2", text: "생활2");
                    //    tool = panel.AddRadioButton(name: "mnuas3", text: "생활3");
                }
                else if (tab.Name == "rbTool")
                {
                    var group = tab.AddGroup("도구");
                    var tool = group.AddButton(name: "mnuEpanet", text: "EPANET 실행", image: MMaker.Core.Properties.Resources._32_EPANET2);
                    tool = group.AddButton(name: "mnuMergeInp", text: "수리모델 병합", image: MMaker.Core.Properties.Resources._32_INP병합);
                    tool = group.AddButton(name: "mnuSaveDpf", text: "Dr.Pipe저장", image: MMaker.Core.Properties.Resources._32_닥터파이프저장);

                    tool = group.AddButton(name: "mnuTestdbf", text: "test", image: MMaker.Core.Properties.Resources._32_닥터파이프저장);
                }
            }
        }
    }
}