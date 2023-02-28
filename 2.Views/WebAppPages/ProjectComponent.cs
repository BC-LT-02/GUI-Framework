using Todoly.Core.UIElements.Commons;
using Todoly.Core.UIElements.Enums;
using Todoly.Core.UIElements.Interfaces;
using Todoly.Core.UIElements.Web;
using Todoly.Views.WebAppPages.Attributes;

namespace Todoly.Views.WebAppPages;

[View("Project Component")]
public class ProjectComponent
{
    [Element("Selected Project", ElementType.Button)]
    [Locator(LocatorType.ClassName, "ProjectSelected")]
    public BaseWebElement? CurrentSelectedProject { get; }

    [Element("Project Button", ElementType.Button)]
    [Locator(LocatorType.XPath, "//div[@id='ProjectListPlaceHolder']//td[text()='{0}']")]
    public IClickable? ProjectButton { get; }

    [Element("Project Handle", ElementType.Button)]
    [Locator(
        LocatorType.XPath,
        "//div[@id='ProjectListPlaceHolder']//td[text()='{0}']/parent::tr/td/img[contains(@class, 'handle')]"
    )]
    public Button? ProjectHandle { get; }

    [Element("Project With Shopping Bag Image", ElementType.Button)]
    [Locator(LocatorType.XPath, "//div[@style='background: url(Images/icons/cart2.png) no-repeat;']")]
    public Button? ProjectShoppingBag { get; }

    [Element("Project Context Button", ElementType.Button)]
    [Locator(
        LocatorType.XPath,
        "//td[text()='{0}']/ancestor::table[@class='ProjItemTable']//img[@title='Options']"
    )]
    public Button? ProjectContextButton { get; }

    [Element("Context Menu Buttons", ElementType.Button)]
    [Locator(LocatorType.XPath, "//ul[@id='projectContextMenu']/li[@class='{0}']/a")]
    public Button? ProjectEditButton { get; }

    [Element("Shopping Bag Image", ElementType.Button)]
    [Locator(LocatorType.XPath, "(//span[@iconid='14'])[1]")]
    public Button? ShoppingBagImage { get; }

    [Element("Edit Project Input", ElementType.TextField)]
    [Locator(LocatorType.XPath, "(//div[@id='ProjectEditDiv'])[1]/input")]
    public TextField? ProjectEditInput { get; }

    [Element("Save Edit Project", ElementType.Button)]
    [Locator(LocatorType.XPath, "(//div[@id='ProjectEditDiv'])[1]/img[@id='ItemEditSubmit']")]
    public Button? ProjectEditSaveButton { get; }

    [Element("Cancel Edit Project", ElementType.Button)]
    [Locator(LocatorType.XPath, "(//div[@id='ProjectEditDiv'])[1]/img[@id='ItemEditCancel']")]
    public Button? ProjectEditCancelButton { get; }

    [Element("Project Images", ElementType.Button)]
    [Locator(LocatorType.XPath, "(//div[@id='IconFrameOuter'])[1]/span[@iconid='{0}']")]
    public Button? ProjectImages { get; }

    [Element("Second Project", ElementType.Button)]
    [Locator(LocatorType.XPath, "(//div[@id='ProjectListPlaceHolder']//li)[2]//td[text()='{0}']")]
    public Button? SecondProject { get; }

    [Element("Child Project", ElementType.Button)]
    [Locator(LocatorType.XPath, "//ul[@class='list projectList']//td[text()='{0}']")]
    public Button? ChildProject { get; }
}
