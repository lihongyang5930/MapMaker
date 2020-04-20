using System;
using Serilog;

namespace DrPipe.Core.Services
{
    public class Logger
    {
        public void Debug(string message)
        {
            Log.Logger.Debug(message);
        }

        public void Error(string message)
        {
            Log.Logger.Error(message);
        }

        public void Error(Exception exception)
        {
            Log.Logger.Error(exception, string.Empty);
        }

        public void Information(string message)
        {
            Log.Logger.Information(message);
        }
    }
}
