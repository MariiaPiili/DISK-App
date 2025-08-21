using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CandidatesListController : MonoBehaviour
{
    public Transform Content;
    public GameObject CandidatePrefab;

    public CandidatesManager CandidatesManager;
    public HomePageController DISCManagerHomePage;
    public WindowManager WindowManager; 

    private List<GameObject> spawnPrefabCandidates = new List<GameObject>();

    public void OnEnable()
    {
        DeleteAllCandidatesFromScene();

        foreach (CandidateModel candidate in CandidatesManager.candidateListWrapper.Candidates)
        {
            GameObject candidatePrefab = Instantiate(CandidatePrefab, Content);
            Debug.Log(candidate.DateOfTesting);
            candidatePrefab.GetComponent<CandidatesCard>().Init(candidate.CandidateName, candidate.ResultLetter, candidate.DateOfTesting);
            spawnPrefabCandidates.Add(candidatePrefab);

            candidatePrefab.GetComponent<ItemCandidateContoller>().Init(candidate, DISCManagerHomePage,WindowManager);
        }
    }

    public void DeleteAllCandidatesFromScene()
    {
        for (int i = 0; i < spawnPrefabCandidates.Count; i++)
        {
            Destroy(spawnPrefabCandidates[i]);
        }
        spawnPrefabCandidates.Clear();
    }

    public void OnDisable()
    {
        DeleteAllCandidatesFromScene();
    }

    public void Sort(string value)
    {
        DeleteAllCandidatesFromScene();
        List<CandidateModel> candidates = new List<CandidateModel>();
        for (int i = 0; i < CandidatesManager.candidateListWrapper.Candidates.Count; i++)
        {
            if (CandidatesManager.candidateListWrapper.Candidates[i].ResultLetter.Trim() != "")
            {
                if (CandidatesManager.candidateListWrapper.Candidates[i].ResultLetter.First() == Convert.ToChar(value))
                {
                    candidates.Add(CandidatesManager.candidateListWrapper.Candidates[i]);
                }
            }
        }

        foreach (CandidateModel candidate in candidates)
        {
            GameObject candidatePrefab = Instantiate(CandidatePrefab, Content);
            Debug.Log(candidate.DateOfTesting);
            candidatePrefab.GetComponent<CandidatesCard>().Init(candidate.CandidateName, candidate.ResultLetter, candidate.DateOfTesting);
            spawnPrefabCandidates.Add(candidatePrefab);

            //candidatePrefab.GetComponent<ItemCandidate>().Candidate = candidate;
            //candidatePrefab.GetComponent<ItemCandidate>().DISCManagerHomePage = DISCManagerHomePage;
            candidatePrefab.GetComponent<ItemCandidateContoller>().Init(candidate, DISCManagerHomePage, WindowManager);
        }
    }

}
