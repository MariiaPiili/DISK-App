using UnityEngine;

public class HomePageController : MonoBehaviour
{
    public CandidateModel CandidateModel;

    public HomePageView HomePageView;

    public void Init(CandidateModel candidate)
    {
        CandidateModel = candidate;
    }

    public void OnEnable()
    {
        HomePageView.Init(CandidateModel);
    }
}
