using DA_Assets.Extensions;
using System.IO;
using System.Text;
using UnityEngine;

public class CandidatesManager : MonoBehaviour
{
    public CandidateListWrapperModel candidateListWrapper;

    private string _savePath;

    void Start()
    {
        candidateListWrapper = new CandidateListWrapperModel();
        _savePath = Application.persistentDataPath + "/Candidates.json";
        Debug.Log(_savePath);
        Load();
    }

    public void Load()
    {
        if (File.Exists(_savePath))
        {
            string json = File.ReadAllText(_savePath);
            Debug.Log(json);
            if (!json.IsEmpty())
            {
                candidateListWrapper.Candidates = JsonUtility.FromJson<CandidateListWrapperModel>(json).Candidates;
            }
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
        candidateListWrapper.Candidates.Add(new CandidateModel("фв", "22.02.2025", "20.01.2000"));
        Save();
    }
    public void SaveCandidate(CandidateModel candidate)
    {
        Debug.Log($"candidateListWrapper {candidateListWrapper == null}");
        Debug.Log($"candidateListWrapper.Candidates {candidateListWrapper.Candidates == null}");
        Debug.Log($"candidate {candidate == null}");
        candidateListWrapper.Candidates.Add(candidate);
        Save();
    }
}
