using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRichGame
{
    internal class LogHelper
    {
        public static void Init()
        {
            Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.Console()
                    .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
                    .CreateLogger();
        }
        public static void Info(string v)
        {
            Log.Information(v);
        }
        public static void Error(Exception? exception, string messageTemplate)
        {
            Log.Error(exception, messageTemplate);
        }
    }

}
