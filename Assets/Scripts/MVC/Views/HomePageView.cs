using TMPro;
using UnityEngine;

public class HomePageView : MonoBehaviour
{
    public TextMeshProUGUI CandidateName;
    public TextMeshProUGUI CandidateDateOfBirth;
    public TextMeshProUGUI CandidateDate;
    public TextMeshProUGUI CandidateResultLetter;
    public TextMeshProUGUI CandidateDescription;

    public void Init(CandidateModel candidate)
    {
        CandidateName.text = candidate.CandidateName;
        CandidateDateOfBirth.text = candidate.CandidateDateOfBirth;
        CandidateDate.text = candidate.DateOfTesting;
        CandidateResultLetter.text = candidate.ResultLetter;
        CandidateDescription.text = candidate.ResultGPT;
    }
}