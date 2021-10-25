using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    [SerializeField] private AudioClip clip;
    [SerializeField] private float volume;
    [SerializeField] private float pitch;
    [HideInInspector] public AudioSource source;
    public AudioClip GetClip()
    {
        return clip;
    }
    public float GetVolume()
    {
        return volume;
    }
    public float GetPitch()
    {
        return pitch;
    }

    public void Init()
    {
        source.volume = volume;
        source.pitch = pitch;
        source.clip = clip;
    }

    public void Play()
    {
        source.Play();
    }
}
