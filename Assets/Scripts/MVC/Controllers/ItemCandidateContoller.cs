using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCandidateContoller : MonoBehaviour
{
    public HomePageController DISCManagerHomePage;
    public CandidateModel Candidate;
    public WindowManager WindowManager;

    public void Init(CandidateModel candidate, HomePageController dISCManagerHomePage, WindowManager windowManager)
    {
        Candidate = candidate;
        DISCManagerHomePage = dISCManagerHomePage;
        WindowManager = windowManager;
    }
    public void OnClick()
    {      
        DISCManagerHomePage.Init(Candidate);
        WindowManager.NextScreen();
    }
}
