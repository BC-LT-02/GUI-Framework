using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
using Todoly.Core.UIElements.Drivers;
using Todoly.Tests.UI.Steps.Commons;
using Todoly.Views.WebAppPages;

namespace SeleniumTest.Tests;

[Binding]
[Scope(Feature = "User Login")]
public class LoginStepDefinitions : CommonSteps
{
    private readonly ScenarioContext _scenarioContext;

    public LoginStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given(@"the user navigates to the URL")]
    public void GivenTheUserNavigatesToTheURL()
    {
        GenericWebDriver.Instance.Navigate().GoToUrl(ConfigModel.HostUrl);
    }

    [Then(@"the user should be able to see the '(.*)' button at '(.*)'")]
    public void ThenTheUserShouldBeAbleToSeeTheMainPage(string elementName, string viewName)
    {
        Assert.True(UIElementFactory.GetElement(elementName, viewName).WebElement.Displayed);
        Assert.That(GenericWebDriver.Instance.Title, Is.EqualTo("Todo.ly"));
    }
}
