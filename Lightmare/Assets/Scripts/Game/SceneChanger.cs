using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger instance;
    [SerializeField] string[] levels;

    private void Start()
    {
        if (!instance)
        {
            instance = this;
        }
        else { Debug.LogError("There are too many SceneManagers right now. There should only be one"); }
    }

    public void ChangeToLevel(int level)
    {
        SceneManager.LoadScene(levels[level]);
    }
}
