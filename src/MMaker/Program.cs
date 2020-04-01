using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

using MindOne.Core.Services;

using MMaker.Core;

using Serilog;
using Serilog.Events;

using Syncfusion.Windows.Forms;

namespace MMaker
{
    internal static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var environment = new AppEnvironment();

            InitEnvironment(environment);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            InitializeLogger(environment.LoggerName, environment.LogsDirectory);
            InitializeSyncfusion();

            Appearances.DefaultFont = new System.Drawing.Font(
                "나눔바른고딕",
                8F,
                System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point,
                0);

            StartMapMaker(environment);
        }
        /// <summary>
        /// 프로그램 시작
        /// </summary>
        /// <param name="environment">환경설정정보</param>
        private static void StartMapMaker(AppEnvironment environment)
        {
            var appStartTime = DateTime.Now;
            try
            {
                var dialog = new DialogService(
                             messageBoxTitle: "MapMaker v2.0",
                             openTitle: "열기 - MapMaker v2.0",
                             saveTitle: "저장 - MapMaker v2.0",
                             defaultDirectory: environment.DialogDefaultDirectory);
                var views = new ViewService();
                var shell = new MmakerShell(environment, dialog, views);
                Log.Logger.Information($"Initialized ({(DateTime.Now - appStartTime).TotalSeconds} sec)");

                Application.Run(shell);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
                throw;
            }
            finally
            {
                Log.Logger.Information("Shutdown");
            }
        }

        private static void InitEnvironment(AppEnvironment environment)
        {
            environment.ProcessFileName = Process.GetCurrentProcess().MainModule.FileName;
            environment.ProcessDirName = Path.GetDirectoryName(environment.ProcessFileName);
            environment.AppDataDirName = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);      // %AppData%
            environment.RootDirectory = Path.Combine(environment.AppDataDirName, "MapMaker");               // %AppData%\DrPipe
            environment.LogsDirectory = Path.Combine(environment.RootDirectory, "logs");                    // %AppData%\DrPipe\logs
            environment.DataDirectory = Path.Combine(environment.RootDirectory, "data");                    // %AppData%\DrPipe\data
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
                            .WriteTo.Logger(logger => logger.WriteTo.RollingFile(
                                                        pathFormat: pathFormat,
                                                        outputTemplate: outputTemplate,
                                                        retainedFileCountLimit: retainedFileCountLimit));
            Log.Logger = config.CreateLogger();
        }

        private static void InitializeSyncfusion()
        {
            Syncfusion.Windows.Forms.SkinManager.LoadAssembly(typeof(Syncfusion.WinForms.Themes.Office2016Theme).Assembly);
            SkinManager.ApplicationVisualTheme = "Office2016Colorful"; // Office2016White Office2016Colorful
        }
    }
}