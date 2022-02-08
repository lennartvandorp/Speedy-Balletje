using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class SpeedAnalytics : MonoBehaviour
{
    Rigidbody playerRb;
    float highestSpeed;
    float averageSpeed;
    float interval;
    float speedCollect;
    float timeSpent;
    float timesInter;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GameManager.Instance.Player.GetComponent<Rigidbody>();
        GameManager.Instance.failGame += OnFail;
        GameManager.Instance.finishGame += OnWin;
        timeSpent = Time.deltaTime;

    }
    private void Update()
    {
        if (playerRb.velocity.z > highestSpeed)
        {
            highestSpeed = playerRb.velocity.z;
        }
        if (Time.deltaTime == interval)
		{
            speedCollect += playerRb.velocity.z;
            timeSpent = 0;
            timesInter++;
		}
        averageSpeed = speedCollect / timesInter;
    }

    void OnFail()
    {
        highestSpeed = 0f;
        timeSpent = 0;
        timesInter = 0;
        speedCollect = 0f;
    }

    void OnWin()
    {
        AnalyticsResult resultAvrg = Analytics.CustomEvent("AverageSpeedAnalytics",
               new Dictionary<string, object> {
                {"Level", SceneManager.GetActiveScene().name },
                {"AverageSpeed", averageSpeed }
               });
     

        AnalyticsResult result = Analytics.CustomEvent("highestSpeedAnalytics",
            new Dictionary<string, object> {
                {"Level", SceneManager.GetActiveScene().name },
                {"HighestSpeed", highestSpeed }
            });
        Debug.Log("speed: " + result);
    }
}
