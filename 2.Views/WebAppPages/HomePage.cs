using Todoly.Core.Helpers;
using Todoly.Core.UIElements.Commons;
using Todoly.Core.UIElements.Drivers;
using Todoly.Core.UIElements.Enums;
using Todoly.Core.UIElements.Interfaces;
using Todoly.Core.UIElements.Web;

namespace Todoly.Views.WebAppPages;

public class HomePage
{
    public readonly string HostUrl = ConfigModel.HostUrl;

    public IClickable LogoutButton =>
        new Button("", new Locator(LocatorType.Id, "ctl00_HeaderTopControl1_LinkButtonLogout"));
    public IClickable SettingsButton => new Button("", new Locator(LocatorType.XPath, "//div[@id='ctl00_HeaderTopControl1_PanelHeaderButtons']//a[text()='Settings']"));

    public HomePage()
    {
        //GenericWebDriver.Instance.Navigate().GoToUrl(HostUrl);
    }
}
