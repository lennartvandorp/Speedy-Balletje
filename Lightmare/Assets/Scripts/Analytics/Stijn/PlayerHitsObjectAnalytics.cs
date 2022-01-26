using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class PlayerHitsObjectAnalytics : MonoBehaviour
{
    [SerializeField] static public int hitObjects;
    [SerializeField] static public List<GameObject> DestroyedObject = RestartHelper.DestroyedObject;

    public void OnObjectHit(GameObject obj)
    {
        AnalyticsResult result = Analytics.CustomEvent("hitobject", new Dictionary<string, object> {
            {SceneManager.GetActiveScene().name, obj.transform.position }
            }
                );
    }
    public void TotalObjectsHit()
    {
        AnalyticsResult result = Analytics.CustomEvent("AmountOfObjectsHit", new Dictionary<string, object> {
            {SceneManager.GetActiveScene().name, hitObjects }
            }
                );
    }
    public void OnObjectDestroyed(GameObject obj, Vector3 magnitude)
    {
        AnalyticsResult result = Analytics.CustomEvent("DextroyedObject", new Dictionary<string, object>{
            {SceneManager.GetActiveScene().name,  new Dictionary<Vector3, object>
        {
             {obj.transform.position, magnitude}
        }
            }
            }
                );
    }
    public void TotalObjectsdestroyed()
    {
        AnalyticsResult result = Analytics.CustomEvent("AmountOfObjectsDestroyed", new Dictionary<string, object> {
            {SceneManager.GetActiveScene().name, DestroyedObject.Count }
            }
                );
    }
}
