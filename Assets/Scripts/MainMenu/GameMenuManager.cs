using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuManager : MonoBehaviour
{
    [SerializeField] private SelectionManager selectionManager;
    [SerializeField] private GameAudioManager gameAudioManager;
    [Space(10)]
    [SerializeField] private Options options;
    [Space(10)]
    [SerializeField] private Toggle musicToggle;
    [SerializeField] private Toggle soundToggle;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundSlider;
    [SerializeField] private Dropdown languageDropdown;
    [SerializeField] private GameObject optionsWindow;
    [SerializeField] private AudioMixer audioMixer;
    private void Start()
    {
        audioMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("musicVolume"));
        audioMixer.SetFloat("SoundVolume", PlayerPrefs.GetFloat("soundVolume"));
        if (PlayerPrefs.GetInt("shouldPlayMusic") == 0)
        {
            audioMixer.SetFloat("MusicVolume", -80);
        }
        if (PlayerPrefs.GetInt("shouldPlaySound") == 0)
        {
            audioMixer.SetFloat("SoundVolume", -80);
        }
    }
    public void OnMenuClicked()
    {
        //LeanTransition leanTrasition = GameObject.Find("LeanTransition").GetComponent<LeanTransition>();
        //leanTrasition.DefaultTiming = LeanTiming.Update;
        Time.timeScale = 0;
        selectionManager.Pause();
    }

    public void OnExitClicked()
    {
        gameAudioManager.PlayButtonClickMusic();
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScene");
    }

    public void OnAllMenuClosed()
    {
        gameAudioManager.PlayButtonClickMusic();
        Time.timeScale = 1;
        selectionManager.Unpause();
    }

    public void OnOptionsClicked()
    {
        gameAudioManager.PlayButtonClickMusic();
        optionsWindow.SetActive(true);
        musicToggle.isOn = PlayerPrefs.GetInt("shouldPlayMusic") == 1;
        soundToggle.isOn = PlayerPrefs.GetInt("shouldPlaySound") == 1;
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        soundSlider.value = PlayerPrefs.GetFloat("soundVolume");
    }

    public void OnOptionsWindowClosed()
    {
        gameAudioManager.PlayButtonClickMusic();
        optionsWindow.SetActive(false);
    }

    public void OnMusicToggleChanged(bool result)
    {
        options.ChangeCanPlayMusic(result);
        if (PlayerPrefs.GetInt("shouldPlayMusic") == 0)
        {
            audioMixer.SetFloat("MusicVolume", -80);
        }
        else
        {
            audioMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("musicVolume"));
        }
        gameAudioManager.PlayButtonClickMusic();
    }

    public void OnSoundToggleChanged(bool result)
    {
        options.ChangeCanPlaySound(result);
        if (PlayerPrefs.GetInt("shouldPlaySound") == 0)
        {
            audioMixer.SetFloat("SoundVolume", -80);
        }
        else
        {
            audioMixer.SetFloat("SoundVolume", PlayerPrefs.GetFloat("soundVolume"));
        }
        gameAudioManager.PlayButtonClickMusic();
    }

    public void OnMusicSliderChanged()
    {
        gameAudioManager.PlaySoftButtonClickMusic();
        options.ChangeMusicVolume(musicSlider.value);
        if (PlayerPrefs.GetInt("shouldPlayMusic") == 1)
        {
            audioMixer.SetFloat("MusicVolume", musicSlider.value);
        }
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
    }
    public void OnSoundSliderChanged()
    {
        gameAudioManager.PlaySoftButtonClickMusic();
        options.ChangeSoundVolume(soundSlider.value);
        if (PlayerPrefs.GetInt("shouldPlaySound") == 1)
        {
            audioMixer.SetFloat("SoundVolume", soundSlider.value);
        }
        PlayerPrefs.SetFloat("soundVolume", soundSlider.value);
    }

    public void OnLanguageDropdownChanged()
    {
        gameAudioManager.PlayButtonClickMusic();
        Debug.Log("" + languageDropdown.value);
    }
    
}
