using OpenQA.Selenium;
using Todoly.Core.Helpers;
using Todoly.Core.UIElements.Commons;
using Todoly.Core.UIElements.Enums;
using Todoly.Core.UIElements.Interfaces;
using Todoly.Core.UIElements.Web;

namespace Todoly.Views.WebAppPages;

public class HomePage
{
    public readonly string HostUrl = ConfigModel.HostUrl;
    public Button LogoutButton =>
        new Button("", new Locator(LocatorType.Id, "ctl00_HeaderTopControl1_LinkButtonLogout"));

    public Button SettingsButton => new Button("", new Locator(LocatorType.XPath, "//div[@id='ctl00_HeaderTopControl1_PanelHeaderButtons']//a[text()='Settings']"));

    public Button AddNewProjectButton =>
        new Button("", new Locator(LocatorType.XPath, "//td[@class='ProjItemContent' and text()='Add New Project']"));

    public TextField AddNewProjectInput =>
        new TextField("", new Locator(LocatorType.Id, "NewProjNameInput"));

    public Button AddNewProjectNameButton =>
        new Button("", new Locator(LocatorType.Id, "NewProjNameButton"));

    public IElement CurrentSelectedProject =>
        new BaseWebElement("", new Locator(LocatorType.ClassName, "ProjectSelected"));

    public Button ProjectEditButton =>
        new Button("", new Locator(LocatorType.XPath, "//ul[@id='projectContextMenu']/li[@class='edit']/a"));

    public TextField ProjectEditInput =>
        new TextField("", new Locator(LocatorType.XPath, "(//div[@id='ProjectEditDiv'])[1]/input"));

    public Button ProjectEditSaveButton =>
        new Button("", new Locator(LocatorType.XPath, "(//div[@id='ProjectEditDiv'])[1]/img[@id='ItemEditSubmit']"));

    public Button ProjectEditCancelButton =>
        new Button("", new Locator(LocatorType.XPath, "(//div[@id='ProjectEditDiv'])[1]/img[@id='ItemEditCancel']"));

    public Button ProjectDeleteButton =>
        new Button("", new Locator(LocatorType.Id, "ProjShareMenuDel"));

    public IElement ProjectTitleDiv =>
        new Button("", new Locator(LocatorType.Id, "CurrentProjectTitle"));

    public Button NewItemAddButton =>
        new Button("", new Locator(LocatorType.Id, "NewItemAddButton"));

    public IElement RecycleBinDiv => new Button("", new Locator(LocatorType.Id, "ItemId_-3"));

    public Button RecycleBinContextButton =>
        new Button("", new Locator(LocatorType.XPath, "//div[@itemid='-3']/img"));

    public Button RecycleBinEmptyButton =>
        new Button("", new Locator(LocatorType.XPath, "//ul[@id='recycleContextMenu']/li/a"));

    public IElement NoItemsDiv => new Button("", new Locator(LocatorType.ClassName, "NoItems"));
    public TextField AddToDoInput =>
        new TextField("", new Locator(LocatorType.Id, "NewItemContentInput"));

    public Button ProjectButton(string projectName) =>
        new Button(
            "",
            new Locator(
                LocatorType.XPath,
                $"//*[@id='MainTable']//tr/td[contains(@class, 'ProjItemContent')][contains(., '{projectName}')]"
            )
        );

    public IElement GetProjectTd(string projectName) =>
        new Button("", new Locator(
            LocatorType.XPath,
            $"//div[@id='ProjectListPlaceHolder']//td[text()='{projectName}']"
        )
    );

    public IElement GetProjectHandle(string projectName) =>
        new Button("", new Locator(
            LocatorType.XPath,
            $"//div[@id='ProjectListPlaceHolder']//td[text()='{projectName}']/parent::tr/td/img[contains(@class, 'handle')]"
        )
    );

    public Button GetProjectContextButton(string projectName) =>
        new Button("", new Locator(
            LocatorType.XPath,
            $"//td[text()='{projectName}']/ancestor::table[@class='ProjItemTable']//img[@title='Options']"
        )
    );

    public HomePage() { }
}
