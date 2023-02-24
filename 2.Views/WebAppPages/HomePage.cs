using Todoly.Core.Helpers;
using Todoly.Core.UIElements.Commons;
using Todoly.Core.UIElements.Enums;
using Todoly.Core.UIElements.Interfaces;
using Todoly.Core.UIElements.Web;
using Todoly.Views.WebAppPages.Attributes;

namespace Todoly.Views.WebAppPages;

[View("Home Page")]
public class HomePage
{
    public readonly string HostUrl = ConfigModel.HostUrl;

    [Element("Logout", ElementType.Button)]
    [Locator(LocatorType.Id, "ctl00_HeaderTopControl1_LinkButtonLogout")]
    public Button LogoutButton =>
        new Button("", new Locator(LocatorType.Id, "ctl00_HeaderTopControl1_LinkButtonLogout"));

    [Element("Settings", ElementType.Button)]
    [Locator(
        LocatorType.XPath,
        "//div[@id='ctl00_HeaderTopControl1_PanelHeaderButtons']//a[text()='Settings']"
    )]
    public Button SettingsButton =>
        new Button(
            "",
            new Locator(
                LocatorType.XPath,
                "//div[@id='ctl00_HeaderTopControl1_PanelHeaderButtons']//a[text()='Settings']"
            )
        );

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

    [Element("Add New Project", ElementType.Button)]
    [Locator(LocatorType.XPath, "//td[@class='ProjItemContent' and text()='Add New Project']")]
    public Button AddNewProjectButton =>
        new Button(
            "",
            new Locator(
                LocatorType.XPath,
                "//td[@class='ProjItemContent' and text()='Add New Project']"
            )
        );

    [Element("New Project Name", ElementType.TextField)]
    [Locator(LocatorType.Id, "NewProjNameInput")]
    public TextField AddNewProjectInput =>
        new TextField("", new Locator(LocatorType.Id, "NewProjNameInput"));

    [Element("Add New Project Name", ElementType.Button)]
    [Locator(LocatorType.Id, "NewProjNameButton")]
    public Button AddNewProjectNameButton =>
        new Button("", new Locator(LocatorType.Id, "NewProjNameButton"));

    [Element("Current Project Title", ElementType.Button)]
    [Locator(LocatorType.Id, "CurrentProjectTitle")]
    public Button ProjectTitleDiv =>
        new Button("", new Locator(LocatorType.Id, "CurrentProjectTitle"));

    [Element("Add New Item", ElementType.Button)]
    [Locator(LocatorType.Id, "NewItemAddButton")]
    public Button NewItemAddButton =>
        new Button("", new Locator(LocatorType.Id, "NewItemAddButton"));

    [Element("Recycle Bin Div", ElementType.Button)]
    [Locator(LocatorType.Id, "ItemId_-3")]
    public Button RecycleBinDiv => new Button("", new Locator(LocatorType.Id, "ItemId_-3"));

    [Element("Recycle Bin Dropdown", ElementType.Button)]
    [Locator(LocatorType.XPath, "//div[@itemid='-3']/img")]
    public Button RecycleBinContextButton =>
        new Button("", new Locator(LocatorType.XPath, "//div[@itemid='-3']/img"));

    [Element("Empty Recycle Bin", ElementType.Button)]
    [Locator(LocatorType.XPath, "//ul[@id='recycleContextMenu']/li/a")]
    public Button RecycleBinEmptyButton =>
        new Button("", new Locator(LocatorType.XPath, "//ul[@id='recycleContextMenu']/li/a"));

    [Element("No Items", ElementType.Button)]
    [Locator(LocatorType.ClassName, "NoItems")]
    public Button NoItemsDiv => new Button("", new Locator(LocatorType.ClassName, "NoItems"));

    [Element("Information Message", ElementType.Button)]
    [Locator(LocatorType.Id, "InfoMessageText")]
    public Button InfoMessageText => new Button("", new Locator(LocatorType.Id, "InfoMessageText"));
}
