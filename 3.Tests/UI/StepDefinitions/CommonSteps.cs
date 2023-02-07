using SeleniumTest.Core.Interfaces;
using TechTalk.SpecFlow;
using Views.WebAppPages;

namespace SeleniumTest.Tests.Steps.Commons;

[TestFixture]
public class CommonSteps
{
    private readonly IGenericWebDriver _driver;
    private readonly ScenarioContext _scenarioContext;

    public CommonSteps(ScenarioContext scenarioContext, IGenericWebDriver driver)
    {
        _scenarioContext = scenarioContext;
        _driver = driver;
    }

    [Given(@"the user is logged in")]
    public void Login()
    {
        LoginPage loginPage = new LoginPage(_driver);
        loginPage!.LoginIntoApplication();
    }

    [Given(@"the user has an existing project")]
    public void Giventheuserhasanexistingproject()
    {
        _scenarioContext.Pending();
    }

    [Given(@"the user has an existing item")]
    public void Giventheuserhasanexistingitem()
    {
        _scenarioContext.Pending();
    }
}
