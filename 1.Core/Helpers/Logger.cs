using Serilog;

namespace Todoly.Core.Helpers;
public static class Logger
{
    public static ILogger CreateLoggerForTest(string? testName)
    {
        string logFileName = $"Logs/log-{testName}.txt";

        return new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File(logFileName, outputTemplate: "{Timestamp:yyy-MM-dd HH:mm:ss.fff} | {Level:u3} | {Message} {NewLine}")
            .CreateLogger();
    }
}
