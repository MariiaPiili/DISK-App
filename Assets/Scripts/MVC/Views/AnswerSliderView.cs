using TMPro;
using UnityEngine;

public class AnswerSliderView : MonoBehaviour
{
    public static int ResultValue;

    public UnityEngine.UI.Slider InputSlider;
    public TextMeshProUGUI AnswerValueText;

    private void Start()
    {
        InputSlider.minValue = 1;
        InputSlider.maxValue = 5;
        UpdateDisplayedValue(InputSlider.value);
    }

    public void OnSliderValueChanged(float value)
    {
        UpdateDisplayedValue(value);
    }

    private void UpdateDisplayedValue(float value)
    {
        value = Mathf.Clamp(value, 1, 5);
        ResultValue = Mathf.RoundToInt(value);
        AnswerValueText.text = ResultValue.ToString();
        Debug.Log($"Slider value updated: {ResultValue}");
    }
}
