using OpenQA.Selenium;
using SeleniumTest.Core;
using SeleniumTest.Core.Drivers;
using TechTalk.SpecFlow;
using Views.WebAppPages;

namespace SeleniumTest.Tests;

[Binding]
[Scope(Feature = "User Login")]
[TestFixture]
public class LoginChromeTests
{
    private readonly LoginPage _loginPage;
    private readonly ScenarioContext _scenarioContext;

    public LoginChromeTests(ScenarioContext scenarioContext)
    {
        _loginPage = new LoginPage();
        _scenarioContext = scenarioContext;
    }

    [Given(@"the user navigates to the URL")]
    public void GivenTheUserNavigatesToTheURL()
    {
        GenericWebDriver.Instance.Navigate().GoToUrl(ConfigModel.HostUrl);
        IWebElement panelNotAuthDiv = GenericWebDriver.Instance.FindElement(By.Id("ctl00_MainContent_PanelNotAuth"));
        Assert.True(panelNotAuthDiv.Displayed);
    }

    [When(@"the user clicks on Login")]
    public void WhenTheUserClicksOnLogin()
    {
        _loginPage.LoginButton.Click();
        IWebElement loginDiv = GenericWebDriver.Instance.FindElement(By.Id("HPloginDiv"));
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
        IWebElement panelAuthDiv = GenericWebDriver.Instance.FindElement(By.Id("ctl00_MainContent_PanelAuth"));
        Assert.True(panelAuthDiv.Displayed);
    }

    [AfterScenario]
    public void TearDown()
    {
        GenericWebDriver.Dispose();
    }
}

