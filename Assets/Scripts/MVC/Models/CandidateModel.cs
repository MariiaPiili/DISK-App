using System;

[Serializable]
public class CandidateModel
{
    public string CandidateName;
    public string CandidateDateOfBirth;
    public string DateOfTesting;
    public string ResultLetter;
    public string ResultGPT;

    public int DAmount;
    public int IAmount;
    public int SAmount;
    public int CAmount;

    public CandidateModel(string candidateName, string candidateDateOfBirth, string dateOfTesting)
    {
        CandidateName = candidateName;
        CandidateDateOfBirth = candidateDateOfBirth;
        DateOfTesting = dateOfTesting;
    }

    public CandidateModel(string candidateName, string candidateDateOfBirth, string dateOfTesting, string resultLetter, string resultGPT, int dAmount, int iAmount, int sAmount, int cAmount)
    {
        CandidateName = candidateName;
        CandidateDateOfBirth = candidateDateOfBirth;
        DateOfTesting = dateOfTesting;
        ResultLetter = resultLetter;
        ResultGPT = resultGPT;
        DAmount = dAmount;
        IAmount = iAmount;
        SAmount = sAmount;
        CAmount = cAmount;
    }

}
