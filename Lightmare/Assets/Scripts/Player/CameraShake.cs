using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float standardShakeIntensity;
    [SerializeField] float shakeReduction;

    private void Start()
    {
        GameManager.Instance.SetCameraShake(this);
    }

    private void LateUpdate()
    {
        DynamicCameraShake();
    }
    /// <summary>
    /// Starts the screenshake coroutine. 
    /// </summary>
    /// <param name="duration"></param>
    /// <param name="intensity"></param>
    public void StartScreenShake(float duration, float intensity)
    {
        StartCoroutine(DuringScreenshake(duration, intensity));
    }


    IEnumerator DuringScreenshake(float duration, float intensity)
    {
        Vector3 offset = RandomOffset(intensity);
        transform.position += offset;
        float time = 0;
        while (time < duration)
        {
            yield return null;
            transform.position -= offset;
            offset = RandomOffset(intensity);
            transform.position += offset;
            time += Time.deltaTime;
            Debug.Log("shaking");
        }
        transform.position -= offset;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="intensity"></param>
    /// <returns>A random vector3 with values between -intensity and intensity</returns>
    Vector3 RandomOffset(float intensity)
    {
        return new Vector3(Random.Range(-intensity, intensity), Random.Range(-intensity, intensity), Random.Range(-intensity, intensity));
    }

    float currentIntensity;
    Vector3 lastOffset;
    void DynamicCameraShake()
    {
        if (currentIntensity > 0)
        {
            Vector3 offset = RandomOffset(currentIntensity);
            transform.position -= lastOffset;
            transform.position += offset;
            lastOffset = offset;
            currentIntensity -= shakeReduction * Time.deltaTime;
        }

    }

    public void StartDynamicCameraShake(float intensity) { currentIntensity += intensity; }
    public void StartDynamicCameraShake() { currentIntensity += standardShakeIntensity; }
}
