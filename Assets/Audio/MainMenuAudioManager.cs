using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip buttonClickSound;
    [SerializeField] private AudioClip softClick;
    [Space(10)]
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioSource soundAudioSource;

    private void Start()
    {
        musicAudioSource.PlayOneShot(menuMusic);
    }

    public void PlayButtonClickMusic()
    {
        soundAudioSource.PlayOneShot(buttonClickSound);
    }

    public void PlaySoftButtonClickMusic()
    {
        soundAudioSource.PlayOneShot(softClick);
    }
}
