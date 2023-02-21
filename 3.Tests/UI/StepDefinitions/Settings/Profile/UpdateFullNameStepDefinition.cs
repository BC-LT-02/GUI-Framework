using TechTalk.SpecFlow;
using Todoly.Tests.UI.Steps.Commons;
using Todoly.Views.WebAppPages;

namespace SeleniumTest.Tests;

[Binding]
[Scope(Feature = "Full Name update")]
public class UpdateFullNameStepDefinition : CommonSteps
{
    private readonly HomePage _homePage;
    private readonly ScenarioContext _scenarioContext;
    public UpdateFullNameStepDefinition(ScenarioContext scenarioContext) : base(scenarioContext)
    {
        _homePage = new HomePage();
        _scenarioContext = scenarioContext;
    }

    [Then(@"the '(.*)' is updated")]
    public void Thenthefullnameisupdated(string elementName)
    {
        _homePage.SettingsButton.Click();
        Assert.That(UIElementFactory.GetElement(elementName, CurrentView).WebElement.GetAttribute("value"), Is.EqualTo("New Name"));
    }
}
