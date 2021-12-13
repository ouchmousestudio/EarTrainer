using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class ParamEQ : MonoBehaviour
{
    [SerializeField] private AudioMixer musicMixer;
    [SerializeField] private Slider freqSlider;
    [SerializeField] private Toggle bypassToggle;
    [SerializeField] private TextMeshProUGUI freqText;

    public void SetParamFreq(float paramFreq)
    {
        float scaledFreq;
        float expFreq = 20;
        expFreq = Mathf.Exp(freqSlider.value);
        scaledFreq = expFreq;

        musicMixer.SetFloat("paramFreq", scaledFreq);

        ShowText();
    }

    public void SetParamFreqRaw(float paramFreq)
    {
        musicMixer.SetFloat("paramFreq", paramFreq);
    }

    public float GetParamFreq()
    {
        float value;
        bool result = musicMixer.GetFloat("paramFreq", out value);
        if (result) { return value; }
        else { return 0f; }
    }

    public void Bypass()
    {
        if (bypassToggle.isOn)
        {
            musicMixer.SetFloat("paramGain", 1f);
        }
        else
        {
            musicMixer.SetFloat("paramGain", 1.6f);
        }
    }

    public void ShowText()
    {
        //Print UI
        float roundedValue = Mathf.Round(GetParamFreq());
        freqText.text = "Freq: " + ConverttoKhz(roundedValue);
    }

    public string ConverttoKhz(float roundedValue)
    {
        if (roundedValue < 1000f)
        {
            return roundedValue.ToString() + "Hz";
        }
        else
        {
            return  (roundedValue / 1000).ToString() + "kHz";
        }
    }
}
