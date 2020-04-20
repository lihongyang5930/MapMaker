using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapMaker.Core;
using MindOne.Core.Services;
using Serilog;
using Serilog.Events;
using Syncfusion.Windows.Forms;

namespace MapMaker
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var appStartTime = DateTime.Now;
            var environment = new AppEnvironment();
            environment.ProcessFileName = Process.GetCurrentProcess().MainModule.FileName;
            environment.ProcessDirName = Path.GetDirectoryName(environment.ProcessFileName);
            environment.AppDataDirName = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory); // %AppData%
            environment.RootDirectory = Path.Combine(environment.AppDataDirName, "MapMaker");                   // %AppData%\DrPipe
            environment.LogsDirectory = Path.Combine(environment.RootDirectory, "logs");                     // %AppData%\DrPipe\logs
            environment.DataDirectory = Path.Combine(environment.RootDirectory, "data");                     // %AppData%\DrPipe\data
            environment.DialogDefaultDirectory = Path.Combine(environment.ProcessDirName, @"samples");
            environment.EpanetFileName = Path.Combine(environment.ProcessDirName, @"epanet\epanet2w\Epanet2w.exe");
            environment.TempDirectory = Path.Combine(environment.ProcessDirName, @"_temp");
            environment.FirebirdClientFileName = Path.Combine(environment.ProcessDirName, @"firebird\fbembed.dll");
            environment.FirebirdGbakFileName = Path.Combine(environment.ProcessDirName, @"firebird\gbak.exe");
            environment.LoggerName = "MapMaker";

            Directory.CreateDirectory(environment.RootDirectory);
            Directory.CreateDirectory(environment.LogsDirectory);
            Directory.CreateDirectory(environment.DataDirectory);
            Directory.CreateDirectory(environment.TempDirectory);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                InitializeLogger(environment.LoggerName, environment.LogsDirectory);
                InitializeSyncfusion();

                Appearances.DefaultFont = new System.Drawing.Font(
                    "나눔바른고딕",
                    8F,
                    System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point,
                    0);

                var dialog = new DialogService(
                             messageBoxTitle: "MapMaker v2.0",
                             openTitle: "열기 - MapMaker v2.0",
                             saveTitle: "저장 - MapMaker v2.0",
                             defaultDirectory: environment.DialogDefaultDirectory);
                var views = new ViewService();
                var shell = new Shell(environment, dialog, views);
                Log.Logger.Information($"Initialized ({(DateTime.Now - appStartTime).TotalSeconds} sec)");
                Application.Run(shell);
                Log.Logger.Information("Shutdown");
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static void InitializeLogger(string loggerName, string logsDirectory)
        {
            var minimumLevel = LogEventLevel.Debug;
            var outputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}";
            var pathFormat = Path.Combine(logsDirectory, loggerName + ".{Date}.log");
            var retainedFileCountLimit = 100;
            var config = new Serilog.LoggerConfiguration()
                                                .Enrich.FromLogContext()
                                                .MinimumLevel.Is(minimumLevel)
                                                .WriteTo.Logger(logger =>
                                                                    logger.WriteTo.RollingFile(
                                                                            pathFormat: pathFormat,
                                                                            outputTemplate: outputTemplate,
                                                                            retainedFileCountLimit: retainedFileCountLimit));
            Log.Logger = config.CreateLogger();
        }

        private static void InitializeSyncfusion()
        {
            SkinManager.LoadAssembly(typeof(Syncfusion.WinForms.Themes.Office2016Theme).Assembly);
            SkinManager.ApplicationVisualTheme = "Office2016Colorful"; // Office2016White Office2016Colorful
        }
    }
}
