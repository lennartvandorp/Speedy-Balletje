using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static string levelName;

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
    public event Action stopStun;
    public event Action onJump;
    public event Action startBoost;
    public event Action stopBoost;
    public event Action landBoost;

    // Start is called before the first frame update
    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        levelName = SceneManager.GetActiveScene().name;
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

    public void LandBoost()
    {
        landBoost();
    }



    CameraShake cameraShake;
    public void StartScreenShake()
    {
        cameraShake.StartDynamicCameraShake();
    }
    public void StartScreenShake(float intensity)
    {
        cameraShake.StartDynamicCameraShake(intensity);
    }

    public void SetCameraShake(CameraShake _cameraShake)
    {
        cameraShake = _cameraShake;
    }
}
