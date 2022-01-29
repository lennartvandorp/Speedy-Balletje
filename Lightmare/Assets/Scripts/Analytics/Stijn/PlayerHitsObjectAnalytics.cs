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
        Debug.Log(("öbject hit"));
        AnalyticsResult result = Analytics.CustomEvent("HitObject", new Dictionary<string, object> {
            {"Level", SceneManager.GetActiveScene().name},
            {"PositionX", obj.transform.position},
            {"PositionY", obj.transform.position},
            {"PositionZ", obj.transform.position}
            }
                );
    }
    static public void TotalObjectsHit()
    {
        Debug.Log(("total öbject hit"));
        AnalyticsResult result = Analytics.CustomEvent("AmountOfObjectsHit", new Dictionary<string, object> {
            {"Level", SceneManager.GetActiveScene().name },
            {"Amount", hitObjects }
            }
                );
        hitObjects = 0;
    }
    static public void OnObjectDestroyed(GameObject obj, float magnitude)
    {
        Debug.Log(("öbject destroyed"));
        AnalyticsResult result = Analytics.CustomEvent("DextroyedObject", new Dictionary<string, object>{
            {"Level", SceneManager.GetActiveScene().name},
            {"ForceApplied", magnitude},
            {"PositionX", obj.transform.position},
            {"PositionY", obj.transform.position},
            {"PositionZ", obj.transform.position}
            }
                );
    }
    static public void TotalObjectsdestroyed()
    {
        Debug.Log(("total öbject destroyed"));
        AnalyticsResult result = Analytics.CustomEvent("AmountOfObjectsDestroyed", new Dictionary<string, object> {
            { "Level", SceneManager.GetActiveScene().name },
            {"Amount", DestroyedObject.Count }
        }
                );
    }
}
