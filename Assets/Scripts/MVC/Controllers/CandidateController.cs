using UnityEngine;

public class CandidateController : MonoBehaviour
{
    public CandidateModel Candidate;

    public void RegisterCandidate(string name, string birthDate)
    {
        Candidate = new CandidateModel(name, birthDate, System.DateTime.Now.ToString("dd.MM.yyyy"));
    }

    public void SaveAnswer(int blockNumber, int value)
    {
        switch (blockNumber)
        {
            case 0: Candidate.DAmount += value; break;
            case 1: Candidate.IAmount += value; break;
            case 2: Candidate.SAmount += value; break;
            case 3: Candidate.CAmount += value; break;
        }
    }    
}
