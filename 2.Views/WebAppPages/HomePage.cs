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

    [Element("Selected Project", ElementType.Button)]
    [Locator(LocatorType.ClassName, "ProjectSelected")]
    public IElement CurrentSelectedProject =>
        new BaseWebElement("", new Locator(LocatorType.ClassName, "ProjectSelected"));

    [Element("Project Button", ElementType.Button)]
    [Locator(LocatorType.XPath, "//div[@id='ProjectListPlaceHolder']//td[text()='{0}']")]
    public Button? ProjectButton { get; }

    [Element("Edit Project", ElementType.Button)]
    [Locator(LocatorType.XPath, "//ul[@id='projectContextMenu']/li[@class='edit']/a")]
    public Button ProjectEditButton =>
        new Button(
            "",
            new Locator(LocatorType.XPath, "//ul[@id='projectContextMenu']/li[@class='edit']/a")
        );

    [Element("Edit Project Input", ElementType.TextField)]
    [Locator(LocatorType.XPath, "(//div[@id='ProjectEditDiv'])[1]/input")]
    public TextField? ProjectEditInput { get; }

    [Element("Save Edit Project", ElementType.Button)]
    [Locator(LocatorType.XPath, "(//div[@id='ProjectEditDiv'])[1]/img[@id='ItemEditSubmit']")]
    public Button? ProjectEditSaveButton { get; }

    [Element("Cancel Edit Project", ElementType.Button)]
    [Locator(LocatorType.XPath, "(//div[@id='ProjectEditDiv'])[1]/img[@id='ItemEditCancel']")]
    public Button? ProjectEditCancelButton { get; }

    [Element("Delete Project", ElementType.Button)]
    [Locator(LocatorType.Id, "ProjShareMenuDel")]
    public Button? ProjectDeleteButton { get; }

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

    [Element("Add New Todo", ElementType.TextField)]
    [Locator(LocatorType.Id, "NewItemContentInput")]
    public TextField AddToDoInput =>
        new TextField("", new Locator(LocatorType.Id, "NewItemContentInput"));

    [Element("Edit Item", ElementType.TextField)]
    [Locator(LocatorType.Id, "ItemEditTextbox")]
    public TextField ItemTextField =>
        new TextField(
            "",
            new Locator(
                LocatorType.XPath,
                "//li[contains(@class, 'BaseItemLi')]//textarea[@id='ItemEditTextbox']"
            )
        );

    public Button SaveItemButton =>
        new Button(
            "",
            new Locator(
                LocatorType.XPath,
                $"//li[contains(@class, 'BaseItemLi')]//img[@id='ItemEditSubmit']"
            )
        );

    public Button CurrentProjectButton =>
        new Button("", new Locator(LocatorType.Id, "CurrentProjectTitle"));

    public Button GetProjectTd(string projectName) =>
        new Button(
            "",
            new Locator(
                LocatorType.XPath,
                $"//div[@id='ProjectListPlaceHolder']//td[text()='{projectName}']"
            )
        );

    public Button GetProjectHandle(string projectName) =>
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

    public Button GetItemDueDateTd(string itemName) =>
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

    public Button ItemButton(string itemName) =>
        new Button(
            "",
            new Locator(
                LocatorType.XPath,
                $"//div[@class='ItemContentDiv' and text()='{itemName}']"
            )
        );

    public Button PostponeSelectButton =>
        new Button(
            "",
            new Locator(
                LocatorType.XPath,
                $"//div[contains(@id, 'EditDueDate') and contains(@style, 'block')]//select[@id='DaySelect']"
            )
        );

    public Button PostponeButton =>
        new Button(
            "",
            new Locator(
                LocatorType.XPath,
                $"//div[contains(@id, 'EditDueDate') and contains(@style, 'block')]//input[@value='Postpone']"
            )
        );

    public Button PostponeXTimeButton(string postponeTime) =>
        new Button(
            "",
            new Locator(
                LocatorType.XPath,
                $"//div[contains(@id, 'EditDueDate') and contains(@style, 'block')]//option[text()='{postponeTime}']"
            )
        );

    public Button ProjectTd(string projectName) =>
        new Button(
            "",
            new Locator(
                LocatorType.XPath,
                $"//div[@id='ProjectListPlaceHolder']//td[text()='{projectName}']"
            )
        );

    public Button GetItemTd(string itemName) =>
        new Button(
            "",
            new Locator(
                LocatorType.XPath,
                $"//div[@class='ItemContentDiv' and text()='{itemName}']"
            )
        );

    public TextField ItemDueDateTextField =>
        new TextField(
            "",
            new Locator(
                LocatorType.XPath,
                "//div[contains(@id, 'EditDueDate') and @itemid]//input[@id='EditDueDateAdvDate']"
            )
        );

    public TextField AddAboveOrBelowTextField =>
        new TextField(
            "",
            new Locator(
                LocatorType.XPath,
                "//ul[contains(@id, 'mainItemList')]//textarea[contains(@id, 'ItemEditTextbox')]"
            )
        );
    public Button ItemDueDateSaveButtonField =>
        new Button(
            "",
            new Locator(
                LocatorType.XPath,
                $"//div[contains(@id, 'EditDueDate') and @itemid]//input[@id='LinkShowDueDateSave']]"
            )
        );

    public Button ItemCheckBox(string itemName) =>
        new Button(
            "",
            new Locator(
                LocatorType.XPath,
                $"//div[contains(@id, 'MainContentArea')]//tbody//td[following-sibling::td/div[contains(text(), '{itemName}')]]//input"
            )
        );

    public Button ItemMenuAddItemAboveButton =>
        new Button(
            "",
            new Locator(
                LocatorType.XPath,
                "//ul[@id='itemContextMenu']/li[@class='add separator']/a"
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

    public Button GetItemColor(string itemName, string itemColor) =>
        new Button(
            "",
            new Locator(
                LocatorType.XPath,
                $"//div[@class='ItemContentDiv' and text()='{itemName}'][contains(@style,'{itemColor}')]"
            )
        );

    public Button ItemDeletedAlert =>
        new Button("", new Locator(LocatorType.XPath, $"//span[@id='InfoMessageText']"));

    public Button NoItemsOnMain =>
        new Button("", new Locator(LocatorType.XPath, $"//div[@class='NoItems']"));

    public Button GetItemByIndex(int index) =>
        new Button(
            "",
            new Locator(LocatorType.XPath, $"//ul[contains(@id, 'mainItemList')]/li[{index}]")
        );
}
