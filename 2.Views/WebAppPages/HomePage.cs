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

    [Element("New Project Name", ElementType.Button)]
    [Locator(LocatorType.Id, "NewProjNameInput")]
    public TextField AddNewProjectInput =>
        new TextField("", new Locator(LocatorType.Id, "NewProjNameInput"));

    [Element("Add New Project Name", ElementType.Button)]
    [Locator(LocatorType.Id, "NewProjNameButton")]
    public Button AddNewProjectNameButton =>
        new Button("", new Locator(LocatorType.Id, "NewProjNameButton"));

    // [Element("Selected Project", ElementType.Button)]
    [Locator(LocatorType.ClassName, "ProjectSelected")]
    public IElement CurrentSelectedProject =>
        new BaseWebElement("", new Locator(LocatorType.ClassName, "ProjectSelected"));

    [Element("Edit Project", ElementType.Button)]
    [Locator(LocatorType.XPath, "//ul[@id='projectContextMenu']/li[@class='edit']/a")]
    public Button ProjectEditButton =>
        new Button(
            "",
            new Locator(LocatorType.XPath, "//ul[@id='projectContextMenu']/li[@class='edit']/a")
        );

    [Element("Edit Project Input", ElementType.TextField)]
    [Locator(LocatorType.XPath, "(//div[@id='ProjectEditDiv'])[1]/input']/li[@class='edit']/a")]
    public TextField ProjectEditInput =>
        new TextField("", new Locator(LocatorType.XPath, "(//div[@id='ProjectEditDiv'])[1]/input"));

    [Element("Save Edit Project", ElementType.Button)]
    [Locator(LocatorType.XPath, "(//div[@id='ProjectEditDiv'])[1]/img[@id='ItemEditSubmit']")]
    public Button ProjectEditSaveButton =>
        new Button(
            "",
            new Locator(
                LocatorType.XPath,
                "(//div[@id='ProjectEditDiv'])[1]/img[@id='ItemEditSubmit']"
            )
        );

    [Element("Cancel Edit Project", ElementType.Button)]
    [Locator(LocatorType.XPath, "(//div[@id='ProjectEditDiv'])[1]/img[@id='ItemEditCancel']")]
    public Button ProjectEditCancelButton =>
        new Button(
            "",
            new Locator(
                LocatorType.XPath,
                "(//div[@id='ProjectEditDiv'])[1]/img[@id='ItemEditCancel']"
            )
        );

    [Element("Delete Project", ElementType.Button)]
    [Locator(LocatorType.Id, "ProjShareMenuDel")]
    public Button ProjectDeleteButton =>
        new Button("", new Locator(LocatorType.Id, "ProjShareMenuDel"));

    [Element("Current Project Title", ElementType.Button)]
    [Locator(LocatorType.Id, "CurrentProjectTitle")]
    public IElement ProjectTitleDiv =>
        new Button("", new Locator(LocatorType.Id, "CurrentProjectTitle"));

    [Element("Add New Item", ElementType.Button)]
    [Locator(LocatorType.Id, "NewItemAddButton")]
    public Button NewItemAddButton =>
        new Button("", new Locator(LocatorType.Id, "NewItemAddButton"));

    [Element("Recycle Bin", ElementType.Button)]
    [Locator(LocatorType.Id, "ItemId_-3")]
    public IElement RecycleBinDiv => new Button("", new Locator(LocatorType.Id, "ItemId_-3"));

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
    public IElement NoItemsDiv => new Button("", new Locator(LocatorType.ClassName, "NoItems"));

    [Element("Information Message", ElementType.Button)]
    [Locator(LocatorType.Id, "InfoMessageText")]
    public IElement InfoMessageText =>
        new Button("", new Locator(LocatorType.Id, "InfoMessageText"));

    [Element("Add New Todo", ElementType.TextField)]
    [Locator(LocatorType.Id, "NewItemContentInput")]
    public TextField AddToDoInput =>
        new TextField("", new Locator(LocatorType.Id, "NewItemContentInput"));

    [Element("Edit Item", ElementType.TextField)]
    [Locator(LocatorType.Id, "ItemEditTextbox")]
    public ITextField ItemTextField =>
        new TextField(
            "",
            new Locator(
                LocatorType.XPath,
                "//li[contains(@class, 'BaseItemLi')]//textarea[@id='ItemEditTextbox']"
            )
        );

    public Button ProjectButton(string projectName) =>
        new Button(
            "",
            new Locator(
                LocatorType.XPath,
                $"//*[@id='MainTable']//tr/td[contains(@class, 'ProjItemContent')][contains(., '{projectName}')]"
            )
        );

    public IElement GetProjectTd(string projectName) =>
        new Button(
            "",
            new Locator(
                LocatorType.XPath,
                $"//div[@id='ProjectListPlaceHolder']//td[text()='{projectName}']"
            )
        );

    public IElement GetProjectHandle(string projectName) =>
        new Button(
            "",
            new Locator(
                LocatorType.XPath,
                $"//div[@id='ProjectListPlaceHolder']//td[text()='{projectName}']/parent::tr/td/img[contains(@class, 'handle')]"
            )
        );

    public Button GetProjectContextButton(string projectName) =>
        new Button(
            "",
            new Locator(
                LocatorType.XPath,
                $"//td[text()='{projectName}']/ancestor::table[@class='ProjItemTable']//img[@title='Options']"
            )
        );

    public Button GetItemDueDateButton(string itemName) =>
        new Button(
            "",
            new Locator(
                LocatorType.XPath,
                $"//div[text()='{itemName}']/ancestor::table[@class='ProjItemTable']//div[contains(@class, 'ItemDueDateInner')]"
            )
        );

    public IElement GetItemDueDateTd(string itemName) =>
        new Button(
            "",
            new Locator(
                LocatorType.XPath,
                $"//div[text()='{itemName}']/ancestor::table[@class='ProjItemTable']//div[contains(@class, 'ItemDueDateInner')]"
            )
        );

    public Button GetItemContextButton(string itemName) =>
        new Button(
            "",
            new Locator(
                LocatorType.XPath,
                $"//div[text()='{itemName}']/ancestor::table[@class='ProjItemTable']//img[@title='Options']"
            )
        );

    public Button ItemDeleteButton =>
        new Button(
            "",
            new Locator(
                LocatorType.XPath,
                "//ul[@id='itemContextMenu']/li[@class='delete separator']/a"
            )
        );

    public Button ItemPriorityButton(string priorityValue) =>
        new Button(
            "",
            new Locator(
                LocatorType.XPath,
                $"//span[@class='PrioFrame' and text()='{priorityValue}']"
            )
        );

    public IClickable ItemButton(string itemName) =>
        new Button(
            "",
            new Locator(
                LocatorType.XPath,
                $"//div[@class='ItemContentDiv' and text()='{itemName}']"
            )
        );

    public IClickable ProjectTd(string projectName) =>
        new Button(
            "",
            new Locator(
                LocatorType.XPath,
                $"//div[@id='ProjectListPlaceHolder']//td[text()='{projectName}']"
            )
        );

    public IElement GetItemTd(string itemName) =>
        new Button(
            "",
            new Locator(
                LocatorType.XPath,
                $"//div[@class='ItemContentDiv' and text()='{itemName}']"
            )
        );

    public ITextField ItemDueDateTextField =>
        new TextField(
            "",
            new Locator(
                LocatorType.XPath,
                "//div[contains(@id, 'EditDueDate') and @itemid]//input[@id='EditDueDateAdvDate']"
            )
        );

    public IClickable ItemDueDateSaveButtonField =>
        new Button(
            "",
            new Locator(
                LocatorType.XPath,
                $"//div[contains(@id, 'EditDueDate') and @itemid]//input[@id='LinkShowDueDateSave']]"
            )
        );

    public IClickable ItemCheckBox(string itemName) =>
        new Button(
            "",
            new Locator(
                LocatorType.XPath,
                $"//div[contains(@id, 'MainContentArea')]//tbody//td[following-sibling::td/div[contains(text(), '{itemName}')]]//input"
            )
        );

    public IElement CheckedItem(string itemName) =>
        new BaseWebElement(
            "",
            new Locator(
                LocatorType.XPath,
                $"//div[contains(@id, 'DoneItemsDiv')]//div[contains(., '{itemName}')][contains(@class, 'DoneItem')]"
            )
        );

    public IElement GetItemColor(string itemName, string itemColor) =>
        new Button(
            "",
            new Locator(
                LocatorType.XPath,
                $"//div[@class='ItemContentDiv' and text()='{itemName}'][contains(@style,'{itemColor}')]"
            )
        );

    public IElement ItemDeletedAlert =>
        new Button("", new Locator(LocatorType.XPath, $"//span[@id='InfoMessageText']"));

    public IElement NoItemsOnMain =>
        new Button("", new Locator(LocatorType.XPath, $"//div[@class='NoItems']"));

    public HomePage() { }
}
