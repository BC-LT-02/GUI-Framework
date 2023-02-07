using SeleniumTest.Core;
using SeleniumTest.Core.Interfaces;
using UIElements.Commons;
using UIElements.Enums;
using UIElements.Interfaces;
using UIElements.Web;

namespace Views.WebAppPages;

public class ProfilePage
{
    public readonly IGenericWebDriver _driver;
    public ITypeable FullNameTextField => new TextField("", new Locator(LocatorType.Id, "FullNameInput"), _driver);
    public ITypeable EmailTextField => new TextField("", new Locator(LocatorType.Id, "EmailInput"), _driver);
    public IClickable OkButton => new Button("", new Locator(LocatorType.XPath, "c//div[@class='ui-dialog-buttonset']//span[text()='Ok']"), _driver);
    public IClickable Settings => new Button("", new Locator(LocatorType.XPath, "//div[@id='ctl00_HeaderTopControl1_PanelHeaderButtons']//a[text()='Settings']"), _driver);

    public ProfilePage(IGenericWebDriver driver)
    {
        _driver = driver;
    }
}
