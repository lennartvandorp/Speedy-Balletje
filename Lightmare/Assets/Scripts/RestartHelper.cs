using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartHelper : MonoBehaviour
{
    [SerializeField]static public List<GameObject> DestroyedObject = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.restart += respawn;
        GameManager.Instance.failGame += respawn;
        GameManager.Instance.finishGame += PlayerHitsObjectAnalytics.TotalObjectsdestroyed;
        GameManager.Instance.finishGame += PlayerHitsObjectAnalytics.TotalObjectsHit;
        GameManager.Instance.failGame += PlayerHitsObjectAnalytics.TotalObjectsdestroyed;
        GameManager.Instance.failGame += PlayerHitsObjectAnalytics.TotalObjectsHit;
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
