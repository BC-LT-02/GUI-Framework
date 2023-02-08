using OpenQA.Selenium;
using SeleniumTest.Core;
using SeleniumTest.Core.Drivers;
using UIElements.Commons;
using UIElements.Enums;
using UIElements.Interfaces;
using UIElements.Web;

namespace Views.WebAppPages;

public class HomePage
{
    public readonly string HostUrl = ConfigModel.HostUrl;

    public IClickable LogoutButton =>
        new Button("", new Locator(LocatorType.Id, "ctl00_HeaderTopControl1_LinkButtonLogout"));

    public HomePage()
    {
        //GenericWebDriver.Instance.Navigate().GoToUrl(HostUrl);
    }

    //UpdateItemName
    public IClickable ItemButton(string oldItemName) =>
        new Button(
            "",
            new Locator(
                LocatorType.XPath,
                "//div[@class='ItemContentDiv' and text()='" + oldItemName + "']"
            )
        );

    public void ClickListItem(string oldItemName)
    {
        ItemButton(oldItemName).Click();
    }

    public ITypeable EditItemTextField =>
        new TextField("", new Locator(LocatorType.Id, "ItemEditTextbox"));

    public void TypeNewItemName(string itemName)
    {
        EditItemTextField.Clear();
        EditItemTextField.Type(itemName);
        EditItemTextField.Type(Keys.Enter);
    }
}
