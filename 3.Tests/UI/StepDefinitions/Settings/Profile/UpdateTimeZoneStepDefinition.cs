using TechTalk.SpecFlow;
using Todoly.Tests.UI.Steps.Commons;
using Todoly.Views.WebAppPages;

namespace SeleniumTest.Tests;

[Binding]
[Scope(Feature = "Time Zone update")]
public class UpdateTimeZoneStepDefinition : CommonSteps
{
    private readonly ScenarioContext _scenarioContext;

    public UpdateTimeZoneStepDefinition(ScenarioContext scenarioContext)
        : base(scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Then(@"the time zone is updated")]
    public void Thenthetimezoneisupdated()
    {
        UIElementFactory.GetElement("Settings", "Home Page").Click();
        Assert.That(
            UIElementFactory
                .GetElement("Hawaiian Time", CurrentView)
                .WebElement.GetAttribute("selected"),
            Is.EqualTo("true")
        );
    }
}
