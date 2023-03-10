namespace Todoly.Core.Helpers;

public class ConfigModel
{
    public static readonly int DriverImplicitTimeout = ConfigBuilder.Instance.GetInt(
        "ui",
        "DriverImplicitTimeout"
    );

    public static readonly int DriverExplicitTimeout = ConfigBuilder.Instance.GetInt(
        "ui",
        "DriverExplicitTimeout"
    );

    public static readonly string HostUrl = ConfigBuilder.Instance.GetString("ui", "HostUrl");
    public static readonly string TODO_LY_EMAIL = ConfigBuilder.Instance.GetString("TODO-LY-EMAIL");
    public static readonly string TODO_LY_PASS = ConfigBuilder.Instance.GetString("TODO-LY-PASS");
    public static readonly string BROWSERSTACK_USERNAME = ConfigBuilder.Instance.GetString("BROWSERSTACK-USERNAME");
    public static readonly string BROWSERSTACK_ACCESSKEY = ConfigBuilder.Instance.GetString("BROWSERSTACK-ACCESSKEY");
    public static readonly string BROWSERSTACK_URL = ConfigBuilder.Instance.GetString("ui", "BrowserStackUrl");
    public static readonly string UserFullName = ConfigBuilder.Instance.GetString("api", "UserFullName");
    public static readonly string UserTimeZone = ConfigBuilder.Instance.GetString("api", "UserTimeZone");
    public static readonly string DriverType = ConfigBuilder.Instance.GetString("ui", "DriverType");
    public static readonly string ApiHostUrl = ConfigBuilder.Instance.GetString(
        "api",
        "ApiHostUrl"
    );
    public static readonly string ProjectUri = ConfigBuilder.Instance.GetString(
        "api",
        "ProjectUri"
    );
    public static readonly string ItemUri = ConfigBuilder.Instance.GetString("api", "ItemUri");
    public static readonly string UserUri = ConfigBuilder.Instance.GetString("api", "UserUri");
    public static readonly string UserPutUri = ConfigBuilder.Instance.GetString("api", "UserPutUri");
    public static readonly string CurrentProject = ConfigBuilder.Instance.GetString(
        "api",
        "CurrentProject"
    );
    public static readonly string CurrentProjectPayload = ConfigBuilder.Instance.GetString(
        "api",
        "CurrentProjectPayload"
    );
    public static readonly string DriverMode = ConfigBuilder.Instance.GetString("ui", "DriverMode");
    public static readonly string CurrentItem = ConfigBuilder.Instance.GetString(
        "api",
        "CurrentItem"
    );
}
