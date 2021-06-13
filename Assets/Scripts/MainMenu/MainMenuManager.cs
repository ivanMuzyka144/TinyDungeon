using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private MainMenuAudioManager mainMenuAudioManager;
    [Space(10)]
    [SerializeField] private GameObject creditsWindow;
    [SerializeField] private GameObject optionsWindow;
    [Space(10)]
    [SerializeField] private Options options;
    [Space(10)]
    [SerializeField] private Toggle musicToggle;
    [SerializeField] private Toggle soundToggle;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundSlider;
    [SerializeField] private Dropdown languageDropdown;
    [Space(10)]
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
    public void OnStartClicked()
    {
        PlayerPrefs.SetInt("currentLevel",1);
        PlayerPrefs.SetInt("currentRooms", 0);
        SceneManager.LoadScene("SampleScene");
        mainMenuAudioManager.PlayButtonClickMusic();
    }
    public void OnOptionsClicked()
    {
        mainMenuAudioManager.PlayButtonClickMusic();
        optionsWindow.SetActive(true);
        //<----------------
        musicToggle.isOn = PlayerPrefs.GetInt("shouldPlayMusic") == 1;
        soundToggle.isOn = PlayerPrefs.GetInt("shouldPlaySound") == 1;
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        soundSlider.value = PlayerPrefs.GetFloat("soundVolume");
    }

    public void OnCreditsClicked()
    {
        mainMenuAudioManager.PlayButtonClickMusic();
        creditsWindow.SetActive(true);
    }

    public void OnCreditsExitClicked()
    {
        mainMenuAudioManager.PlayButtonClickMusic();
        creditsWindow.SetActive(false);
    }

    public void OnOptionsExitClicked()
    {
        mainMenuAudioManager.PlayButtonClickMusic();
        optionsWindow.SetActive(false);
    }

    public void OnExitClicked()
    {
        mainMenuAudioManager.PlayButtonClickMusic();
        Application.Quit();
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
        mainMenuAudioManager.PlayButtonClickMusic();
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
        mainMenuAudioManager.PlayButtonClickMusic();
    }

    public void OnMusicSliderChanged()
    {
        mainMenuAudioManager.PlaySoftButtonClickMusic();
        options.ChangeMusicVolume(musicSlider.value);
        if (PlayerPrefs.GetInt("shouldPlayMusic") == 1)
        {
            audioMixer.SetFloat("MusicVolume", musicSlider.value);
        }
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
    }
    public void OnSoundSliderChanged()
    {
        mainMenuAudioManager.PlaySoftButtonClickMusic();
        options.ChangeSoundVolume(soundSlider.value);
        if (PlayerPrefs.GetInt("shouldPlaySound") == 1)
        {
            audioMixer.SetFloat("SoundVolume", soundSlider.value);
        }
        PlayerPrefs.SetFloat("soundVolume", soundSlider.value);
    }

    public void OnLanguageDropdownChanged()
    {
        mainMenuAudioManager.PlayButtonClickMusic();
        Debug.Log("" + languageDropdown.value);
    }
}
