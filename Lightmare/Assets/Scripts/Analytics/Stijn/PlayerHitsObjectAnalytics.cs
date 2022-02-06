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

        AnalyticsResult result = Analytics.CustomEvent("HitObject"+ SceneManager.GetActiveScene().name, new Dictionary<string, object> {
            {"Position", obj.transform.position}

            }
                );
        Debug.Log((result));
    }
    static public void TotalObjectsHit()
    {
        AnalyticsResult result = Analytics.CustomEvent("AmountOfObjectsHit"+ SceneManager.GetActiveScene().name, new Dictionary<string, object> {
            {"Amount", hitObjects }
            }
                );
        hitObjects = 0;
        Debug.Log((result));
    }
    static public void OnObjectDestroyed(GameObject obj, float magnitude)
    {
        AnalyticsResult result = Analytics.CustomEvent("DextroyedObject"+ SceneManager.GetActiveScene().name, new Dictionary<string, object>{
            {"ForceApplied", magnitude},
            {"Position", obj.transform.position}

            }
                );
        Debug.Log((result));
    }
    static public void TotalObjectsdestroyed()
    {
        AnalyticsResult result = Analytics.CustomEvent("AmountOfObjectsDestroyed"+ SceneManager.GetActiveScene().name, new Dictionary<string, object> {
            {"Amount", DestroyedObject.Count }
        }
                );
        Debug.Log((result));
    }
}
