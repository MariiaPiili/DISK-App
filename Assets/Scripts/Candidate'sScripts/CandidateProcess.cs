using UnityEngine;

public class CandidateProcess : MonoBehaviour
{
    public Candidate Candidate;

    public void SaveResult(int blockNumber, int answerResult)
    {
        switch (blockNumber)
        {
            case 0:
                Candidate.DAmount += answerResult;
                break;
            case 1:
                Candidate.IAmount += answerResult;
                break;
            case 2:
                Candidate.SAmount += answerResult;
                break;
            case 3:
                Candidate.CAmount += answerResult;
                break;
        }
    }
}
