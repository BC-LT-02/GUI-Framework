using OpenQA.Selenium;
using SeleniumTest.Core.Drivers;
using SeleniumTest.Core.Interfaces;
using TechTalk.SpecFlow;
using Views.WebAppPages;

namespace SeleniumTest.Tests;

[Binding]
[Scope(Feature = "User Login")]
[TestFixture]
public class LoginChromeTests
{
    private readonly LoginPage _loginPage;
    private readonly IGenericWebDriver _driver;
    private readonly ScenarioContext _scenarioContext;

    public LoginChromeTests(ScenarioContext scenarioContext, ChromeWebDriver driver)
    {
        _scenarioContext = scenarioContext;
        _driver = driver;
        _loginPage = new LoginPage(_driver);
    }

    [Given(@"the user navigates to the URL")]
    public void GivenTheUserNavigatesToTheURL()
    {
        IWebElement panelNotAuthDiv = _driver.Instance().FindElement(By.Id("ctl00_MainContent_PanelNotAuth"));
        Assert.True(panelNotAuthDiv.Displayed);
    }

    [When(@"the user clicks on Login")]
    public void WhenTheUserClicksOnLogin()
    {
        _loginPage.LoginButton.Click();
        IWebElement loginDiv = _driver.Instance().FindElement(By.Id("HPloginDiv"));
        Assert.True(loginDiv.Displayed);
    }

    [When(@"introduces his credentials")]
    public void WhenIntroducesHisCredentials()
    {
        _loginPage.EmailTextField.Clear();
        _loginPage.EmailTextField.Type(_loginPage.EmailCredentials);
        _loginPage.PasswordTextField.Clear();
        _loginPage.PasswordTextField.Type(_loginPage.PassCredentials);
    }

    [When(@"clicks on Login button")]
    public void WhenClicksOnLoginButton()
    {
        _loginPage.ConfirmLoginButton.Click();
    }

    [Then(@"the user should be able to see the main page")]
    public void ThenTheUserShouldBeAbleToSeeTheMainPage()
    {
        IWebElement panelAuthDiv = _driver.Instance().FindElement(By.Id("ctl00_MainContent_PanelAuth"));
        Assert.True(panelAuthDiv.Displayed);
    }

    [TearDown]
    public void TearDown()
    {
        _driver!.Dispose();
    }
}

