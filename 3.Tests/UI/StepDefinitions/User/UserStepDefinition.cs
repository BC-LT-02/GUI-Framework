using NUnit.Framework.Constraints;
using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
using Todoly.Core.UIElements.Drivers;
using Todoly.Tests.UI.Steps.Commons;
using Todoly.Views.WebAppPages;

namespace SeleniumTest.Tests;

[Binding]
[Scope(Feature = "User")]
public class UserStepDefinitions : CommonSteps
{
    private readonly ScenarioContext _scenarioContext;

    public UserStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
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

    [Then(@"the user should be logged out from the site")]
    public void Thentheusershouldbeloggedoutfromthesite()
    {
        var currentUrl = GenericWebDriver.Instance.Url;
        var currentTitle = GenericWebDriver.Instance.Title;

        Assert.That(currentUrl, new EqualConstraint(ConfigModel.HostUrl));
        Assert.That(currentTitle, new EqualConstraint("Todo.ly Simple Todo List"));
    }
}
