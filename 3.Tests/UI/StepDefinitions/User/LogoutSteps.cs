using OpenQA.Selenium;
using SeleniumTest.Core.Drivers;
using SeleniumTest.Core.Interfaces;
using SeleniumTest.Tests.Steps.Commons;
using TechTalk.SpecFlow;
using Views.WebAppPages;

namespace SeleniumTest.Tests.Steps.User;

[Binding]
[Scope(Feature = "User Logout")]
public class LogoutStepDefinitions : CommonSteps
{
    private readonly HomePage _homePage;
    private readonly IGenericWebDriver _driver;
    private readonly ScenarioContext _scenarioContext;

    public LogoutStepDefinitions(ScenarioContext scenarioContext, ChromeWebDriver driver)
        : base(scenarioContext, driver)
    {
        _scenarioContext = scenarioContext;
        _driver = driver;
        _homePage = new HomePage(_driver);
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Dispose();
    }

    [When(@"the user clicks the logout button")]
    public void Whentheuserclicksthelogoutbutton()
    {
        _homePage.LogoutOffTheApplication();
    }

    [Then(@"the user should be logged out from the site")]
    public void Thentheusershouldbeloggedoutfromthesite()
    {
        var div = _driver.Instance().FindElement(By.Id("ctl00_MainContent_PanelNotAuth"));
        Assert.True(div.Displayed, "The user is not on the log in page");
    }
}
