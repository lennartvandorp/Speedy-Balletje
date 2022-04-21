using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    TextMeshProUGUI tmp;

    float currentTime;
    bool isCounting = true;
    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        GameManager.Instance.restart += ResetTimer;
        GameManager.Instance.failGame += ResetTimer;
        GameManager.Instance.finishGame += StopTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCounting)
        {
            CountTime();
        }
        DisplayTime();
    }

    void ResetTimer()
    {
        currentTime = 0f;
        isCounting = true;
    }

    void CountTime()
    {
        currentTime += Time.deltaTime;
    }
    void DisplayTime()
    {
        tmp.text = (Mathf.Round(currentTime * 10f) / 10) + " s";

    }

    void StopTimer()
    {
        isCounting = false;
        //todo: Database implementation of adding the time to it
        Database.DataBaseManager.Instance.AddCurrentTimeToDatabase(currentTime);
    }
}
