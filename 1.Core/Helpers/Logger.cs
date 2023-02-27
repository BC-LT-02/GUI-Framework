using Serilog;
using NUnit.Framework;

namespace Todoly.Core.Helpers;
public static class Logger
{
    private static ILogger[]? _logger;

    public static ILogger[] Instance
    {
        get
        {
            if (_logger == null)
            {
                _logger = CreateLoggersForTest(TestContext.CurrentContext.Test.Name);
            }

            return _logger;
        }
        set
        {
            _logger = value;
        }
    }
    public static ILogger[] CreateLoggersForTest(string? testName)
    {
        string logFilesName = $"Logs/Tests/log-{testName}.txt";
        string generalLogFileName = $"Logs/Latest.txt";

        return new ILogger[] { ConfigureLogger(logFilesName, RollingInterval.Minute, 1), ConfigureLogger(generalLogFileName, RollingInterval.Hour, 1) };
    }

    public static ILogger ConfigureLogger(string fileName, RollingInterval interval, int retainedLimit)
    {
        return new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File(fileName, outputTemplate: "{Timestamp:yyy-MM-dd HH:mm:ss.fff} | {Level:u3} | {Message} {NewLine}", rollingInterval: interval, retainedFileCountLimit: retainedLimit)
            .CreateLogger();
    }
}
