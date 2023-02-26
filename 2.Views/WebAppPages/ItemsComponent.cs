using Todoly.Core.UIElements.Commons;
using Todoly.Core.UIElements.Enums;
using Todoly.Core.UIElements.Interfaces;
using Todoly.Core.UIElements.Web;
using Todoly.Views.WebAppPages.Attributes;

namespace Todoly.Views.WebAppPages;

[View("Items Component")]
public class ItemsComponent
{
    [Element("Item Contextmenu", ElementType.Button)]
    [Locator(LocatorType.XPath, "//ul[@id='itemContextMenu']//*[text()='{0}']")]
    public Button? ItemContextmenu { get; }

    [Element("Get Item", ElementType.Button)]
    [Locator(LocatorType.XPath, "//div[@class='ItemContentDiv' and text()='{0}']")]
    public IClickable? GetItemTd { get; }

    [Element("Item Context Button", ElementType.Button)]
    [Locator(
        LocatorType.XPath,
        "//div[text()='{0}']/ancestor::table[@class='ProjItemTable']//img[@title='Options']"
    )]
    public Button? GetItemContextButton { get; }

    [Element("Edit Item", ElementType.TextField)]
    [Locator(
        LocatorType.XPath,
        "//li[contains(@class, 'BaseItemLi')]//textarea[@id='ItemEditTextbox']"
    )]
    public TextField? ItemTextField { get; }

    [Element("Item Index", ElementType.Button)]
    [Locator(LocatorType.XPath, "//ul[contains(@id, 'mainItemList')]/li[{0}]")]
    public Button? ItemIndex { get; }

    [Element("Item Checkbox", ElementType.Button)]
    [Locator(
        LocatorType.XPath,
        "//div[contains(@id, 'MainContentArea')]//tbody//td[following-sibling::td/div[contains(text(), '{0}')]]//input"
    )]
    public Button? ItemCheckBox { get; }

    [Element("Checked Item", ElementType.Button)]
    [Locator(
        LocatorType.XPath,
        "//div[contains(@id, 'DoneItemsDiv')]//div[contains(., '{0}')][contains(@class, 'DoneItem')]"
    )]
    public IElement? CheckedItem { get; }

    [Element("Add New Todo", ElementType.TextField)]
    [Locator(LocatorType.Id, "NewItemContentInput")]
    public TextField? AddToDoInput { get; }

    [Element("Item Deleted Alert", ElementType.TextField)]
    [Locator(LocatorType.XPath, "//span[@id='InfoMessageText']")]
    public Button? ItemDeletedAlert { get; }

    [Element("No Items", ElementType.TextField)]
    [Locator(LocatorType.XPath, "//div[@class='NoItems']")]
    public Button? NoItemsOnMain { get; }

    [Element("Current Project", ElementType.Button)]
    [Locator(LocatorType.Id, "CurrentProjectTitle")]
    public Button? CurrentProjectButton { get; }

    [Element("Item Color", ElementType.Button)]
    [Locator(LocatorType.XPath, "//div[@class='ItemContentDiv'][contains(@style,'0')]")]
    public Button? GetItemColor { get; }

    [Element("Item DueDate", ElementType.Button)]
    [Locator(
        LocatorType.XPath,
        "//div[text()='{0}']/ancestor::table[@class='ProjItemTable']//div[contains(@class, 'ItemDueDateInner')]"
    )]
    public Button? GetItemDueDateButton { get; }

    [Element("DueDate TextField", ElementType.TextField)]
    [Locator(
        LocatorType.XPath,
        "//div[contains(@id, 'EditDueDate') and @itemid]//input[@id='EditDueDateAdvDate']"
    )]
    public TextField? ItemDueDateTextField { get; }

    [Element("Postpone Select", ElementType.Button)]
    [Locator(
        LocatorType.XPath,
        "//div[contains(@id, 'EditDueDate') and contains(@style, 'block')]//select[@id='DaySelect']"
    )]
    public Button? PostponeSelectButton { get; }

    [Element("Postpone X Time", ElementType.Button)]
    [Locator(
        LocatorType.XPath,
        "//div[contains(@id, 'EditDueDate') and contains(@style, 'block')]//option[text()='{0}']"
    )]
    public Button? PostponeXTimeButton { get; }

    [Element("Postpone Button", ElementType.Button)]
    [Locator(
        LocatorType.XPath,
        "//div[contains(@id, 'EditDueDate') and contains(@style, 'block')]//input[@value='Postpone']"
    )]
    public Button? PostponeButton { get; }

    [Element("Item DueDate Td", ElementType.Button)]
    [Locator(
        LocatorType.XPath,
        "//div[text()='{0}']/ancestor::table[@class='ProjItemTable']//div[contains(@class, 'ItemDueDateInner')]"
    )]
    public Button? GetItemDueDateTd { get; }
}
