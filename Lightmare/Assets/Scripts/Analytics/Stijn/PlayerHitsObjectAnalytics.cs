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

        AnalyticsResult result = Analytics.CustomEvent("HitObject", new Dictionary<string, object> {
            {"Level", SceneManager.GetActiveScene().name},
            {"PositionX", obj.transform.position},
            {"PositionY", obj.transform.position},
            {"PositionZ", obj.transform.position}
            }
                );
        Debug.Log((result));
    }
    static public void TotalObjectsHit()
    {
        AnalyticsResult result = Analytics.CustomEvent("AmountOfObjectsHit", new Dictionary<string, object> {
            {"Level", SceneManager.GetActiveScene().name },
            {"Amount", hitObjects }
            }
                );
        hitObjects = 0;
        Debug.Log((result));
    }
    static public void OnObjectDestroyed(GameObject obj, float magnitude)
    {
        AnalyticsResult result = Analytics.CustomEvent("DextroyedObject", new Dictionary<string, object>{
            {"Level", SceneManager.GetActiveScene().name},
            {"ForceApplied", magnitude},
            {"PositionX", obj.transform.position},
            {"PositionY", obj.transform.position},
            {"PositionZ", obj.transform.position}
            }
                );
        Debug.Log((result));
    }
    static public void TotalObjectsdestroyed()
    {
        AnalyticsResult result = Analytics.CustomEvent("AmountOfObjectsDestroyed", new Dictionary<string, object> {
            { "Level", SceneManager.GetActiveScene().name },
            {"Amount", DestroyedObject.Count }
        }
                );
        Debug.Log((result));
    }
}
