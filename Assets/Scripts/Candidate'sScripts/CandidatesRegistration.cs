using DA_Assets.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CandidatesRegistration : MonoBehaviour
{
    public TMP_InputField Name;
    public TMP_InputField DateOfBirth;

    public Button CreateAccountBtn;

    public CandidateProcess CandidateProcess;

    private void Start()
    {
        CreateAccountBtn.interactable = false;
        CandidateProcess = FindObjectOfType<CandidateProcess>();
    }

    public void SetInteractable()
    {
        bool checkName = !Name.text.Trim().IsEmpty();
        bool checkDatOfBirth = IsValidRealBirthdate(DateOfBirth.text);

        CreateAccountBtn.interactable = checkName & checkDatOfBirth;
    }

    private bool IsValidRealBirthdate(string dateString)
    {
        
        try
        {
            DateTime.ParseExact(dateString, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }

    public void Registration()
    {
        CandidateProcess.Candidate = new Candidate(Name.text, DateOfBirth.text, DateTime.Now.Date.ToString("dd.MM.yyyy"));
    }

}
