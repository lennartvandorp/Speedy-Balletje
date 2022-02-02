using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.Analytics;

public class RestartHelper : MonoBehaviour
{
    [SerializeField]static public List<GameObject> DestroyedObject = new List<GameObject>();
    // Start is called before the first frame update
    async void Start()
    {
        GameManager.Instance.restart += respawn;
        GameManager.Instance.failGame += respawn;
        GameManager.Instance.finishGame += PlayerHitsObjectAnalytics.TotalObjectsdestroyed;
        GameManager.Instance.finishGame += PlayerHitsObjectAnalytics.TotalObjectsHit;
        GameManager.Instance.failGame += PlayerHitsObjectAnalytics.TotalObjectsdestroyed;
        GameManager.Instance.failGame += PlayerHitsObjectAnalytics.TotalObjectsHit;

        //try
        //{
        //    await UnityServices.InitializeAsync();
        //    List<string> consentIdentifiers = await Events.CheckForRequiredConsents();
        //}
        //catch (ConsentCheckException e)
        //{
        //    Debug.Log("shit");
        //    // Something went wrong when checking the GeoIP, check the e.Reason and handle appropriately
        //}
        //Analytics.EnableEvent("HitObject", true);
    }
    static public void respawn()
    {
        foreach(GameObject obj in DestroyedObject)
        {
            obj.SetActive(true);
        }
        DestroyedObject.Clear();
    }
}
