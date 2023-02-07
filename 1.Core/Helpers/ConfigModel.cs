namespace SeleniumTest.Core;

public class ConfigModel
{
    public static readonly int DriverImplicitTimeout = ConfigBuilder.Instance.GetInt(
        "DriverImplicitTimeout"
    );

    public static readonly int DriverExplicitTimeout = ConfigBuilder.Instance.GetInt(
        "DriverExplicitTimeout"
    );

    public static readonly string HostUrl = ConfigBuilder.Instance.GetString("HostUrl");

    public static readonly string TODO_LY_EMAIL = ConfigBuilder.Instance.GetString("TODO-LY-EMAIL");
    public static readonly string TODO_LY_PASS = ConfigBuilder.Instance.GetString("TODO-LY-PASS");
}
