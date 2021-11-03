using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CharacterAudioManager : MonoBehaviour
{
    [SerializeField] private Sound speedWhoosh;
    [SerializeField] private Sound jumpSound;
    
    private void Start()
    {
        AddSound(speedWhoosh);
        AddSound(jumpSound);
        GameManager.Instance().onJump += PlayJumpSound;
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
    void PlayJumpSound()
    {
        jumpSound.Play();
    }
}
