using UIElements.Commons;
using UIElements.Enums;
using UIElements.Interfaces;
using UIElements.Web;

namespace Views.WebAppPages;

public class ProfilePage
{
    public ITypeable FullNameTextField => new TextField("", new Locator(LocatorType.Id, "FullNameInput"));
    public ITypeable EmailTextField => new TextField("", new Locator(LocatorType.Id, "EmailInput"));
    public IClickable OkButton => new Button("", new Locator(LocatorType.XPath, "//div[@class='ui-dialog-buttonset']//span[text()='Ok']"));
    public IClickable CloseButton => new Button("", new Locator(LocatorType.XPath, "//div[@aria-labelledby='ui-dialog-title-settingsDialog'][contains(@style, 'block')]//ul[@id='settings_tabs']//span[text()='close']"));
    public IClickable NonDisplayedCloseButton => new Button("", new Locator(LocatorType.XPath, "//div[@aria-labelledby='ui-dialog-title-settingsDialog'][contains(@style, 'none')]//ul[@id='settings_tabs']//span[text()='close']"));

    public ProfilePage()
    {
    }
}
