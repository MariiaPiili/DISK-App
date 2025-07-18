using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManagerLogin : MonoBehaviour
{
    private const string _adminEmail = "admin.admin@gmail.com";
    private const string _adminPassword = "4321A";

    public TMP_InputField ManagerEmail;
    public TMP_InputField ManagerPassword;
    public Button NextButton;
    public Toggle Visible;
    public TextMeshProUGUI VisiblePasswordText;
    public TextMeshProUGUI InvisiblePasswordText;
    public TextMeshProUGUI MistakeInThePasswordText;

    void Start()
    {
        SetVisible(Visible.isOn);
        NextButton.interactable = false;
        MistakeInThePasswordText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVisible(bool invisible)
    {
        VisiblePasswordText.fontSize = !invisible ? 22 : 0 ;
        InvisiblePasswordText.fontSize = invisible ? 22 : 0;
    }

    public void SetTextPassword(string password) 
    {
        VisiblePasswordText.text = password;
        InvisiblePasswordText.text = new string('*', password.Length);
    }

    public void ActiveButton()
    {
        bool password = ManagerPassword.text == _adminPassword;
        bool email = ManagerEmail.text == _adminEmail;
        NextButton.interactable = password && email;
    }

    public void CkeckPassword()
    {
        MistakeInThePasswordText.gameObject.SetActive(ManagerPassword.text != _adminPassword && ManagerPassword.text.Count() >= 5 );
            
    }
}
