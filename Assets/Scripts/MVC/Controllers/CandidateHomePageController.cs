using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CandidateHomePageController : MonoBehaviour
{
    public CandidateController CandidateController;
    public TrackingOrderView TrackingOrderView;
    public WindowManager WindowManager;
    public QuestionsModel Questions = new();

    public Image BlockIcon;
    public Sprite[] BlockIcons;

    public TextMeshProUGUI BlockHeading;
    public TextMeshProUGUI NumberOfQuestionInBlock;
    public TextMeshProUGUI QuestionText;
    public Slider BlockProgressSlider;
    public Slider InputSlider;
    public Button ContinueButton;

    private int _currentQuestion = 0;
    private int _currentBlock = 0;
    private System.DateTime _startTime;

    private void Start()
    {
        _startTime = System.DateTime.Now;
    }

    private void OnEnable() => ShowQuestion();

    public void NextQuestion()
    {
        CandidateController.SaveAnswer(_currentBlock, AnswerSliderView.ResultValue);
        _currentQuestion++;

        if (_currentQuestion == 25)
        {
            int minutes = (System.DateTime.Now - _startTime).Minutes;
            _currentBlock++;
            _currentQuestion = 0;
            TrackingOrderView.Init(minutes, _currentBlock);
            WindowManager.NextScreen();
        }
        if(_currentBlock == 4)
        {
            _currentBlock = 3;
        }

        ShowQuestion();
    }

    private void ShowQuestion()
    {
        QuestionText.text = Questions.GetQuestion(_currentQuestion, _currentBlock);
        InputSlider.value = 1;
        BlockHeading.text = GetBlockName(_currentBlock);
        Debug.Log($"current block + {_currentBlock}");
        BlockIcon.sprite = BlockIcons[_currentBlock];
        NumberOfQuestionInBlock.text = (_currentQuestion + 1).ToString();
        BlockProgressSlider.value = (float)(_currentQuestion + 1) / 25f;
    }

    private string GetBlockName(int block) => block switch
    {
        0 => "D – Dominanssi",
        1 => "I – Vaikuttaminen",
        2 => "S – Vakaa tyyli",
        3 => "C – Tunnollisuus",
        _ => ""
    };

}
