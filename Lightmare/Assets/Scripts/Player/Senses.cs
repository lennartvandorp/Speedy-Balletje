using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(SphereCollider))]
public class Senses : MonoBehaviour
{
    SphereCollider collider;
    PlayerController controller;

    float groundDist = .05f;
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
    }

    void SetIsTouchingGround()
    {
        Ray ray = new Ray(transform.position + new Vector3(0f, -collider.radius + .05f, 0f), new Vector3(0f, -1, 0f));
        RaycastHit hit;
        Physics.Raycast(ray, out hit, groundDist + .05f);
        Debug.DrawRay(ray.origin, ray.direction * (groundDist + .05f), Color.blue);
        if (hit.collider && !hit.collider.isTrigger)
        {
            controller.IsTouchingGroundSetter = true;
            Debug.Log("Hitground");
        }
        else { controller.IsTouchingGroundSetter = false;
            Debug.Log("NoHitGround");
        }
    }
}
