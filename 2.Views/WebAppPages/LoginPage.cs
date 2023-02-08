using SeleniumTest.Core;
using SeleniumTest.Core.Drivers;
using UIElements.Commons;
using UIElements.Enums;
using UIElements.Interfaces;
using UIElements.Web;

namespace Views.WebAppPages;

public class LoginPage
{
    public readonly string HostUrl = ConfigModel.HostUrl;
    public readonly string EmailCredentials = ConfigModel.TODO_LY_EMAIL;
    public readonly string PassCredentials = ConfigModel.TODO_LY_PASS;

    public IClickable LoginButton =>
        new Button("", new Locator(LocatorType.ClassName, "HPHeaderLogin"));

    public ITypeable EmailTextField =>
        new TextField(
            "",
            new Locator(LocatorType.Id, "ctl00_MainContent_LoginControl1_TextBoxEmail")
        );

    public ITypeable PasswordTextField =>
        new TextField(
            "",
            new Locator(LocatorType.Id, "ctl00_MainContent_LoginControl1_TextBoxPassword")
        );

    public IClickable ConfirmLoginButton =>
        new Button("", new Locator(LocatorType.Id, "ctl00_MainContent_LoginControl1_ButtonLogin"));

    public LoginPage()
    {
        /*GenericWebDriver.Instance.Navigate().GoToUrl(HostUrl);
        if (GenericWebDriver.Instance.Title != "Todo.ly Simple Todo List")
        {
            throw new Exception("You're not in the login page");
        }
        */
    }

    public void LoginIntoApplication()
    {
        GenericWebDriver.Instance.Navigate().GoToUrl(HostUrl);
        LoginButton.Click();
        EmailTextField.Type(EmailCredentials);
        PasswordTextField.Type(PassCredentials);
        ConfirmLoginButton.Click();
    }
}
