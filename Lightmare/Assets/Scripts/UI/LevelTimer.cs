using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    TextMeshProUGUI tmp;

    float currentTime;
    bool isCounting;
    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        CountTime();
        DisplayTime();
    }

    void ResetTimer() {
        currentTime = 0f;
    }

    void CountTime() 
    {
        currentTime += Time.deltaTime;
    }
    void DisplayTime() 
    {
        tmp.text = (Mathf.Round(currentTime * 100f) / 100) + " s";
        
    }
}
