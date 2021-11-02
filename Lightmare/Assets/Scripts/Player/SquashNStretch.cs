using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquashNStretch : MonoBehaviour
{
    Rigidbody rb;
    Vector3 originalScale;
    [SerializeField] float stretchDivider;//the lower the more stretch
    [SerializeField] float stretchAcc;
    [SerializeField] Transform rotationBody;
    SphereCollider collider;

    float stretchSpeed;
    Vector3 normalScale;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalScale = transform.localScale;
        normalScale = rotationBody.transform.localScale;
        collider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity != Vector3.zero)
        {
            rotationBody.rotation = Quaternion.LookRotation(rb.velocity);
        }

        float currentSpeed = rb.velocity.magnitude;
        float stretch = currentSpeed / stretchDivider;

        rotationBody.transform.localScale = normalScale + new Vector3(-stretch / 2f, -stretch / 2f, stretch);
        collider.radius = normalScale.x/2f - (stretch / 2f);
    }



    /// <param name="input"></param>
    /// <returns> A positive version of a vector</returns>
    Vector3 positiveVector3(Vector3 input)
    {
        return new Vector3(positiveFloat(input.x), positiveFloat(input.y), positiveFloat(input.z));
    }


    /// <param name="input"></param>
    /// <returns>A positive version of a float</returns>
    float positiveFloat(float input)
    {
        return Mathf.Sqrt(input * input);
    }
}
