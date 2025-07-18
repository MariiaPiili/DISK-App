using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class HomePage2 : MonoBehaviour
{
    public Image BlockIcon;

    public Sprite SpriteBlockD;
    public Sprite SpriteBlockI;
    public Sprite SpriteBlockS;
    public Sprite SpriteBlockC;

    public TextMeshProUGUI BlockHeading;
    public TextMeshProUGUI NumberOfQuestionInBlock;
    public TextMeshProUGUI QuestionText;
    public TextMeshProUGUI SliderResultText;

    public Slider BlockProgressSlider;
    public Slider InputSlider;

    public Button ContinueButton;

    public CandidateProcess CandidateProcess;
    public TrackingOrder TrackingOrder;
    public WindowManager WindowManager;

    private Questions _questions = new Questions();

    private int _currentQuestion = 0;
    private int _currentBlock = 0;

    private DateTime _lastTime;

    private void Start()
    {
        CandidateProcess = FindObjectOfType<CandidateProcess>();  
        
        _lastTime = DateTime.Now;
    }   
    
    private void OnEnable()
    {
        ShowQuestion();        
    }

    public void NextQuestion()
    {
        CandidateProcess.SaveResult(_currentBlock, AnswerSlider.ResultValue);
        _currentQuestion++;
        if (_currentQuestion == 25)
        {
            _currentQuestion = 0;
            _currentBlock++;

            int minute = (DateTime.Now - _lastTime).Minutes;
            TrackingOrder.Init(minute, _currentBlock);

            WindowManager.NextScreen();
        }

        ShowQuestion();
    }

    private void ShowQuestion()
    {
        QuestionText.text = _questions.GetQuestion(_currentQuestion, _currentBlock);
        InputSlider.value = 1;
        BlockHeading.text = GetHeadingBlock();
        BlockIcon.sprite = GetIconBlock();
        NumberOfQuestionInBlock.text = (_currentQuestion + 1).ToString();

        BlockProgressSlider.value = (100f / 25 * (_currentQuestion + 1))/100f;
    }

    private Sprite GetIconBlock()
    {
        switch (_currentBlock)
        {
            case 0:
                return SpriteBlockD;
            case 1:
                return SpriteBlockI;
            case 2:
                return SpriteBlockS;
            case 3:
                return SpriteBlockC;
        }
        return null;
    }

    private string GetHeadingBlock()
    {
        switch (_currentBlock)
        {
            case 0:
                return "D – Dominanssi";
            case 1:
                return "I – Vaikuttaminen";
            case 2:
                return "S – Vakaa tyyli";
            case 3:
                return "C – Tunnollisuus";
        }
        return null;
    }
        
}
