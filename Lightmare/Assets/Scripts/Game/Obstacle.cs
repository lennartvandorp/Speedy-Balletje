using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    

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
        if(collision.gameObject.tag == "Player")
        {
            GameManager.Instance.StunPlayer();
            GameManager.Instance.StartScreenShake(collision.impactForceSum.magnitude /100f);
            GameObject impactParticles = Instantiate(GameManager.Instance.ImpactParticles);
            impactParticles.transform.position = collision.GetContact(0).point;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {

        }
    }
}
