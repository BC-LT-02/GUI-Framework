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
    public TextField? ProfileSettingsContainer { get; }

    [Element("FullName", ElementType.TextField)]
    [Locator(LocatorType.Id, "FullNameInput")]
    public TextField? FullNameTextField { get; }

    [Element("Email", ElementType.TextField)]
    [Locator(LocatorType.Id, "EmailInput")]
    public TextField? EmailTextField { get; }

    [Element("Ok", ElementType.Button)]
    [Locator(LocatorType.XPath, "//div[@class='ui-dialog-buttonset']//span[text()='Ok']")]
    public Button? OkButton { get; }

    [Element("Close", ElementType.Button)]
    [Locator(LocatorType.XPath, "//div[@aria-labelledby='ui-dialog-title-settingsDialog'][contains(@style, 'block')]//ul[@id='settings_tabs']//span[text()='close']")]
    public Button? CloseButton { get; }

    [Element("NonDisplayedClose", ElementType.Button)]
    [Locator(LocatorType.XPath, "//div[@aria-labelledby='ui-dialog-title-settingsDialog'][contains(@style, 'none')]//ul[@id='settings_tabs']//span[text()='close']")]
    public Button? NonDisplayedCloseButton { get; }

    [Element("Old Password", ElementType.TextField)]
    [Locator(LocatorType.Id, "TextPwOld")]
    public TextField? OldPassTextField { get; }

    [Element("New Password", ElementType.TextField)]
    [Locator(LocatorType.Id, "TextPwNew")]
    public TextField? NewPassTextField { get; }

    [Element("Time Zone", ElementType.Button)]
    [Locator(LocatorType.Id, "DropDownTimezone")]
    public Button? TimeZoneOption { get; }

    [Element("Hawaiian Time", ElementType.Button)]
    [Locator(LocatorType.XPath, "//select[@id = 'DropDownTimezone']//option[@value='Hawaiian Standard Time']")]
    public Button? HawaiianTimeOption { get; }

    [Element("Default Settings", ElementType.Button)]
    [Locator(LocatorType.XPath, "//ul[@id='settings_tabs']//a[@href='#settings_basicPanel']")]
    public Button? DefaultSettings { get; }

    [Element("General Settings", ElementType.Container)]
    [Locator(LocatorType.XPath, "//div[@id='settings_basicPanel']//div[text()='General Settings']")]
    public Container? GeneralSettingsContainer { get; }

    [Element("Share", ElementType.Button)]
    [Locator(LocatorType.XPath, "//ul[@id='settings_tabs']//a[@href='#settings_sharePanel']")]
    public Button? Share { get; }

    [Element("Projects Shared", ElementType.Container)]
    [Locator(LocatorType.XPath, "//div[@id='settings_sharePanel']//div[text()='Projects Shared with you']")]
    public Container? ProjectsSharedContainer { get; }

    [Element("Pro", ElementType.Button)]
    [Locator(LocatorType.XPath, "//ul[@id='settings_tabs']//a[@href='#settings_ProPanel']")]
    public Button? Pro { get; }

    [Element("Upgrade to Pro", ElementType.Button)]
    [Locator(LocatorType.XPath, "//div[@id='settingsNonPro']//a[@href='/Upgrade']")]
    public Button? UpgradeToProOption { get; }

    [Element("Account", ElementType.Button)]
    [Locator(LocatorType.XPath, "//ul[@id='settings_tabs']/li/a[text()='Account']")]
    public Button AccountTabButton =>
        new Button(
            "",
            new Locator(LocatorType.XPath, "//ul[@id='settings_tabs']/li/a[text()='Account']")
        );

    [Element("Delete Account", ElementType.Button)]
    [Locator(LocatorType.Id, "DeleteAccountBtn")]
    public Button DeleteAccountButton =>
        new Button("", new Locator(LocatorType.Id, "DeleteAccountBtn"));
}
