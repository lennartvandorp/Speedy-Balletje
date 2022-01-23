using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    float screenshakeDivider = 150f;
    int neededForce = 60;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log(collision.impactForceSum.magnitude);
            if(collision.impactForceSum.magnitude >= neededForce)
            {
                collision.rigidbody.velocity -= new Vector3(collision.rigidbody.velocity.x, 0, 0);
                this.gameObject.active = false;
            }
            GameManager.Instance.StunPlayer();
            GameManager.Instance.StartScreenShake(collision.impactForceSum.magnitude / screenshakeDivider);//activates the screen shake
            GameObject impactParticles = Instantiate(GameManager.Instance.ImpactParticles);
            impactParticles.transform.position = collision.GetContact(0).point;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

        }
    }
}