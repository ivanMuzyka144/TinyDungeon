using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip gameMusic;
    [SerializeField] private AudioClip buttonClickSound;
    [SerializeField] private AudioClip softClick;
    [SerializeField] private AudioClip blink1;
    [SerializeField] private AudioClip blink2;
    [SerializeField] private AudioClip blink3;
    [SerializeField] private AudioClip dragSound;
    [SerializeField] private AudioClip dropSound;
    [Space(10)]
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioSource soundAudioSource;
    private void Start()
    {
        musicAudioSource.PlayOneShot(gameMusic);
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
