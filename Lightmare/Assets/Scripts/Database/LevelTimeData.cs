using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimeData
{
    public string levelName;
    public float levelTime;
    public LevelTimeData(string _levelName, float _levelTime) {
        levelName = _levelName;
        levelTime = _levelTime;
    }
}
