using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class DistTraveledAnalytics : MonoBehaviour
{
    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = GameManager.Instance.Player.transform.position;
        GameManager.Instance.failGame += OnDeath;
    }


    void OnDeath()
    {
        float endDist = GameManager.Instance.Player.transform.position.z;
        float dist = endDist - startPos.z;

        AnalyticsResult result = Analytics.CustomEvent("distOfDeathAnalytics", new Dictionary<string, object> { 
            { "Level", SceneManager.GetActiveScene().name },
            {"Distance", dist }
        });
        Debug.Log("Dist: " + result);
    }
}
