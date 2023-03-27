using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngineInternal;

public class SliderValueSaver : MonoBehaviour
{
    Slider slider;

    [Tooltip("Keep this empty if you don't want to have a value text")]
    [SerializeField] private TextMeshProUGUI valueText;

    [SerializeField] PlayerPrefsInterface.Pref pref;
    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = PlayerPrefs.GetFloat(PlayerPrefsInterface.Instance.GetPref(pref));
    }


    public void SaveValue()
    {
        if (valueText)
        {
            valueText.text = RoundFloat(slider.value, 2).ToString();
        }
        PlayerPrefsInterface.Instance.SetValue(pref, slider.value);
    }


    /// <summary>
    /// Rounds a float with decimals
    /// </summary>
    /// <param name="value">The float to round</param>
    /// <param name="decimals">The amount of decimals</param>
    /// <returns></returns>
    float RoundFloat(float value, int decimals)
    {
        return Mathf.Round(value * Mathf.Pow(10, decimals)) / Mathf.Pow(10, decimals);
    }
}
