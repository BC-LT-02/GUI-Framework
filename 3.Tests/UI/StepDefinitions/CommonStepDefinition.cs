using TechTalk.SpecFlow;
using Todoly.Core.UIElements.Drivers;
using Todoly.Views.WebAppPages;

namespace Todoly.Tests.UI.Steps.Commons;

public class CommonSteps
{
    private readonly ScenarioContext _scenarioContext;

    public CommonSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given(@"the user is logged in")]
    public void Login()
    {
        LoginPage loginPage = new LoginPage();
        loginPage!.LoginIntoApplication();
    }
}
