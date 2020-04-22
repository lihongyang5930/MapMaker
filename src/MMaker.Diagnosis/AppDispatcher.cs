using DotSpatial.Controls;
using DotSpatial.Data;
using DotSpatial.Symbology;

using MindOne.Core.Helper;

using MMaker.Core;
using MMaker.Core.Enums;
using MMaker.Diagnosis.Controllers;
using MMaker.Diagnosis.Helper;
using MMaker.Diagnosis.Views;

using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace MMaker.Diagnosis
{
    public class AppDispatcher : CommandDispatcher<AppCommand>
    {
        public IShell MmakerShell
        {
            get; set;
        }

        private Map Map => MmakerShell?.AppManager?.Map as Map;
        private Legend Legend => MmakerShell?.AppManager?.Legend as Legend;

        /// <summary>
        /// 메뉴선택 또는 
        /// </summary>
        /// <param name="command"></param>
        public override void Run(AppCommand command)
        {
            if (HandleCursors(command)) { Trace.WriteLine($"\tHandleCursors({command.ToString()})."); return; }
            else if (HandleGenerator(command)) { Trace.WriteLine($"\tHandleGenerator({command.ToString()})."); return;}
            else if (HandleLayers(command)) { Trace.WriteLine($"\tHandleLayers({command.ToString()})."); return; }
            else if (HandleProject(command)) { Trace.WriteLine($"\tHandleProject({command.ToString()})."); return;}
            else if (HandleContextMenu(command)) { Trace.WriteLine($"\tHandleContextMenu({command.ToString()})."); return; }
            else { Trace.WriteLine($"\t명령어({command.ToString()}) 처리기가 없습니다."); return;}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        private bool HandleGenerator(AppCommand command)
        {
            switch (command)
            {
                /// 관망모델 메뉴
                case AppCommand.Grid:   //-> GRID생성
                    MessageHelper.Info("개발중..." + command.EnumToString());
                    return true;
                case AppCommand.InValidate: //-> 검증/보정
                    {
                        var view = MmakerShell.Views.GetView<Views.ValidationForm>();
                        view.MmakerShell = MmakerShell;
                        MmakerShell.DockManager.InitializeDockRight(view, "검/보정");
                        MmakerShell.DockManager.SetDockVisible(view, true);
                    }
                    return true;
                case AppCommand.UsageFlow:  //-> 사용량 등록
                    using (var form = new UsageFlow())
                    {
                        form.ShowDialog(MmakerShell.MainForm);
                    }
                    //App.Map.Identifier.HotTracking = !App.Map.Identifier.HotTracking;
                    //App.Map.Redraw2(tkRedrawType.RedrawSkipDataLayers);
                    return true;
                case AppCommand.MakeINP:    //-> 수리모델 생성
                    using (var form = new ModelCreationForm())
                    {
                        form.ShowDialog(MmakerShell.MainForm);
                    }
                    return true;
                case AppCommand.Attribute:  //-> 속성정보
                    var obj = Map.Layers.FirstOrDefault(l => l.IsSelected);
                    if (obj == null) return false;
                    {
                        //var view = MmakerShell.Views.GetView<Views.AttributeTable>();
                        var l = obj as IFeatureLayer;
                        //view.Layer = l;

                        var view = new DotSpatial.Symbology.Forms.AttributeDialog(l)
                        {
                            TopLevel = false,
                            FormBorderStyle = FormBorderStyle.None,
                            Text = "속성정보"
                        };
                        MmakerShell.DockManager.InitializeDockBottom(view, "속성");
                        MmakerShell.DockManager.SetDockVisible(view, true);
                    }
                    //App.Map.Identifier.HotTracking = !App.Map.Identifier.HotTracking;
                    //App.Map.Redraw2(tkRedrawType.RedrawSkipDataLayers);
                    MessageHelper.Info("개발중..." + command.EnumToString());
                    return true;
                /// 도구 메뉴
                case AppCommand.Epanet: //EPANET실행
                    MessageHelper.Info("개발중..." + command.EnumToString());
                    //App.Map.Identifier.HotTracking = !App.Map.Identifier.HotTracking;
                    //App.Map.Redraw2(tkRedrawType.RedrawSkipDataLayers);
                    return true;
                case AppCommand.MergeINP:   //수리모델 병합
                    MessageHelper.Info("개발중..." + command.EnumToString());
                    //App.Map.Identifier.HotTracking = !App.Map.Identifier.HotTracking;
                    //App.Map.Redraw2(tkRedrawType.RedrawSkipDataLayers);
                    return true;
                case AppCommand.SaveDpf:    //Dr.Pipe저장
                    MessageHelper.Info("개발중..." + command.EnumToString());
                    //string file = "";
                    //if (!MWL.Core.UI.FileHelper.ShowSaveDialog(null, Core.FileType.DrPipe, ref file)) return false;

                    //System.IO.File.WriteAllBytes(file, Properties.Resources.dpfSample);
                    //App.Map.Identifier.HotTracking = !App.Map.Identifier.HotTracking;
                    //App.Map.Redraw2(tkRedrawType.RedrawSkipDataLayers);
                    return true;
                default:
                    break;
            }
            return false;
        }

        private bool HandleContextMenu(AppCommand command)
        {
            switch (command)
            {
                case AppCommand.HighlightShapes:
                    //App.Map.Identifier.HotTracking = !App.Map.Identifier.HotTracking;
                    //App.Map.Redraw2(tkRedrawType.RedrawSkipDataLayers);
                    return true;
            }
            return false;
        }

        private bool HandleProject(AppCommand command)
        {
            switch (command)
            {
                case AppCommand.Snapshot:
                    MessageHelper.Info("준비중..." + command.EnumToString());
                    //App.Map.MakeScreenshot(MainForm.Instance);
                    break;

                case AppCommand.Search:
                    MessageHelper.Info("준비중..." + command.EnumToString());
                    //using (var form = new GeoLocationForm())
                    //{
                    //    form.ShowDialog(MainForm.Instance);
                    //}
                    break;

                case AppCommand.OpenProject:
                    if (Map.Layers.Any() && Map.GetLayers().Count > 1)
                    {
                        if (DialogResult.No == MessageHelper.AskCritical($"현재 작업중인 레이어가 존재합니다.\n계속 하시겠습니까?"))
                            return false;

                        InitProject();
                    }

                    MessageHelper.Info("준비중..." + command.EnumToString());
                    return true;

                case AppCommand.NewProject:   //새프로젝트
                    if (DialogResult.Yes == MessageHelper.AskCritical($"새로운 프로젝트를 만듭니다.\n작업중인 모든 레이어가 제거됩니다.\n계속 하시겠습니까?"))
                    {
                        InitProject();
                        //App.Project.TryClose();
                    }
                    return true;

                case AppCommand.SetProjection:
                    MessageHelper.Info("준비중..." + command.EnumToString());
                    {
                        //if (App.Map.NumLayers > 0)
                        //{
                        //    MessageHelper.Info("It's not allowed to change map projection when there are layers on the map.");
                        //}
                        //else
                        //{
                        //    using (var form = new SetProjectionForm())
                        //        form.ShowDialog(MainForm.Instance);
                        //}
                    }
                    return true;

                case AppCommand.SaveProject:
                    MessageHelper.Info("준비중..." + command.EnumToString());
                    //{
                    //    if (App.Project.Save())
                    //        MessageHelper.Info("Project was saved: " + App.Project.GetPath());
                    //}
                    return true;

                case AppCommand.SaveProjectAs:
                    MessageHelper.Info("준비중..." + command.EnumToString());
                    //App.Project.SaveAs();
                    return true;

                case AppCommand.CloseApp:
                    {
                        //MmakerShell.Views?.MainForm?.Close();
                        Application.Exit();
                    }
                    return true;
            }
            return false;
        }

        private void InitProject()
        {
            MmakerShell.AppManager.Map.ClearLayers();
            MMaker.Core.AppStatic.ReSetLayers();

            (MmakerShell.Controller as DiagnosisController).ResetBackgroundLayer();
            Map.ZoomToMaxExtent();
        }   

        private bool HandleLayers(AppCommand command)
        {
            switch (command)
            {
                //case AppCommand.AddDatabase:
                //    LayerHelper.OpenOgrLayer();
                //    return true;
                //case AppCommand.Open:
                //    LayerHelper.AddLayer(LayerType.All);
                //    return true;
                //case AppCommand.AddRaster:
                //    LayerHelper.AddLayer(LayerType.Raster);
                //    return true;

                //관리 -> 레이어 불러오기
                case AppCommand.AddVector:
                    {
                        var dm = new DotSpatial.Data.DataManager() { LoadInRam = true };

                        var files = MmakerShell.Dialog.OpenShapeFiles();
                        if (files == null)
                        {
                            //선택 파일이 없으면 리턴
                            return true;
                        }

                        foreach (string file in files)
                        {
                            IFeatureSet layer = dm.OpenVector(file, true, null);
                            LayerLoader form = new Views.LayerLoader(layer) { StartPosition = FormStartPosition.CenterScreen, MmakerShell = MmakerShell };
                            DialogResult log = form.ShowDialog();
                            layer.Close();
                        }
                    }
                    return true;
                case AppCommand.ZoomToLayer:
                    {
                        IMapLayer layer = Map.Layers.SelectedLayer;
                        if (layer == null)
                            return false;

                        Map.ViewExtents = layer.Extent;
                    }
                    return true;

                    //case AppCommand.CreateLayer:
                    //    Editor.RunCommand(EditorCommand.CreateLayer);
                    //    return true;
                    //case AppCommand.RemoveLayer:
                    //    LayerHelper.RemoveLayer();
                    //    return true;
            }
            return false;
        }

        private bool SetMapCursor(DotSpatial.Controls.FunctionMode mode)
        {
            MmakerShell.AppManager.Map.FunctionMode = mode;
            MmakerShell.RefreshUI();
            return true;
        }

        private bool HandleCursors(AppCommand command)
        {
            switch (command)
            {
                //case AppCommand.SelectByPolygon:
                //    return SetMapCursor(tkCursorMode.cmSelectByPolygon);
                case AppCommand.Identify:
                    return SetMapCursor(DotSpatial.Controls.FunctionMode.Info);
                //case AppCommand.Measure:
                //    App.Map.Measuring.MeasuringType = tkMeasuringType.MeasureDistance;
                //    return SetMapCursor(tkCursorMode.cmMeasure);
                //case AppCommand.MeasureArea:
                //    App.Map.Measuring.MeasuringType = tkMeasuringType.MeasureArea;
                //    return SetMapCursor(tkCursorMode.cmMeasure);
                case AppCommand.Pan:
                    return SetMapCursor(DotSpatial.Controls.FunctionMode.Pan);
                //case AppCommand.Select:
                //    return SetMapCursor(tkCursorMode.cmSelection);
                case AppCommand.ZoomIn:
                    return SetMapCursor(DotSpatial.Controls.FunctionMode.ZoomIn);
                case AppCommand.ZoomOut:
                    return SetMapCursor(DotSpatial.Controls.FunctionMode.ZoomOut);
                    //case AppCommand.ZoomToSelected:
                    //    LayerHelper.ZoomToSelected();
                    //    break;
                    //case AppCommand.ClearSelection:
                    //    LayerHelper.ClearSelection();
                    //    break;
                    //case AppCommand.None:
                    //    return true;
            }
            return false;
        }

        protected override void CommandNotFound(ToolStripItem item)
        {
            MessageHelper.Info("No handle is found: " + item.Name);
        }
    }
}