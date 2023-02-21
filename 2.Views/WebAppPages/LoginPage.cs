using Todoly.Core.Helpers;
using Todoly.Core.UIElements.Commons;
using Todoly.Core.UIElements.Enums;
using Todoly.Core.UIElements.Web;
using Todoly.Core.UIElements.WebActions;
using Todoly.Views.WebAppPages.Attributes;

namespace Todoly.Views.WebAppPages;

[View("Login Page")]
public class LoginPage
{
    public readonly string HostUrl = ConfigModel.HostUrl;
    public readonly string EmailCredentials = ConfigModel.TODO_LY_EMAIL;
    public readonly string PassCredentials = ConfigModel.TODO_LY_PASS;

    [Element("Login", ElementType.Button)]
    [Locator(LocatorType.ClassName, "HPHeaderLogin")]
    public Button LoginButton => UIElementFactory.GetElement("Login", "Login Page");

    [Element("Email", ElementType.TextField)]
    [Locator(LocatorType.Id, "ctl00_MainContent_LoginControl1_TextBoxEmail")]
    public TextField EmailTextField => UIElementFactory.GetElement("Email", "Login Page");

    [Element("Password", ElementType.TextField)]
    [Locator(LocatorType.Id, "ctl00_MainContent_LoginControl1_TextBoxPassword")]
    public TextField PasswordTextField => UIElementFactory.GetElement("Password", "Login Page");

    [Element("Confirm Login", ElementType.Button)]
    [Locator(LocatorType.Id, "ctl00_MainContent_LoginControl1_ButtonLogin")]
    public Button ConfirmLoginButton => UIElementFactory.GetElement("Confirm Login", "Login Page");

    public LoginPage() { }

    public void LoginIntoApplication()
    {
        WebActions.NavigateTo(ConfigModel.HostUrl);
        LoginButton.Click();
        EmailTextField.Type(EmailCredentials);
        PasswordTextField.Type(PassCredentials);
        ConfirmLoginButton.Click();
    }
}
