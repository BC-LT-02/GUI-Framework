using OpenQA.Selenium;
using SeleniumTest.Core;
using SeleniumTest.Core.Drivers;
﻿using Todoly.Core.Helpers;
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
    public HomePage() { }
}
