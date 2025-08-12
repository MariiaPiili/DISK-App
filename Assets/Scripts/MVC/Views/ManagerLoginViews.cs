using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManagerLoginView : MonoBehaviour
{
    public TMP_InputField emailField;
    public TMP_InputField passwordField;
    public Button loginButton;
    public Toggle showPasswordToggle;
    public TextMeshProUGUI visiblePasswordText;
    public TextMeshProUGUI hiddenPasswordText;
    public TextMeshProUGUI errorText;

    public void SetVisible(bool isVisible)
    {
        visiblePasswordText.fontSize = isVisible ? 22 : 0;
        hiddenPasswordText.fontSize = isVisible ? 0 : 22;
    }

    public void SetPassword(string password)
    {
        visiblePasswordText.text = password;
        hiddenPasswordText.text = new string('*', password.Length);
    }

    public void ShowError(bool show)
    {
        errorText.gameObject.SetActive(show);
    }

    public void SetLoginButtonEnabled(bool enabled)
    {
        loginButton.interactable = enabled;
    }
}


