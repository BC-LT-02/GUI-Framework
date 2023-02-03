using OpenQA.Selenium;
using SeleniumTest.Core.Drivers;
using SeleniumTest.Core.Interfaces;

namespace SeleniumTest.Tests;

[Collection("Selenium")]
public class LoginChromeTests : IClassFixture<ChromeWebDriver>
{
    private readonly IGenericWebDriver _driver;
    private readonly ITestOutputHelper _outputHelper;
    private readonly LoginPage _loginPage;

    public LoginChromeTests(ChromeWebDriver driver, ITestOutputHelper output)
    {
        _driver = driver;
        _outputHelper = output;
        _loginPage = new LoginPage(_driver);
    }

    [Fact]
    public void TestLoginUsingChromeWebDriver()
    {
        _loginPage.LoginIntoApplication();
        string expectedDivElementId = "ctl00_MainContent_PanelAuth";
        var expectedDivElement = _driver.Instance().FindElement(By.Id(expectedDivElementId));

        Assert.True(expectedDivElement.Displayed, "The expected element wasn't displayed/found");
    }
}
