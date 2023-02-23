using Todoly.Core.UIElements.Commons;
using Todoly.Core.UIElements.Enums;
using Todoly.Core.UIElements.Web;
using Todoly.Views.WebAppPages.Attributes;

namespace Todoly.Views.WebAppPages;

[View("Profile Page")]
public class ProfilePage
{
    [Element("Profile Settings", ElementType.Container)]
    [Locator(LocatorType.Id, "settings_Profile")]
    public TextField ProfileSettingsContainer => UIElementFactory.GetElement("Profile Settings", "Profile Page");

    [Element("FullName", ElementType.TextField)]
    [Locator(LocatorType.Id, "FullNameInput")]
    public TextField FullNameTextField => UIElementFactory.GetElement("FullName", "Profile Page");

    [Element("Email", ElementType.TextField)]
    [Locator(LocatorType.Id, "EmailInput")]
    public TextField EmailTextField => UIElementFactory.GetElement(elementName: "Email", "Profile Page");

    [Element("Ok", ElementType.Button)]
    [Locator(LocatorType.XPath, "//div[@class='ui-dialog-buttonset']//span[text()='Ok']")]
    public Button OkButton => UIElementFactory.GetElement("Ok", "Profile Page");

    [Element("Close", ElementType.Button)]
    [Locator(LocatorType.XPath, "//div[@aria-labelledby='ui-dialog-title-settingsDialog'][contains(@style, 'block')]//ul[@id='settings_tabs']//span[text()='close']")]
    public Button CloseButton => UIElementFactory.GetElement("Close", "Profile Page");

    [Element("NonDisplayedClose", ElementType.Button)]
    [Locator(LocatorType.XPath, "//div[@aria-labelledby='ui-dialog-title-settingsDialog'][contains(@style, 'none')]//ul[@id='settings_tabs']//span[text()='close']")]
    public Button NonDisplayedCloseButton => UIElementFactory.GetElement("NonDisplayedClose", "Profile Page");

    [Element("Old Password", ElementType.TextField)]
    [Locator(LocatorType.Id, "TextPwOld")]
    public TextField OldPassTextField => UIElementFactory.GetElement(elementName: "Old Password", "Profile Page");

    [Element("New Password", ElementType.TextField)]
    [Locator(LocatorType.Id, "TextPwNew")]
    public TextField NewPassTextField => UIElementFactory.GetElement(elementName: "New Password", "Profile Page");
}
