using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rolling : MonoBehaviour
{


    Rigidbody rb;
    [SerializeField] Rigidbody rotationRb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rotationRb.angularVelocity = new Vector3(rb.velocity.z, rb.velocity.x, 0f);
    }
}
