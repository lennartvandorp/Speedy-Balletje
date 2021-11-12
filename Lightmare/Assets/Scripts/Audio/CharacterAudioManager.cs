using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CharacterAudioManager : MonoBehaviour
{
    [SerializeField] private Sound speedWhoosh;
    [SerializeField] private SoundList jumpSound;
    
    private void Start()
    {
        AddSound(speedWhoosh);
        AddSoundList(jumpSound);
        GameManager.Instance.onJump += PlayJumpSound;
    }

    void AddSound(Sound sound)
    {
        sound.Init(gameObject.AddComponent<AudioSource>());
    }

    void AddSoundList(SoundList soundList)
    {

        soundList.Init(gameObject.AddComponent<AudioSource>());
    }
    void playWhoosh()
    {
        speedWhoosh.Play();
    }

    void PlayJumpSound()
    {
        jumpSound.PlayFromList();
    }
}
