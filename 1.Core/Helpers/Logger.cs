using Serilog;

namespace Todoly.Core.Helpers;
public static class Logger
{
    private static ILogger? _logger;

    public static ILogger Instance
    {
        get
        {
            if (_logger == null)
            {
                _logger = new LoggerConfiguration()
                            .MinimumLevel.Debug()
                            .WriteTo.File("logs.txt", outputTemplate: "{Timestamp:yyy-MM-dd HH:mm:ss.fff} | {Level:u3} | {Message} {NewLine}", rollingInterval: RollingInterval.Day)
                            .CreateLogger();
            }

            return _logger;
        }
    }
    public static void ConfigureLogger()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .Enrich.FromLogContext()
            .WriteTo.File("logs\\log.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 31, fileSizeLimitBytes: 10485760, buffered: true)
            .CreateLogger();
    }
}
