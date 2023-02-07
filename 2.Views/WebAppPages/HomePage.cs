using SeleniumTest.Core;
using SeleniumTest.Core.Interfaces;
using UIElements.Commons;
using UIElements.Enums;
using UIElements.Interfaces;
using UIElements.Web;

namespace Views.WebAppPages;

public class HomePage
{
    private readonly IGenericWebDriver _driver;
    public readonly string HostUrl = ConfigModel.HostUrl;

    public IClickable LogoutButton =>
        new Button(
            "",
            new Locator(LocatorType.Id, "ctl00_HeaderTopControl1_LinkButtonLogout"),
            _driver
        );

    public HomePage(IGenericWebDriver driver)
    {
        _driver = driver;
        _driver.Instance().Navigate().GoToUrl(HostUrl);
    }

    public void LogoutOffTheApplication()
    {
        LogoutButton.Click();
    }
}
