using NUnit.Framework;
using Serilog;
using TechTalk.SpecFlow;

namespace Todoly.Core.Helpers;
public static class ConfigLogger
{
    private static Loggers? _logger;
    private static ScenarioContext? _context;
    public static Loggers Instance
    {
        get
        {
            if (_logger == null)
            {
                _logger = CreateLoggersForTest(_context!.ScenarioInfo.Title);
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
            TestLogger = ConfigureLogger(logFilesName, 1),
            GeneralLogger = ConfigureLogger(generalLogFileName, 1)
        };
    }

    public static ILogger ConfigureLogger(string fileName, int retainedLimit)
    {
        return new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File(fileName, outputTemplate: "{Timestamp:yyy-MM-dd HH:mm:ss.fff} | {Level:u3} | {Message} {NewLine}", retainedFileCountLimit: retainedLimit)
            .CreateLogger();
    }

    public static void Information(string message, ScenarioContext context)
    {
        _context = context;
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
