using System;
using System.Collections.Generic;

[Serializable]
public class CandidateListWrapperModel
{
    public List<CandidateModel> Candidates;

    public CandidateListWrapperModel()
    {
        Candidates = new List<CandidateModel>();
    }    
}