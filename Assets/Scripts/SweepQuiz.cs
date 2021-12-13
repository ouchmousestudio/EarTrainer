using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class SweepQuiz : MonoBehaviour
{
    [SerializeField] ParamEQ paramEQ;
    [SerializeField] private TextMeshProUGUI answerText;
    [SerializeField] private TextMeshProUGUI freqText;
    [SerializeField] private Slider freqSlider;

    private float currentFreq;
    private float sliderFreq;
    private float freqDifference;

    public void SetCurrentFreq()
    {
        //Set Random Frequency
        currentFreq = Random.Range(20, 20000);
        paramEQ.SetParamFreqRaw(currentFreq);
    }

    public void UpdateFreqText()
    {
        string freqString = paramEQ.ConverttoKhz(Mathf.Round(Mathf.Exp(freqSlider.value)));

        freqText.text = "Freq: " + freqString;
    }

    public void CheckAnswer()
    {
        float answer = Mathf.Exp(freqSlider.value);

        freqDifference = Mathf.Abs(answer - currentFreq);

        if(freqDifference < 10)
        {
            answerText.text = "Perfect!";
        }
        else if (freqDifference < 100)
        {
            answerText.text = "Correct!";
        }
        else if (freqDifference < 500)
        {
            answerText.text = "Almost!";
        }
        else
        {
            answerText.text = "Wrong!";
        }
    }
}
