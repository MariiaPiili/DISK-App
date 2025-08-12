using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginController : MonoBehaviour
{
    public ManagerLoginView loginView;

    private const string _adminEmail = "admin.admin@gmail.com";
    private const string _adminPassword = "4321A";

    private void Start()
    {
        loginView.SetVisible(loginView.showPasswordToggle.isOn);
        loginView.SetLoginButtonEnabled(false);
        loginView.ShowError(false);
    }

    public void OnPasswordChanged()
    {
        string password = loginView.passwordField.text;
        loginView.SetPassword(password);
        loginView.SetLoginButtonEnabled(IsLoginValid());
        loginView.ShowError(password.Length >= 5 && password != _adminPassword);
    }

    public void OnEmailChanged()
    {
        loginView.SetLoginButtonEnabled(IsLoginValid());
    }

    private bool IsLoginValid()
    {
        return loginView.emailField.text == _adminEmail &&
               loginView.passwordField.text == _adminPassword;
    }
}

