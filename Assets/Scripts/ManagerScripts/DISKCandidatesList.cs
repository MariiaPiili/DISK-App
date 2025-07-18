using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DISKCandidatesList : MonoBehaviour
{
    public Transform Content;
    public GameObject CandidatePrefab;

    public CandidatesManager CandidatesManager;


    public void OnEnable()
    {
        foreach (Candidate candidate in CandidatesManager.candidateListWrapper.Candidates)
        {
            GameObject candidatePrefab = Instantiate(CandidatePrefab, Content);
            Debug.Log(candidate.DateOfTesting);
            candidatePrefab.GetComponent<CandidatesCard>().Init(candidate.CandidateName, candidate.ResultLetter, candidate.DateOfTesting);
        }
    }


}
