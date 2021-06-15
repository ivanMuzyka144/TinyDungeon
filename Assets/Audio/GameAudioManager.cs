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
    [SerializeField] private AudioClip runningSound;
    [SerializeField] private AudioClip zoomInSound;
    [SerializeField] private AudioClip zoomOutSound;
    [SerializeField] private AudioClip doorOpens;
    [SerializeField] private AudioClip doorClose;
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

    public void PlayBlinkSound(int number)
    {
        if(number == 1)
        {
            soundAudioSource.PlayOneShot(blink1);
        }
        if (number == 2)
        {
            soundAudioSource.PlayOneShot(blink2);
        }
        if (number == 3)
        {
            soundAudioSource.PlayOneShot(blink3);
        }
    }

    public void PlayDragSound()
    {
        soundAudioSource.PlayOneShot(dragSound);
    }

    public void PlayDropSound()
    {
        soundAudioSource.PlayOneShot(dropSound);
    }

    public void PlayRunningSound()
    {
        soundAudioSource.PlayOneShot(runningSound);
    }

    public void PlayZoomInSound()
    {
        soundAudioSource.PlayOneShot(zoomInSound);
    }

    public void PlayZoomOutSound()
    {
        soundAudioSource.PlayOneShot(zoomOutSound);
    }

    public void PlayDoorOpensSound()
    {
        soundAudioSource.PlayOneShot(doorOpens);
    }
    public void PlayDoorCloseSound()
    {
        soundAudioSource.PlayOneShot(doorClose);
    }
}
