using DA_Assets.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RegistrationController : MonoBehaviour
{
    public TMP_InputField NameField;
    public TMP_InputField BirthDateField;

    public Button CreateButton;

    public CandidateController CandidateController;

    private void Start()
    {
        CreateButton.interactable = false;
        CandidateController = FindObjectOfType<CandidateController>();
    }

    public void SetInteractable()
    {
        CreateButton.interactable = !string.IsNullOrWhiteSpace(NameField.text)
            && System.DateTime.TryParseExact(BirthDateField.text, "dd.MM.yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out _);
    }

    public void Register()
    {
        CandidateController.RegisterCandidate(NameField.text, BirthDateField.text);
    }
}
