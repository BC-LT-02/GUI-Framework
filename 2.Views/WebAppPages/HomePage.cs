using Todoly.Core.Helpers;
using Todoly.Core.UIElements.Commons;
using Todoly.Core.UIElements.Enums;
using Todoly.Core.UIElements.Interfaces;
using Todoly.Core.UIElements.Web;

namespace Todoly.Views.WebAppPages;

public class HomePage
{
    public readonly string HostUrl = ConfigModel.HostUrl;
    public IClickable LogoutButton =>
        new Button("", new Locator(LocatorType.Id, "ctl00_HeaderTopControl1_LinkButtonLogout"));
    public IElement ProjectTitleDiv =>
        new Button("", new Locator(LocatorType.Id, "CurrentProjectTitle"));
    public IElement RecycleBinDiv => new Button("", new Locator(LocatorType.Id, "ItemId_-3"));

    public IClickable RecycleBinContextButton =>
        new Button("", new Locator(LocatorType.XPath, "//div[@itemid='-3']/img"));
    public IClickable RecycleBinEmptyButton =>
        new Button("", new Locator(LocatorType.XPath, "//ul[@id='recycleContextMenu']/li/a"));

    public IElement NoItemsDiv => new Button("", new Locator(LocatorType.ClassName, "NoItems"));

    public HomePage()
    {
        //GenericWebDriver.Instance.Navigate().GoToUrl(HostUrl);
    }
}
