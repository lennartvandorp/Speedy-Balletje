using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]

public class SpeedLineHandler : MonoBehaviour
{
    Rigidbody playerRb;
    ParticleSystem ps;
    [SerializeField] float minimumSpeed;
    [SerializeField] bool startWithSpeed;
    [SerializeField] bool startWithOnGround;

    /// <summary>
    /// actually saves the value, don't directly modify
    /// </summary>
    bool playing;
    /// <summary>
    /// Will set the particles active or inactive inherently
    /// </summary>
    bool isPlaying
    {
        set
        {
            if ((!ps.isPlaying) && value)
            {
                ps.Play();
            }
            else if (ps.isPlaying && !value)
            {
                ps.Stop();
            }
            playing = value;
        }
        get { return playing; }
    }

    Senses senses;
    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GameManager.Instance.Player.GetComponent<Rigidbody>();
        ps = GetComponent<ParticleSystem>();
        if (startWithOnGround)
        {
            senses = GameManager.Instance.Player.GetComponent<Senses>();
        }
        if (senses == null) { senses = GameManager.Instance.Player.GetComponent<Senses>(); }
    }

    // Update is called once per frame
    void Update()
    {
        if (startWithSpeed)
        {
            if (playerRb.velocity.magnitude >= minimumSpeed)
            {
                isPlaying = true;
            }
            else { isPlaying = false; }
        }

        //only run if the particles activate based on if the player is on the ground
        if (startWithOnGround)
        {
            if (senses.IsTouchingGround)
            {
                isPlaying = true;
            }
            else {isPlaying = false; }
        }
    }

}
