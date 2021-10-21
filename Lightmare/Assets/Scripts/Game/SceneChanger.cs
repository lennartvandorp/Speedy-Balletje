using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger instance;
    [SerializeField] Scene[] levels;

    private void Start()
    {
        if (!instance)
        {
            instance = this;
        }
        else { Debug.LogError("There are too many SceneManagers right now. There should only be one"); }
    }

    public void ChangeToTutorial() {
        SceneManager.LoadScene("Tutorial");
    }
}
