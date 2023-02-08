using OpenQA.Selenium;
using SeleniumTest.Core.Drivers;
using SeleniumTest.Core.Interfaces;
using SeleniumTest.Tests.Steps.Commons;
using TechTalk.SpecFlow;
using Views.WebAppPages;

namespace SeleniumTest.Tests;

[Binding]
[Scope(Feature = "Full Name update")]
[TestFixture]
public class UpdateFullNameStepDefinition : CommonSteps
{
    private readonly ProfilePage _profile;
    private readonly IGenericWebDriver _driver;
    private readonly ScenarioContext _scenarioContext;

    public UpdateFullNameStepDefinition(ScenarioContext scenarioContext, ChromeWebDriver driver) : base(scenarioContext, driver)
    {
        _scenarioContext = scenarioContext;
        _driver = driver;
        _profile = new ProfilePage(driver);
    }

    [Given(@"the user clicks on the Settings option on the Nav Bar")]
    public void GiventheuserclicksontheSettingsoptionontheNavBar()
    {
        _profile.Settings.Click();
        IWebElement settingsDialog = _driver.Instance().FindElement(By.XPath("//div[@id='settingsDialog']"));
        Assert.True(settingsDialog.Displayed);
    }

    [When(@"the user clicks on the Full Name input")]
    public void WhentheuserclicksontheFullNameinput()
    {
        _profile.FullNameTextField.Clear();
    }

    [Given(@"inputs a new valid full name ""(.*)""")]
    public void Giveninputsanewvalidfullname(string newFullName)
    {
        _profile.FullNameTextField.Type(newFullName);
    }

    [Given(@"clicks on the OK button")]
    public void GivenclicksontheOKbutton()
    {
        _profile.OkButton.Click();
    }

    [Then(@"the full name is updated")]
    public void Thenthefullnameisupdated()
    {
        _scenarioContext.Pending();
    }

    [Given(@"the settings view is closed")]
    public void Giventhesettingsviewisclosed()
    {
        _scenarioContext.Pending();
    }

    [TearDown]
    public void TearDown()
    {
        _driver!.Dispose();
    }
}
