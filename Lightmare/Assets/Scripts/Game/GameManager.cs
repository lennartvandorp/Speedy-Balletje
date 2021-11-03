using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance()
    {
        return instance;
    }
    [SerializeField] private GameObject player;
    public GameObject Player()
    {
        return player;
    }


    public event Action startGame;
    public event Action finishGame;
    public event Action failGame;
    public event Action restart;
    public event Action stunPlayer;
    public event Action onJump;
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
}
