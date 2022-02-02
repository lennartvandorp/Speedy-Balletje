using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoTracker : MonoBehaviour
{
    [HideInInspector] public string levelName;

    private void Awake()
    {
        levelName = SceneManager.GetActiveScene().name;
    }

}
