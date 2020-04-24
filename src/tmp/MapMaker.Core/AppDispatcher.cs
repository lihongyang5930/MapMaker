using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapMaker.Core.Enums;
using MindOne.Core.Helper;

namespace MapMaker.Core
{
    public class AppDispatcher : CommandDispatcher<AppCommand>
    {
        public override void Run(AppCommand command)
        {
            if (HandleCursors(command)) return;

            if (HandleGenerator(command)) return;

            if (HandleLayers(command)) return;

            if (HandleProject(command)) return;

            if (HandleContextMenu(command)) return;
        }

        private bool HandleGenerator(AppCommand command)
        {
            switch (command)
            {
                case AppCommand.Grid:
                    MessageHelper.Info("개발중..." + command.EnumToString());
                    return true;
                case AppCommand.InValidate:
                    {
                        //if (App.Map.NumLayers == 0)
                        //{
                        //    MessageHelper.Info("레이어 불러오기를 실행하십시오.");
                        //    return false;
                        //}
                        //var dock = App.Docker.Contents.FirstOrDefault(x => x.DockHandler.Form.Name == "ValidationForm");
                        //if (dock == null)
                        //{
                        //    var form = new ValidationForm();
                        //    form.Show(App.Docker, DockState.DockRight);
                        //}
                        //else
                        //{
                        //    dock.DockHandler.DockState = DockState.DockRight;
                        //    dock.DockHandler.Activate();
                        //}
                    }
                    return true;
                case AppCommand.UsageFlow:
                    //if (App.Map.NumLayers == 0)
                    //{
                    //    MessageHelper.Info("레이어 불러오기를 실행하십시오.");
                    //    return false;
                    //}
                    //using (var form = new UsageFlow())
                    //{
                    //    form.ShowDialog(MainForm.Instance);
                    //}
                    //App.Map.Identifier.HotTracking = !App.Map.Identifier.HotTracking;
                    //App.Map.Redraw2(tkRedrawType.RedrawSkipDataLayers);
                    return true;
                case AppCommand.MergeINP:
                    //if (App.Map.NumLayers == 0)
                    //{
                    //    MessageHelper.Info("레이어 불러오기를 실행하십시오.");
                    //    return false;
                    //}
                    MessageHelper.Info("개발중..." + command.EnumToString());
                    //App.Map.Identifier.HotTracking = !App.Map.Identifier.HotTracking;
                    //App.Map.Redraw2(tkRedrawType.RedrawSkipDataLayers);
                    return true;
                case AppCommand.Attribute:
                    //if (App.Map.NumLayers == 0)
                    //{
                    //    MessageHelper.Info("레이어 불러오기를 실행하십시오.");
                    //    return false;
                    //}
                    //App.Map.Identifier.HotTracking = !App.Map.Identifier.HotTracking;
                    //App.Map.Redraw2(tkRedrawType.RedrawSkipDataLayers);
                    MessageHelper.Info("개발중..." + command.EnumToString());
                    return true;
                case AppCommand.MakeINP:
                    //if (App.Map.NumLayers == 0)
                    //{
                    //    MessageHelper.Info("레이어 불러오기를 실행하십시오.");
                    //    return false;
                    //}
                    //using (var form = new ModelCreationForm())
                    //{
                    //    form.ShowDialog(MainForm.Instance);
                    //}
                    return true;

                case AppCommand.Epanet:
                    //if (App.Map.NumLayers == 0)
                    //{
                    //    MessageHelper.Info("레이어 불러오기를 실행하십시오.");
                    //    return false;
                    //}
                    MessageHelper.Info("개발중..." + command.EnumToString());
                    //App.Map.Identifier.HotTracking = !App.Map.Identifier.HotTracking;
                    //App.Map.Redraw2(tkRedrawType.RedrawSkipDataLayers);
                    return true;
                case AppCommand.SaveDpf:
                    //if (App.Map.NumLayers == 0)
                    //{
                    //    MessageHelper.Info("레이어 불러오기를 실행하십시오.");
                    //    return false;
                    //}
                    //string file = "";
                    //if (!MWL.Core.UI.FileHelper.ShowSaveDialog(null, Core.FileType.DrPipe, ref file)) return false;

                    //System.IO.File.WriteAllBytes(file, Properties.Resources.dpfSample);
                    //App.Map.Identifier.HotTracking = !App.Map.Identifier.HotTracking;
                    //App.Map.Redraw2(tkRedrawType.RedrawSkipDataLayers);
                    return true;

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
                    //App.Map.MakeScreenshot(MainForm.Instance);
                    break;
                case AppCommand.Search:
                    //using (var form = new GeoLocationForm())
                    //{
                    //    form.ShowDialog(MainForm.Instance);
                    //}
                    break;
                case AppCommand.LoadProject:
                    //{
                    //    string filename;
                    //    if (FileHelper.ShowOpenDialog(MainForm.Instance, FileType.Project, out filename))
                    //    {
                    //        if (App.Project.TryClose())
                    //        {
                    //            App.Project.Load(filename);
                    //        }
                    //    }
                    //}
                    return true;
                case AppCommand.CloseProject:
                    //App.Project.TryClose();
                    return true;
                case AppCommand.SetProjection:
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
                    //{
                    //    if (App.Project.Save())
                    //        MessageHelper.Info("Project was saved: " + App.Project.GetPath());
                    //}
                    return true;
                case AppCommand.SaveProjectAs:
                    //App.Project.SaveAs();
                    return true;
                case AppCommand.CloseApp:
                    //MainForm.Instance.Close();
                    return true;
            }
            return false;
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
                //case AppCommand.AddVector:
                //    LayerHelper.AddLayer(LayerType.Vector);
                //    return true;
                //case AppCommand.RemoveLayer:
                //    LayerHelper.RemoveLayer();
                //    return true;
                //case AppCommand.ZoomToLayer:
                //    LayerHelper.ZoomToLayer();
                //    return true;
                //case AppCommand.CreateLayer:
                //    Editor.RunCommand(EditorCommand.CreateLayer);
                //    return true;
            }
            return false;
        }

        //private bool SetMapCursor(tkCursorMode mode)
        //{
        //    App.Map.CursorMode = mode;
        //    App.RefreshUI();
        //    return true;
        //}

        private bool HandleCursors(AppCommand command)
        {
            switch (command)
            {
                //case AppCommand.SelectByPolygon:
                //    return SetMapCursor(tkCursorMode.cmSelectByPolygon);
                //case AppCommand.Identify:
                //    return SetMapCursor(tkCursorMode.cmIdentify);
                //case AppCommand.Measure:
                //    App.Map.Measuring.MeasuringType = tkMeasuringType.MeasureDistance;
                //    return SetMapCursor(tkCursorMode.cmMeasure);
                //case AppCommand.MeasureArea:
                //    App.Map.Measuring.MeasuringType = tkMeasuringType.MeasureArea;
                //    return SetMapCursor(tkCursorMode.cmMeasure);
                //case AppCommand.Pan:
                //    return SetMapCursor(tkCursorMode.cmPan);
                //case AppCommand.Select:
                //    return SetMapCursor(tkCursorMode.cmSelection);
                //case AppCommand.ZoomIn:
                //    return SetMapCursor(tkCursorMode.cmZoomIn);
                //case AppCommand.ZoomOut:
                //    return SetMapCursor(tkCursorMode.cmZoomOut);
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
