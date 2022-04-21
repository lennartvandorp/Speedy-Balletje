using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BestLevelTimeDisp : TextDispHelper
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        StartCoroutine(ResetLowestTime());
        GameManager.Instance.restart += OnReset;
    }



    public IEnumerator ResetLowestTime()
    {
        yield return null;//
        string lowestTime = Database.DataBaseManager.Instance.highScore.GetLowestTimeFromLevel(SceneManager.GetActiveScene().name).ToString() ;
        SetText("Best time: " + lowestTime.ToString());
    }

    void OnReset() { StartCoroutine(ResetLowestTime()); }
}