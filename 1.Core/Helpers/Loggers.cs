using Serilog;

namespace Todoly.Core.Helpers;

public class Loggers
{
    public ILogger? TestLogger { get; set; }
    public ILogger? GeneralLogger { get; set; }
}
