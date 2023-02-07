using OpenQA.Selenium;
using SeleniumTest.Core;
using SeleniumTest.Core.Interfaces;

public class LoginPage
{
    private readonly IGenericWebDriver _driver;
    public readonly string HostUrl = ConfigModel.HostUrl;
    public readonly string EmailCredentials = ConfigModel.TODO_LY_EMAIL;
    public readonly string PassCredentials = ConfigModel.TODO_LY_PASS;

    public readonly string LoginButtonClass = "HPHeaderLogin";
    public readonly string EmailInputId = "ctl00_MainContent_LoginControl1_TextBoxEmail";
    public readonly string PassInputId = "ctl00_MainContent_LoginControl1_TextBoxPassword";
    public readonly string LoginInputId = "ctl00_MainContent_LoginControl1_ButtonLogin";

    public LoginPage(IGenericWebDriver driver)
    {
        _driver = driver;
    }

    public void LoginIntoApplication()
    {
        _driver.Instance().Navigate().GoToUrl(HostUrl);

        var loginButton = _driver.Instance().FindElement(By.ClassName(LoginButtonClass));
        loginButton.Click();

        var emailInput = _driver.Instance().FindElement(By.Id(EmailInputId));
        emailInput.SendKeys(EmailCredentials);

        var passInput = _driver.Instance().FindElement(By.Id(PassInputId));
        passInput.SendKeys(PassCredentials);

        var loginInput = _driver.Instance().FindElement(By.Id(LoginInputId));
        loginInput.Click();
    }
}
