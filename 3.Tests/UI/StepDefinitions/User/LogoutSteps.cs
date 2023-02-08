using NUnit.Framework.Constraints;
using SeleniumTest.Core.Drivers;
using SeleniumTest.Tests.Steps.Commons;
using TechTalk.SpecFlow;
using Views.WebAppPages;

namespace SeleniumTest.Tests.Steps.User;

[Binding]
[Scope(Feature = "User Logout")]
public class LogoutStepDefinitions : CommonSteps
{
    private readonly HomePage _homePage;
    private readonly ScenarioContext _scenarioContext;

    public LogoutStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _homePage = new HomePage();
    }

    [AfterScenario]
    public void TearDown()
    {
        GenericWebDriver.Dispose();
    }

    [When(@"the user clicks the logout button")]
    public void Whentheuserclicksthelogoutbutton()
    {
        _homePage.LogoutButton.Click();
    }

    [Then(@"the user should be logged out from the site")]
    public void Thentheusershouldbeloggedoutfromthesite()
    {
        var currentUrl = GenericWebDriver.Instance.Url;
        var currentTitle = GenericWebDriver.Instance.Title;

        Assert.That(currentUrl, new EqualConstraint("https://todo.ly/"));
        Assert.That(currentTitle, new EqualConstraint("Todo.ly Simple Todo List"));
    }
}
