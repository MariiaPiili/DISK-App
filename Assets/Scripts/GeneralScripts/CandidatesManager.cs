using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class CandidatesManager : MonoBehaviour
{
    public CandidateListWrapper candidateListWrapper;

    private string _savePath;

    void Start()
    {
        candidateListWrapper = new CandidateListWrapper();
        _savePath = Application.persistentDataPath + "/Candidates.json";
        Debug.Log(_savePath);
        Load();
    }

    public void Load()
    {
        if (File.Exists(_savePath))
        {
            string json = File.ReadAllText(_savePath);
            candidateListWrapper.Candidates = JsonUtility.FromJson<CandidateListWrapper>(json).Candidates;
        }
        else
        {
            string fullPath = _savePath;
            using (FileStream stream = File.Create(fullPath)) // Используем using для автоматического закрытия потока
            {
                byte[] bytes = Encoding.UTF8.GetBytes(""); // Преобразуем строку в байты
                stream.Write(bytes, 0, bytes.Length); // Записываем байты в файл
            }
        }
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(candidateListWrapper, true);
        Debug.Log(json);
        File.WriteAllText(_savePath, json);
    }

    [ContextMenu("gogogogogo")]
    public void SaveCandidate()
    {
        candidateListWrapper.Candidates.Add(new Candidate("фв","22.02.2025","20.01.2000"));
        Save();
    }
    public void SaveCandidate(Candidate candidate)
    {
        candidateListWrapper.Candidates.Add(candidate);
        Save();
    }
}
[Serializable]
public class CandidateListWrapper
{
    public List<Candidate> Candidates;
}