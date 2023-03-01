using NUnit.Framework;
using Serilog;

namespace Todoly.Core.Helpers;
public static class ConfigLogger
{
    private static Loggers? _logger;

    public static Loggers Instance
    {
        get
        {
            if (_logger == null)
            {
                _logger = CreateLoggersForTest(TestContext.CurrentContext.Test.Name);
            }

            return _logger;
        }
        set => _logger = value;
    }
    public static Loggers CreateLoggersForTest(string? testName)
    {
        string logFilesName = $"Logs/Tests/log-{testName}.txt";
        string generalLogFileName = $"Logs/Latest.txt";

        return new Loggers
        {
            TestLogger = ConfigureLogger(logFilesName, RollingInterval.Minute, 1),
            GeneralLogger = ConfigureLogger(generalLogFileName, RollingInterval.Hour, 1)
        };
    }

    public static ILogger ConfigureLogger(string fileName, RollingInterval interval, int retainedLimit)
    {
        return new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File(fileName, outputTemplate: "{Timestamp:yyy-MM-dd HH:mm:ss.fff} | {Level:u3} | {Message} {NewLine}", rollingInterval: interval, retainedFileCountLimit: retainedLimit)
            .CreateLogger();
    }

    public static void Information(string message)
    {
        Instance.TestLogger!.Information(message);
        Instance.GeneralLogger!.Information(message);
    }

    public static void Error(string message)
    {
        Instance.TestLogger!.Error(message);
        Instance.GeneralLogger!.Error(message);
    }

    public static void Debug(string message)
    {
        Instance.TestLogger!.Debug(message);
        Instance.GeneralLogger!.Debug(message);
    }
}
