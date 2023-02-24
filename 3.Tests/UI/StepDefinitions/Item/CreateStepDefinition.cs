﻿using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
using Todoly.Core.UIElements.Drivers;
using Todoly.Core.UIElements.WebActions;
using Todoly.Tests.UI.Steps.Commons;
using Todoly.Views.WebAppPages;

namespace CreateItemTest;

[Binding]
[Scope(Feature = "Create an Item in a Project")]
public class CreateStepDefinitions : CommonSteps
{
    private readonly ScenarioContext _scenarioContext;
    private string _expectedItemName = "";

    public CreateStepDefinitions(ScenarioContext scenarioContext)
        : base(scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [When(@"enters the item ""(.*)"" on Add New Todo input")]
    public void Whentheuserclicks(string itemName)
    {
        _expectedItemName = itemName;
        UIElementFactory.GetElement("Add New Todo", "Items Component").Type(itemName);
        UIElementFactory.GetElement("Add New Todo", "Items Component").Type(Keys.Enter);
    }

    [Then(@"the item should be displayed in the project list")]
    public void Thentheitemshouldbedisplayedintheprojectlist()
    {
        string xPathItem =
            $"//tr//div[contains(., '{_expectedItemName}')][contains(@class, 'ItemContentDiv')]";
        var itemName = GenericWebDriver.Instance.FindElement(By.XPath(xPathItem));
        Assert.That(itemName.Text, Is.EqualTo(_expectedItemName));
    }
}
