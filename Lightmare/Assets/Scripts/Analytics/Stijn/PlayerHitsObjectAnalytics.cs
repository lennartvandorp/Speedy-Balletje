using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class PlayerHitsObjectAnalytics : MonoBehaviour
{
    [SerializeField] static public int hitObjects = 0;
    [SerializeField] static public List<GameObject> DestroyedObject = RestartHelper.DestroyedObject;

    static public void OnObjectHit(GameObject obj)
    {
        string eventname = "HitObject" + SceneManager.GetActiveScene().name;
        eventname = eventname.Replace(" ", string.Empty);
        AnalyticsResult result = Analytics.CustomEvent(eventname, new Dictionary<string, object> {
            {"Position", obj.transform.position}

            }
                );
    }
    static public void TotalObjectsHit()
    {
        string eventname = "AmountOfObjectsHit" + SceneManager.GetActiveScene().name;
        eventname = eventname.Replace(" ", string.Empty);
        AnalyticsResult result = Analytics.CustomEvent(eventname, new Dictionary<string, object> {
            {"Amount", hitObjects }
            }
                );
        hitObjects = 0;
    }
    static public void OnObjectDestroyed(GameObject obj, float magnitude)
    {
        string eventname = "DextroyedObject" + SceneManager.GetActiveScene().name;
        eventname = eventname.Replace(" ", string.Empty);
        AnalyticsResult result = Analytics.CustomEvent(eventname, new Dictionary<string, object>{
            {"ForceApplied", magnitude},
            {"Position", obj.transform.position}

            }
                );
    }
    static public void TotalObjectsdestroyed()
    {
        string eventname = "AmountOfObjectsDestroyed" + SceneManager.GetActiveScene().name;
        eventname = eventname.Replace(" ", string.Empty);
        AnalyticsResult result = Analytics.CustomEvent(eventname, new Dictionary<string, object> {
            {"Amount", DestroyedObject.Count }
        }
                );
    }
}
