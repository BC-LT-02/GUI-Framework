using TechTalk.SpecFlow;
using Todoly.Tests.UI.Steps.Commons;
using Todoly.Views.WebAppPages;

namespace SeleniumTest.Tests;

[Binding]
[Scope(Feature = "Full Name update")]
public class UpdateFullNameStepDefinition : CommonSteps
{
    private readonly HomePage _homePage;
    private ProfilePage? _profilePage;
    private readonly ScenarioContext _scenarioContext;
    public UpdateFullNameStepDefinition(ScenarioContext scenarioContext) : base(scenarioContext)
    {
        _homePage = new HomePage();
        _scenarioContext = scenarioContext;
    }

    [Given(@"the user clicks on the Settings option on the Nav Bar")]
    public void GiventheuserclicksontheSettingsoptionontheNavBar()
    {
        _homePage.SettingsButton.Click();
        _profilePage = new ProfilePage();
    }

    [When(@"the user inputs a new full name ""(.*)"" on the Full Name input")]
    public void WhentheuserinputsanewfullnameontheFullNameinput(string newFullName)
    {
        _profilePage!.FullNameTextField.Type(newFullName);
    }

    [When(@"clicks on the OK button")]
    public void WhenClicksOnTheOkButton()
    {
        _profilePage!.OkButton.Click();
    }

    [Then(@"the settings view is closed")]
    public void Thenthesettingsviewisclosed()
    {
        Assert.False(_profilePage!.NonDisplayedCloseButton.WebElement.Displayed);
    }

    [Then(@"the full name is updated")]
    public void Thenthefullnameisupdated()
    {
        _homePage.SettingsButton.Click();
        Assert.That(_profilePage!.FullNameTextField.WebElement.GetAttribute("value"), Is.EqualTo("New Name"));
    }
}
