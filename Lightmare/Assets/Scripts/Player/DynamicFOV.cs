using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class DynamicFOV : MonoBehaviour
{
    //References to objects
    [SerializeField]private Rigidbody subject;
    private Camera cam;

    [Header("Variables")]

    [SerializeField] private float maxFOVIncrease;
    [SerializeField] private float FOVMult;
    [SerializeField] private float maxChangePerSec;

    //Needed variables
    private float stationaryFOV;
    private float currentFOV;


    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        stationaryFOV = cam.fieldOfView;
        currentFOV = cam.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        float targetFov = stationaryFOV + subject.velocity.magnitude * FOVMult;
        if (targetFov > maxFOVIncrease + stationaryFOV) targetFov = maxFOVIncrease + stationaryFOV;

        float fovSpeed = targetFov - currentFOV;

        fovSpeed = Mathf.Clamp(fovSpeed, -Time.deltaTime * maxFOVIncrease, Time.deltaTime * maxFOVIncrease);//to make sure it doesn't move to much at once
        currentFOV += fovSpeed;
        cam.fieldOfView = currentFOV;
    }
}
