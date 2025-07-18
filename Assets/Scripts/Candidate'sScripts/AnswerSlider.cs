using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class AnswerSlider : MonoBehaviour
{
    public static int ResultValue;

    public UnityEngine.UI.Slider Slider;
    public TextMeshProUGUI AnswerValue;

    void Start()
    {

       Slider.minValue = 1;
       Slider.maxValue = 5;
        
       UpdateText(Slider.value);
    }
    public void UpdateText(float value)
    {
        value = Mathf.Clamp(value, 1, 5); 
        ResultValue = Mathf.RoundToInt(value);
        Debug.Log("Value: " + value);
        AnswerValue.text = Mathf.RoundToInt(value).ToString();
    }
}
