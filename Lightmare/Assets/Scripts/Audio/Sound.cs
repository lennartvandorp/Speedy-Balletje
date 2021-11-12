using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    [SerializeField] private AudioClip clip;
    [SerializeField] private float volume;
    [SerializeField] private float pitch;
    [HideInInspector] private AudioSource source;
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

    public Sound(AudioClip _clip, float _volume, float _pitch)
    {
        clip = _clip;
        volume = _volume;
        pitch = _pitch;
    }

    /// <summary>
    /// Initializes the source values needed
    /// </summary>
    public void Init(AudioSource _source)
    {
        source = _source;
        source.volume = volume;
        source.pitch = pitch;
        source.clip = clip;
    }

    public void Play()
    {
        source.clip = clip;
        source.Play();
    }
}
