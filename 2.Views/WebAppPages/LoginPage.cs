﻿using Todoly.Core.Helpers;
using Todoly.Core.UIElements.Commons;
using Todoly.Core.UIElements.Drivers;
using Todoly.Core.UIElements.Enums;
using Todoly.Core.UIElements.Interfaces;
using Todoly.Core.UIElements.Web;
using Todoly.Core.UIElements.WebActions;

namespace Todoly.Views.WebAppPages;

public class LoginPage
{
    public readonly string HostUrl = ConfigModel.HostUrl;
    public readonly string EmailCredentials = ConfigModel.TODO_LY_EMAIL;
    public readonly string PassCredentials = ConfigModel.TODO_LY_PASS;

    public Button LoginButton =>
        new Button("", new Locator(LocatorType.ClassName, "HPHeaderLogin"));

    public TextField EmailTextField =>
        new TextField(
            "",
            new Locator(LocatorType.Id, "ctl00_MainContent_LoginControl1_TextBoxEmail")
        );

    public TextField PasswordTextField =>
        new TextField(
            "",
            new Locator(LocatorType.Id, "ctl00_MainContent_LoginControl1_TextBoxPassword")
        );

    public Button ConfirmLoginButton =>
        new Button("", new Locator(LocatorType.Id, "ctl00_MainContent_LoginControl1_ButtonLogin"));

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
