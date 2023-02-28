using Serilog;

namespace Todoly.Core.Helpers;
public class TestLoggers
{
    public ILogger? TestLogger { get; set; }
    public ILogger? GeneralLogger { get; set; }
}
