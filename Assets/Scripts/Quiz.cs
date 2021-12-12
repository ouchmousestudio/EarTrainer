using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Quiz : MonoBehaviour
{
    [SerializeField] ParamEQ paramEQ;
    [SerializeField] float[] freqValues;
    [SerializeField] Button[] buttons;
    [SerializeField] TextMeshProUGUI answerText;

    private int randomNum;
    private List<float> freqList;

    private void Start()
    {
        SetRandomFreq();
    }

    public void SetAnswers()
    {
        freqList = new List<float>();

        while (freqList.Count < 4)
        {
            var element = freqValues[Random.Range(0, freqValues.Length)];
            if (!freqList.Contains(element))
            {
                freqList.Add(element);
            }
        }
        for (int i = 0; i < 4; i++)
        {
            string buttonText = paramEQ.ConverttoKhz(freqList[i]);
         
            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = buttonText;
        }
    }

    public void SetRandomFreq()
    {
        SetAnswers();

        //Set Random Frequency
        randomNum = Random.Range(0, 4);
        paramEQ.SetParamFreqRaw(freqList[randomNum]);
    }

    public void CheckAnswer(int answer)
    {
        if (answer == randomNum)
        {
            answerText.text = "Correct!";
        }
        else
        {
            answerText.text = "Wrong!";
        }
    }
}
