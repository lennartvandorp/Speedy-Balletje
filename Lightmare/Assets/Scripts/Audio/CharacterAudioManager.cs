using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CharacterAudioManager : MonoBehaviour
{
    [SerializeField] private Sound speedWhoosh;


    private void Start()
    {
        speedWhoosh.source = gameObject.AddComponent<AudioSource>();
        speedWhoosh.Init();

    }
    void playWhoosh()
    {
        speedWhoosh.Play();
    }
}
