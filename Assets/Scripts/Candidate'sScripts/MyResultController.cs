using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyResultController : MonoBehaviour
{
    public CandidateProcess CandidateProcess;
    public CandidatesManager CandidatesManager;

    public Slider ProgressBlockD;
    public Slider ProgressBlockI;
    public Slider ProgressBlockS;
    public Slider ProgressBlockC;

    public TextMeshProUGUI ProgressTextBlockD;
    public TextMeshProUGUI ProgressTextBlockI;
    public TextMeshProUGUI ProgressTextBlockS;
    public TextMeshProUGUI ProgressTextBlockC;
    public TextMeshProUGUI DescriptionTextChatGpt;

    public Sprite PriorityColorSprite;
    public Sprite OrdinaryColorSprite;

    public Image DResultImage;
    public Image IResultImage;
    public Image SResultImage;
    public Image CResultImage;

    public TextMeshProUGUI MaxResultBlock;

    public Button ReadyTextButton;

    private async void OnEnable()
    {
        ReadyTextButton.interactable = false;
        float maxBlockResult = 125f;
        float minBlockResult = 25f;
        int indexBlock = -1;
        int maxAmount = 0;
        Image maxBackground = null;

        Candidate candidate = CandidateProcess.Candidate;

        List<int> amounts = new List<int>() { candidate.DAmount, candidate.IAmount, candidate.SAmount, candidate.CAmount };
        List<Slider> progressBlocks = new List<Slider>() { ProgressBlockD, ProgressBlockI, ProgressBlockS, ProgressBlockC };
        List<TextMeshProUGUI> progressText = new List<TextMeshProUGUI>() { ProgressTextBlockD, ProgressTextBlockI, ProgressTextBlockS, ProgressTextBlockC };
        List<Image> backgrounds = new List<Image>() { DResultImage, IResultImage, SResultImage, CResultImage };

        for (int i = 0; i < amounts.Count; i++)
        {
            progressBlocks[i].value = (amounts[i] - minBlockResult) / (maxBlockResult - minBlockResult);
            progressText[i].text = amounts[i].ToString();
            backgrounds[i].sprite = OrdinaryColorSprite;
            if (amounts[i] > maxAmount)
            {
                indexBlock = i;
                maxAmount = amounts[i];
                maxBackground = backgrounds[i];
            }
        }
        maxBackground.sprite = PriorityColorSprite;

        switch (indexBlock)
        {
            case 0:
                MaxResultBlock.text = "D - domonanssi";
                break;
            case 1:
                MaxResultBlock.text = "I – Vaikuttaminen";
                break;
            case 2:
                MaxResultBlock.text = "S – Vakaa tyyli";
                break;
            case 3:
                MaxResultBlock.text = "C – Tunnollisuus";
                break;
        }

        string answerGpt = await ChatGPTIntegration.SendChatGPTRequest($"D = {amounts[0]}, I = {amounts[1]}, S = {amounts[2]}" +
            $", C = {amounts[3]}. Sinä olet henkilöstöpäällikkö, jolla on psykologinen koulutus. Arvioit ehdokasta DISC-mallin mukaisesti hänen vastattuaan 100 kysymykseen (25 kysymystä neljässä lohkossa: D, I, S ja C). Jokaisen lohkon pistemäärä vaihtelee välillä 25–125. Analysoi hänen tyyliään aloittaen aina vahvimmasta tyypistä (D, I, S, tai C) ja etene seuraaviin vahvuusjärjestyksessä. Älä mainitse pistemääriä. Kirjoita rakentava ja ammatillinen kuvaus, joka sopii sekä ehdokkaalle että esihenkilölle. Luo selkeä kokonaiskuva ehdokkaasta työntekijänä: kuinka hän toimii, mitä tuo tiimiin ja millaisessa ympäristössä toimii parhaiten. Käytä kunnioittavaa ja myönteistä sävyä. Pituus enintään 550 merkkiä.");
        if (answerGpt != null)
        {
            DescriptionTextChatGpt.text = answerGpt;
            ReadyTextButton.interactable = true;
            CandidateProcess.Candidate.ResultLetter = MaxResultBlock.text;
            CandidateProcess.Candidate.ResultGPT = answerGpt;
        }
        else
        {
            Debug.Log("answerGpt = 0");
        }
    }  
    
    public void OnClick()
    {
        CandidatesManager.SaveCandidate(CandidateProcess.Candidate);
        SceneManager.LoadScene(0);
    }

}
