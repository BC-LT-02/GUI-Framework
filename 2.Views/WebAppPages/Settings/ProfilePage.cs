using Todoly.Core.UIElements.Commons;
using Todoly.Core.UIElements.Enums;
using Todoly.Core.UIElements.Interfaces;
using Todoly.Core.UIElements.Web;

namespace Todoly.Views.WebAppPages;

public class ProfilePage
{
    public TextField FullNameTextField => new TextField("", new Locator(LocatorType.Id, "FullNameInput"));
    public TextField EmailTextField => new TextField("", new Locator(LocatorType.Id, "EmailInput"));
    public Button OkButton => new Button("", new Locator(LocatorType.XPath, "//div[@class='ui-dialog-buttonset']//span[text()='Ok']"));
    public Button CloseButton => new Button("", new Locator(LocatorType.XPath, "//div[@aria-labelledby='ui-dialog-title-settingsDialog'][contains(@style, 'block')]//ul[@id='settings_tabs']//span[text()='close']"));
    public Button NonDisplayedCloseButton => new Button("", new Locator(LocatorType.XPath, "//div[@aria-labelledby='ui-dialog-title-settingsDialog'][contains(@style, 'none')]//ul[@id='settings_tabs']//span[text()='close']"));
}
