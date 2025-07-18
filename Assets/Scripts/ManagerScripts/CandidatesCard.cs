using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CandidatesCard : MonoBehaviour
{
    public TextMeshProUGUI CandidatesName;
    public TextMeshProUGUI CandidatesDominantProfile;
    public TextMeshProUGUI DateOfQuestionnaire;

    public void Init(string candidatesName, string candidatesDominantProfile, string dateOfQuestionnaire)
    {
        CandidatesName.text = candidatesName;
        CandidatesDominantProfile.text = candidatesDominantProfile;
        DateOfQuestionnaire.text = dateOfQuestionnaire;
    }
}
