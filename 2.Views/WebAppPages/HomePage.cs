using SeleniumTest.Core;
using SeleniumTest.Core.Drivers;
using UIElements.Commons;
using UIElements.Enums;
using UIElements.Interfaces;
using UIElements.Web;

namespace Views.WebAppPages;

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
