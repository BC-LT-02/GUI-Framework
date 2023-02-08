using SeleniumTest.Core;
using UIElements.Commons;
using UIElements.Enums;
using UIElements.Interfaces;
using UIElements.Web;

namespace Views.WebAppPages;

public class ProfilePage
{
    public ITypeable FullNameTextField => new TextField("", new Locator(LocatorType.Id, "FullNameInput"));
    public ITypeable EmailTextField => new TextField("", new Locator(LocatorType.Id, "EmailInput"));
    public IClickable OkButton => new Button("", new Locator(LocatorType.XPath, "c//div[@class='ui-dialog-buttonset']//span[text()='Ok']"));
    public IClickable Settings => new Button("", new Locator(LocatorType.XPath, "//div[@id='ctl00_HeaderTopControl1_PanelHeaderButtons']//a[text()='Settings']"));

    public ProfilePage()
    {
        // _driver = driver;
    }
}
