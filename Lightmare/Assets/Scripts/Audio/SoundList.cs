using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundList
{
    [SerializeField] private float volume;
    [SerializeField] private float pitch;
    [SerializeField] private AudioClip[] clips;
    [HideInInspector] public AudioSource source;

    private Sound[] sounds;


    /// <summary>
    /// Sets up the audio files 
    /// </summary>
    /// <param name="_source"></param>
    public void Init(AudioSource _source)
    {
        source = _source;
        source.volume = volume;
        source.pitch = pitch;

        sounds = new Sound[clips.Length];
        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i] = new Sound(clips[i], volume, pitch);
            sounds[i].Init(_source);
        }
    }


    /// <summary>
    /// Picks a random sound from the list and play it
    /// </summary>
    public void PlayFromList()
    {
        sounds[Random.Range(0, sounds.Length)].Play();
    }
}
