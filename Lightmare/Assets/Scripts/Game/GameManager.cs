using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get { return instance; }
    }
    [SerializeField] private GameObject player;
    public GameObject Player
    {
        get { return player; }
    }

    [SerializeField] private GameObject impactParticles;
    public GameObject ImpactParticles
    {
        get { return impactParticles; }
    }


    public event Action startGame;
    public event Action finishGame;
    public event Action failGame;
    public event Action restart;
    public event Action stunPlayer;
    public event Action onJump;
    public event Action startBoost;
    public event Action stopBoost;
    // Start is called before the first frame update
    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    public void Fail()
    {
        failGame();
    }
    public void Finish()
    {
        finishGame();
    }
    public void Restart()
    {
        restart();
    }

    public void StunPlayer()
    {
        stunPlayer();
    }

    public void OnJump()
    {
        onJump();
    }

    public void StartBoost()
    {
        startBoost();
    }
    public void StopBoost()
    {
        stopBoost();
    }
}
