using NUnit.Framework.Constraints;
using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
using Todoly.Core.UIElements.Drivers;
using Todoly.Tests.UI.Steps.Commons;
using Todoly.Views.WebAppPages;

namespace Todoly.Tests.UI.Steps.User;

[Binding]
[Scope(Feature = "User Logout")]
public class LogoutStepDefinitions : CommonSteps
{
    private readonly ScenarioContext _scenarioContext;

    public LogoutStepDefinitions(ScenarioContext scenarioContext)
        : base(scenarioContext)
    {
        _scenarioContext = scenarioContext;
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
