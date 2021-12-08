using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(SphereCollider))]
public class Senses : MonoBehaviour
{
    SphereCollider collider;
    PlayerController controller;


    [HideInInspector] public float GetPlayerZSpeed
    {
        get
        {
            return controller.getCurrentSpeed();
        }
    }


    
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<SphereCollider>();
        controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        SetIsTouchingGround();
        controller.IsTouchingLeftWallSetter = touchingWallLeft;
    }

    #region touching ground
    float groundDist = .1f;

    /// <summary>
    /// actually saves the value, don't directly modify
    /// </summary>
    bool touchingGround;
    bool isTouchingGround
    {
        set
        {
            controller.IsTouchingGroundSetter = value;
            touchingGround = value;
        }
        get { return touchingGround; }
    }
    [HideInInspector]
    public bool IsTouchingGround
    {
        get { return touchingGround; }
    }
    /// <summary>
    /// IsTouchingGround
    /// </summary>
    void SetIsTouchingGround()
    {
        Ray ray = new Ray(transform.position + new Vector3(0f, -collider.radius + .05f, 0f), new Vector3(0f, -1, 0f));
        RaycastHit hit;
        Physics.Raycast(ray, out hit, groundDist + .05f);
        Debug.DrawRay(ray.origin, ray.direction * (groundDist + .05f), Color.blue);
        if (hit.collider && !hit.collider.isTrigger)
        {
            isTouchingGround = true;
        }
        else { 
            isTouchingGround = false;
        }
    }
    #endregion

    #region touching wall
    bool touchingWallLeft {
        get
        {
            Ray ray = new Ray(transform.position + new Vector3(-collider.radius + 0.05f, 0f, 0f), -Vector3.right);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, groundDist + .05f);
            Debug.DrawRay(ray.origin, ray.direction * (groundDist + 0.05f), Color.blue);
            if (hit.collider && !hit.collider.isTrigger)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


    #endregion
}
