using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioManager : MonoBehaviour
{
    public static GameAudioManager Instance { get; private set; }

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
    [SerializeField] private AudioClip wood;
    [SerializeField] private AudioClip loose;
    [SerializeField] private AudioClip win;
    [SerializeField] private AudioClip miracle;
    [SerializeField] private AudioClip item;
    [SerializeField] private AudioClip gameOverVoice;
    [SerializeField] private AudioClip gameOverMelody;
    [SerializeField] private AudioClip chain;
    [SerializeField] private AudioClip unlock;
    [SerializeField] private AudioClip yoohoo;
    [SerializeField] private AudioClip winMelody;
    [SerializeField] private AudioClip confettiPop;
    [Space(10)]
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioSource soundAudioSource;

    private void Awake() => Instance = this;

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

    public void PlayDragSound() => soundAudioSource.PlayOneShot(dragSound);
    public void PlayDropSound() => soundAudioSource.PlayOneShot(dropSound);
    public void PlayRunningSound() => soundAudioSource.PlayOneShot(runningSound);
    public void PlayZoomInSound() => soundAudioSource.PlayOneShot(zoomInSound);
    public void PlayZoomOutSound() => soundAudioSource.PlayOneShot(zoomOutSound);
    public void PlayDoorOpensSound() =>soundAudioSource.PlayOneShot(doorOpens);
    public void PlayDoorCloseSound() => soundAudioSource.PlayOneShot(doorClose);
    public void PlayWoodSound() => soundAudioSource.PlayOneShot(wood);
    public void PlayLooseSound() => soundAudioSource.PlayOneShot(loose);
    public void PlayWinSound() => soundAudioSource.PlayOneShot(win);
    public void PlayMiracleSound() => soundAudioSource.PlayOneShot(miracle);
    public void PlayItemSound() => soundAudioSource.PlayOneShot(item);
    public void PlayGameOverSound() 
    {
        soundAudioSource.PlayOneShot(gameOverVoice);
    }

    public void PlayChainSound() => soundAudioSource.PlayOneShot(chain);
    public void PlayUnlockSound() => soundAudioSource.PlayOneShot(unlock);
    public void PlayGameWinSound()
    {
        StartCoroutine(PlayOneMoreTime());
        soundAudioSource.PlayOneShot(confettiPop);
    }

    IEnumerator PlayOneMoreTime()
    {
        yield return new WaitForSeconds(0.7f);
        soundAudioSource.PlayOneShot(yoohoo);
        soundAudioSource.PlayOneShot(winMelody);
        soundAudioSource.PlayOneShot(confettiPop);
        StartCoroutine(PlayTwoMoreTime());
    }

    IEnumerator PlayTwoMoreTime()
    {
        yield return new WaitForSeconds(0.3f);
        //soundAudioSource.PlayOneShot(confettiPop);
    }
}
