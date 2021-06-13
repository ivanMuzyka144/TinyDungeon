using UnityEngine;

public class Options : MonoBehaviour
{
    public static Options Instance { get; private set; }
    public bool canPlayMusic { get; private set; }
    public bool canPlaySound { get; private set; }
    public float musicVolume { get; private set; }
    public float soundVolume { get; private set; }

    public void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        canPlayMusic = PlayerPrefs.GetInt("shouldPlayMusic") == 1;
        canPlaySound = PlayerPrefs.GetInt("shouldPlaySound") == 1;
        musicVolume = PlayerPrefs.GetFloat("musicVolume");
        soundVolume = PlayerPrefs.GetFloat("soundVolume");
    }
    public void ChangeCanPlayMusic(bool status)
    {
        canPlayMusic = status;
        PlayerPrefs.SetInt("shouldPlayMusic", status ? 1 : 0);
    }
    public void ChangeCanPlaySound(bool status)
    {
        canPlaySound = status;
        PlayerPrefs.SetInt("shouldPlaySound", status ? 1 : 0);
    }
    public void ChangeMusicVolume(float value)
    {
        musicVolume = value;
        PlayerPrefs.SetFloat("musicVolume", value);
    }
    public void ChangeSoundVolume(float value)
    {
        soundVolume = value;
        PlayerPrefs.SetFloat("soundVolume", value);
    }

}
