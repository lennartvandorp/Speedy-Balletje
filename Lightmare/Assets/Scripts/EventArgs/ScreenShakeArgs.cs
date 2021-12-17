using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeArgs
{
    public float shakeTime, shakeIntensity;
    public ScreenShakeArgs(float _shakeTime, float _shakeIntensity)
    {
        shakeTime = _shakeTime;
        shakeIntensity = _shakeIntensity;
    }
}