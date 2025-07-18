using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrackingOrder : MonoBehaviour
{
    public TextMeshProUGUI MinutesLeftText;

    public Image LevelBlockDImage;
    public Image LevelBlockIImage;
    public Image LevelBlockSImage;
    public Image LevelBlockCImage;

    public Sprite DoneSprite;
    public Sprite NextLevelSprite;
    public Sprite WaitingToPriceedSprite;

    public TextMeshProUGUI TextBlockD;
    public TextMeshProUGUI TextBlockI;
    public TextMeshProUGUI TextBlockS;
    public TextMeshProUGUI TextBlockC;

    public Button ContinueButton;

    public WindowManager WindowManager;

    private int _currentBlockNumber;
       

    public void Init(int minute, int currentBlock)
    {
        MinutesLeftText.text = minute.ToString();
        _currentBlockNumber = currentBlock;

        if (currentBlock == 0)
        {
            LevelBlockDImage.sprite = NextLevelSprite;
            TextBlockD.text = "meneillään";
        }
        if (currentBlock > 0)
        {
            LevelBlockDImage.sprite = DoneSprite;
            TextBlockD.text = "suoritettu";
        }
        if (currentBlock < 0)
        {
            LevelBlockDImage.sprite = WaitingToPriceedSprite;
            TextBlockD.text = "odottaa";
        }

        if (currentBlock == 1)
        {
            LevelBlockIImage.sprite = NextLevelSprite;
            TextBlockI.text = "meneillään";
        }
        if (currentBlock > 1)
        {
            LevelBlockIImage.sprite = DoneSprite;
            TextBlockI.text = "suoritettu";
        }
        if (currentBlock < 1)
        {
            LevelBlockIImage.sprite = WaitingToPriceedSprite;
            TextBlockI.text = "odottaa";
        }

        if (currentBlock == 2)
        {
            LevelBlockSImage.sprite = NextLevelSprite;
            TextBlockS.text = "meneillään";
        }
        if (currentBlock > 2)
        {
            LevelBlockSImage.sprite = DoneSprite;
            TextBlockS.text = "suoritettu";
        }
        if (currentBlock < 2)
        {
            LevelBlockSImage.sprite = WaitingToPriceedSprite;
            TextBlockS.text = "odottaa";
        }

        if (currentBlock == 3)
        {
            LevelBlockCImage.sprite = NextLevelSprite;
            TextBlockC.text = "meneillään";
        }
        if (currentBlock > 3)
        {
            LevelBlockCImage.sprite = DoneSprite;
            TextBlockC.text = "suoritettu";
        }
        if (currentBlock < 3)
        {
            LevelBlockCImage.sprite = WaitingToPriceedSprite;
            TextBlockC.text = "odottaa";
        }
    }

    public void Click()
    {
        if (_currentBlockNumber <= 3)
        {
            WindowManager.PreviousScreen();
            return;
        }
        WindowManager.NextScreen();
    }
}
