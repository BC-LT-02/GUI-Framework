using SeleniumTest.Core;
using SeleniumTest.Core.Interfaces;
using UIElements.Commons;
using UIElements.Enums;
using UIElements.Interfaces;
using UIElements.Web;

namespace Views.WebAppPages;

public class LoginPage
{
    private readonly IGenericWebDriver _driver;
    public readonly string HostUrl = ConfigModel.HostUrl;
    public readonly string EmailCredentials = ConfigModel.TODO_LY_EMAIL;
    public readonly string PassCredentials = ConfigModel.TODO_LY_PASS;

    public IClickable LoginButton => new Button("", new Locator(LocatorType.ClassName, "HPHeaderLogin"), _driver);

    public ITypeable EmailTextField => new TextField("", new Locator(LocatorType.Id, "ctl00_MainContent_LoginControl1_TextBoxEmail"), _driver);

    public ITypeable PasswordTextField => new TextField("", new Locator(LocatorType.Id, "ctl00_MainContent_LoginControl1_TextBoxPassword"), _driver);

    public IClickable ConfirmLoginButton => new Button("", new Locator(LocatorType.Id, "ctl00_MainContent_LoginControl1_ButtonLogin"), _driver);

    public LoginPage(IGenericWebDriver driver)
    {
        _driver = driver;
        _driver.Instance().Navigate().GoToUrl(HostUrl);
        if (_driver.Instance().Title != "Todo.ly Simple Todo List")
        {
            throw new Exception("You're not in the login page");
        }
    }

    public void LoginIntoApplication()
    {
        LoginButton.Click();
        EmailTextField.Type(EmailCredentials);
        PasswordTextField.Type(PassCredentials);
        ConfirmLoginButton.Click();
    }
}
