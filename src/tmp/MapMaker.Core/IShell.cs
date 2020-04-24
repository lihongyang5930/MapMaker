using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapMaker.Core.Helper;
using MindOne.Core.Services;

namespace MapMaker.Core
{
    public interface IShell
    {
        ViewService Views { get; set; }
        DialogService Dialog { get; set; }
        DockManager DockManager { get; set; }
        RibbonManager RibbonManager { get; set; }
        AppEnvironment appEnvironment { get; set; }

        string AppTitle { get; set; }
        string ProjectName { get; set; }

        void Invoke(Action action);
        IDisposable PleaseWait();
        IDisposable PleaseWait(string message);
    }
}
