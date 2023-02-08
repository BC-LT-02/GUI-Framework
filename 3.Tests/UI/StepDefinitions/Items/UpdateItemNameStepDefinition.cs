using OpenQA.Selenium;
using SeleniumTest.Tests.Steps.Commons;
using TechTalk.SpecFlow;
using Views.WebAppPages;
using SeleniumTest.Core.Drivers;

namespace SeleniumTest.Tests.Steps.Items;

[Binding]
[Scope(Feature = "Item Name")]
[TestFixture]
public class UpdateItemNameStepDefinitions : CommonSteps
{
    private readonly HomePage _homePage;
    private readonly ScenarioContext _scenarioContext;

    public UpdateItemNameStepDefinitions(ScenarioContext scenarioContext)
        : base(scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _homePage = new HomePage();
    }

    [AfterScenario]
    public void TearDown()
    {
        GenericWebDriver.Dispose();
    }

    [When(@"the user clicks on ""(.*)"" item in the main items section")]
    public void Whentheuserclicksonaniteminthemainitemssection(string oldItemName)
    {
        string _oldItemName = oldItemName;
        _homePage.ClickListItem(_oldItemName);
    }

    [When(@"the user types ""(.*)"" as item name")]
    public void GiventheusertypesItemNameasitemname(string itemName)
    {
        string _itemName = itemName;
        _homePage.TypeNewItemName(_itemName);
    }

    [Then(@"the item should be updated to be ""(.*)""")]
    public void ThentheitemshouldbeupdatedtobeItemName(string itemName)
    {
        string _itemName = itemName;
        var xpath = "//div[@class='ItemContentDiv' and text()='" + _itemName + "']";
        var newItem = GenericWebDriver.Instance.FindElement(By.XPath(xpath));
        Assert.True(newItem.Displayed);
    }
}
