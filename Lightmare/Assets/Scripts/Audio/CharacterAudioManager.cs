using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CharacterAudioManager : MonoBehaviour
{
    [SerializeField] private Sound speedWhoosh;


    private void Start()
    {
        AddSound(speedWhoosh);
    }

    void AddSound(Sound sound)
    {
        sound.source = gameObject.AddComponent<AudioSource>();
        sound.Init();
    }
    void playWhoosh()
    {
        speedWhoosh.Play();
    }
}
