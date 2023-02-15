using TechTalk.SpecFlow;
using Todoly.Core.Helpers;
using Todoly.Tests.UI.Steps.Commons;
using Todoly.Views.WebAppPages;

namespace SeleniumTest.Tests;

[Binding]
[Scope(Feature = "Profile settings view")]
public class ViewProfileStepDefinition : CommonSteps
{
    private readonly HomePage _homePage;
    private ProfilePage? _profilePage;
    private readonly ScenarioContext _scenarioContext;
    public ViewProfileStepDefinition(ScenarioContext scenarioContext) : base(scenarioContext)
    {
        _homePage = new HomePage();
        _scenarioContext = scenarioContext;
    }

    [When(@"the user clicks on the Settings option on the Nav Bar")]
    public void WhentheuserclicksontheSettingsoptionontheNavBar()
    {
        _homePage.SettingsButton.Click();
        _profilePage = new ProfilePage();
    }

    [Then(@"the Profile Settings view should be opened")]
    public void ThentheProfileSettingsviewshouldbeopened()
    {
        Assert.True(_profilePage!.CloseButton.WebElement.Displayed);
    }

    [Then(@"the Full Name label and input should be displayed")]
    public void ThentheFullNamelabelandinputshouldbedisplayed()
    {
        Assert.True(_profilePage!.FullNameTextField.WebElement.Displayed);
        string fullname = ConfigBuilder.Instance.GetString("api", "UserFullName");
        Assert.That(_profilePage!.FullNameTextField.WebElement.GetAttribute("value"), Is.EqualTo(fullname));
    }

    [Then(@"the Email label and input should be displayed")]
    public void ThentheEmaillabelandinputshouldbedisplayed()
    {
        Assert.True(_profilePage!.EmailTextField.WebElement.Displayed);
        string email = ConfigBuilder.Instance.GetString("TODO-LY-EMAIL");
        Assert.That(_profilePage!.EmailTextField.WebElement.GetAttribute("value"), Is.EqualTo(email));
    }

    [Then(@"the Old Password label and input should be displayed")]
    public void ThentheOldPasswordlabelandinputshouldbedisplayed()
    {
        Assert.True(_profilePage!.OldPassTextField.WebElement.Displayed);
    }

    [Then(@"the New Password label and input should be displayed")]
    public void ThentheNewPasswordlabelandinputshouldbedisplayed()
    {
        Assert.True(_profilePage!.NewPassTextField.WebElement.Displayed);
    }
}
