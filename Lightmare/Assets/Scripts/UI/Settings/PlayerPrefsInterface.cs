using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerPrefsInterface : MonoBehaviour
{
    public static PlayerPrefsInterface Instance { get; private set; }

    [HideInInspector] public UnityEvent onUpdatePrefs = new UnityEvent();

    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public enum Pref
    {
        sensitivity
    }
    string sensitivityString = "Sensitivity";

    public string GetPref(Pref pref)
    {
        switch (pref)
        {
            case Pref.sensitivity:
                return sensitivityString;
                break;
        }
        return null;
    }

    public void SetValue(Pref pref, float value)
    {
        PlayerPrefs.SetFloat(GetPref(pref), value);
    }

    public void OnUpdateValues()
    {
        onUpdatePrefs.Invoke();
    }

}
