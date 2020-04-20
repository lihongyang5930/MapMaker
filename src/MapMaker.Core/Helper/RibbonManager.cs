using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using MindOne.Core.Extensions;
using MindOne.Core.Services;
using Syncfusion.Windows.Forms.Tools;
using System;
using System.Diagnostics;
using MapMaker.Core.Enums;

namespace MapMaker.Core.Helper
{
    public class RibbonManager
    {
        public RibbonManager(RibbonControlAdv ribbonControl)
        {
            RibbonControl = ribbonControl;
            //InitializeMenu();
        }

        public RibbonControlAdv RibbonControl { get; private set; }


        public void InitializeMenu()
        {
            RibbonControl.AutoSize = true;
            RibbonControl.CaptionMinHeight = 15;

            foreach (ToolStripTabItem tab in this.RibbonControl.Header.MainItems)
            {
                if (tab.Name == "rbFile")
                {
                    var group = tab.AddGroup("프로젝트 관리");
                    var tool = group.AddButton(name: "mnuCloseProject", text: "새프로젝트"      , image: Properties.Resources.icon_new_map);
                        tool = group.AddButton(name: "mnuLoadProject",  text: "프로젝트 열기"   , image: Properties.Resources.img_folder_open32);
                        tool = group.AddButton(name: "mnuSaveProject",  text: "프로젝트 저장"   , image: Properties.Resources.icon_save);
                        tool = group.AddButton(name: "mnuSaveProjectAs",text: "다른이름으로 저장" , image: Properties.Resources.icon_save_as);
                    group = tab.AddGroup("레이어 관리");
                        tool = group.AddButton(name: "mnuAddVector",    text: "레이어 불러오기", image: Properties.Resources.icon_layer_add);
                    group = tab.AddGroup("시스템 종료");
                        tool = group.AddButton(name: "mnuCloseApp",     text: "종료", image: Properties.Resources.icon_quit);
                }
                else if (tab.Name == "rbGenerator")
                {
                    var group = tab.AddGroup("분석도구");
                    var tool = group.AddButton(name: "mnuGrid",       text: "GRID 생성", image: Properties.Resources._32_그리드생성);
                        tool = group.AddButton(name: "mnuInValidate", text: "검증/보정", image: Properties.Resources._32_관망도편집);
                        tool = group.AddButton(name: "mnuUsageFlow",  text: "사용량 등록", image: Properties.Resources._32_계량기사용량검색);
                        tool = group.AddButton(name: "mnuMakeInp",    text: "수리모델 생성", image: Properties.Resources._32_INP생성);
                        tool = group.AddButton(name: "mnuAttribute",  text: "속성정보", image: Properties.Resources._32_테이블);
                }
                else if (tab.Name == "rbMap")
                {
                    var group = tab.AddGroup("지도제어");
                    var tool = group.AddButton(name: "mnuZoomIn",      text: "확대", image: Properties.Resources.icon_zoom_in);
                        tool = group.AddButton(name: "mnuZoomOut",     text: "축소", image: Properties.Resources.icon_zoom_out);
                        tool = group.AddButton(name: "mnuZoomMax",     text: "전체보기", image: Properties.Resources.icon_zoom_max_extents);
                        tool = group.AddButton(name: "mnuZoomToLayer", text: "레이어로 확대", image: Properties.Resources.icon_zoom_to_layer);
                        tool = group.AddButton(name: "mnuPan",         text: "이동", image: Properties.Resources.icon_pan1);

                    group = tab.AddGroup("지도도구");
                }
                else if (tab.Name == "rbTool")
                {
                    var group = tab.AddGroup("도구");
                    var tool = group.AddButton(name: "mnuEpanet",   text: "EPANET 실행", image: Properties.Resources._32_EPANET2);
                        tool = group.AddButton(name: "mnuMergeInp", text: "수리모델 병합", image: Properties.Resources._32_INP병합);
                        tool = group.AddButton(name: "mnuSaveDpf",  text: "Dr.Pipe저장", image: Properties.Resources._32_닥터파이프저장);
                }
            }
        }


    }




}
