using DotSpatial.Controls;

using MindOne.Core.Services;

using MMaker.Core.Helper;
using MMaker.Geographics.Controls;

using System;
using System.Windows.Forms;

namespace MMaker.Core
{
    public interface IShell
    {
        ViewService Views { get; set; }
        DialogService Dialog { get; set; }
        DockManager DockManager { get; set; }
        RibbonManager RibbonManager { get; set; }
        AppEnvironment AppEnvironment { get; set; }
        AppManager AppManager { get; set; }

        string AppTitle { get; set; }
        string ProjectName { get; set; }

        void Invoke(Action action);
        IDisposable PleaseWait();
        IDisposable PleaseWait(string message);

        Form MainForm { get; }
        MapView MapView { get; set; }
        LegendView LegendView { get; set; }

        void RefreshUI();
    }
}
