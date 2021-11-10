using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLineHandler : MonoBehaviour
{
    Rigidbody playerRb;
    ParticleSystem ps;
    [SerializeField] float minimumSpeed;
    bool isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GameManager.Instance.Player.GetComponent<Rigidbody>();
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerRb.velocity.magnitude >= minimumSpeed)
        {
            if (!isPlaying)
            {
                ps.Play();
                isPlaying = true;
            }
        }
        else if (isPlaying)
        {
            ps.Stop();
            isPlaying = false;
        }
    }
}
