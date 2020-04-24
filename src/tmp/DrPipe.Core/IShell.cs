using System;
using DrPipe.Core.Services;

namespace DrPipe.Core
{
    public interface IShell
    {
        ViewService       Views             { get; set; }
        DialogService     Dialog            { get; set; }
        DockManager       DockManager       { get; set; }
        RibbonManager     RibbonManager     { get; set; }
        DrPipeEnvironment DrPipeEnvironment { get; set; }

        string AppTitle    { get; set; }
        string ProjectName { get; set; }

        void Invoke(Action action);
        IDisposable PleaseWait();
        IDisposable PleaseWait(string message);
    }
}
