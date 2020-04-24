using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DrPipe.Core;
using DrPipe.Core.Services;
using MindOne.Geographics.Layers;
using Serilog;
using Serilog.Events;
using Syncfusion.Windows.Forms;

namespace DrPipe
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var appStartTime = DateTime.Now;
            var environment  = new DrPipeEnvironment();
            environment.ProcessFileName        = Process.GetCurrentProcess().MainModule.FileName;
            environment.ProcessDirName         = Path.GetDirectoryName(environment.ProcessFileName);
            environment.AppDataDirName         = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); // %AppData%
            environment.RootDirectory          = Path.Combine(environment.AppDataDirName, "DrPipe");                   // %AppData%\DrPipe
            environment.LogsDirectory          = Path.Combine(environment.RootDirectory , "logs");                     // %AppData%\DrPipe\logs
            environment.DataDirectory          = Path.Combine(environment.RootDirectory , "data");                     // %AppData%\DrPipe\data
            //environment.DialogDefaultDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);     // %UserProfile%\documents
            environment.DialogDefaultDirectory = Path.Combine(environment.ProcessDirName, @"samples");
            environment.EpanetFileName         = Path.Combine(environment.ProcessDirName, @"epanet\epanet2w\Epanet2w.exe");
            environment.TempDirectory          = Path.Combine(environment.ProcessDirName, @"_temp");
            environment.FirebirdClientFileName = Path.Combine(environment.ProcessDirName, @"firebird\fbembed.dll");
            environment.FirebirdGbakFileName   = Path.Combine(environment.ProcessDirName, @"firebird\gbak.exe");
            environment.LoggerName             = "drpipe";

            Directory.CreateDirectory(environment.RootDirectory);
            Directory.CreateDirectory(environment.LogsDirectory);
            Directory.CreateDirectory(environment.DataDirectory);
            Directory.CreateDirectory(environment.TempDirectory);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += OnApplicationThreadException;
            AppDomain.CurrentDomain.UnhandledException += OnCurrentDomainUnhandledException;

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
                                    messageBoxTitle : "Dr.Pipe",
                                    openTitle       : "열기 - Dr.Pipe",
                                    saveTitle       : "저장 - Dr.Pipe",
                                    defaultDirectory: environment.DialogDefaultDirectory);
                var views  = new ViewService();
                var shell  = new Shell(environment, dialog, views);
                Log.Logger.Information($"Initialized ({(DateTime.Now - appStartTime).TotalSeconds} sec)");
                Application.Run(shell);
                Log.Logger.Information("Shutdown");
            }
            catch (Exception e)
            {
                ShowExceptionDetails(e);
            }
        }

        private static void InitializeLogger(string loggerName, string logsDirectory)
        {
            var minimumLevel           = LogEventLevel.Debug;
            var outputTemplate         = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}";
            var pathFormat             = Path.Combine(logsDirectory, loggerName + ".{Date}.log");
            var retainedFileCountLimit = 100;
            var config                 = new LoggerConfiguration()
                                                .Enrich.FromLogContext()
                                                .MinimumLevel.Is(minimumLevel)
                                                .WriteTo.Logger(logger => 
                                                                    logger
                                                                        //.Filter
                                                                        //.ByIncludingOnly(inclusionPredicate)
                                                                        .WriteTo.RollingFile(
                                                                            pathFormat            : pathFormat, 
                                                                            outputTemplate        : outputTemplate,
                                                                            retainedFileCountLimit: retainedFileCountLimit));
            Log.Logger = config.CreateLogger();
        }
        private static void InitializeSyncfusion()
        {
            SkinManager.LoadAssembly(typeof(Syncfusion.WinForms.Themes.Office2016Theme).Assembly);
            SkinManager.ApplicationVisualTheme = "Office2016Colorful"; // Office2016White Office2016Colorful
        }

        private static void OnApplicationThreadException(object sender, ThreadExceptionEventArgs e)
        {
            // All exceptions thrown by the main thread are handled over this method
            var ex = e.Exception;
            ShowExceptionDetails(ex);
        }
        private static void OnCurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // All exceptions thrown by additional threads are handled in this method
            var ex = e.ExceptionObject as Exception;
            ShowExceptionDetails(ex);
        }
        private static void ShowExceptionDetails(Exception exception)
        {
            Log.Logger.Error(exception: exception, messageTemplate: string.Empty);
            MessageBox.Show(
                exception.Message, 
                "오류가 발생하였습니다. - Dr.Pipe",
                MessageBoxButtons.OK, 
                MessageBoxIcon.Error);
        }
    }
}
