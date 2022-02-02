using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class SpeedAnalytics : MonoBehaviour
{
    Rigidbody playerRb;
    float highestSpeed;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GameManager.Instance.Player.GetComponent<Rigidbody>();
        GameManager.Instance.failGame += OnFail;
        GameManager.Instance.finishGame += OnWin;
    }
    private void Update()
    {
        if (playerRb.velocity.z > highestSpeed)
        {
            highestSpeed = playerRb.velocity.z;
        }
    }

    void OnFail()
    {
        highestSpeed = 0f;
    }

    void OnWin()
    {
        AnalyticsResult result = Analytics.CustomEvent("highestSpeedAnalytics",
            new Dictionary<string, object> {
                {"Level", SceneManager.GetActiveScene().name },
                {"HighestSpeed", highestSpeed }
            });
    }
}
