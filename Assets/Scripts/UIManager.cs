using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject miraclePanel;
    [SerializeField] private GameObject timerPanel;
    [SerializeField] private GameObject gameMenuPanel;
    [SerializeField] private GameObject askMenuPanel;
    [Space(10)]
    [SerializeField] private Text levelText;
    [SerializeField] private Text roomsText;
    [Space(10)]
    [SerializeField] private Text currLevelText;
    [SerializeField] private Text bestLevelText;
    [SerializeField] private Text currRoomsText;
    [SerializeField] private Text bestRoomsText;
    [SerializeField] private Text currCoinsText;
    [SerializeField] private Text allCoinsText;
    [Space(10)]
    [SerializeField] private StatisticsManager statisticsManager;

    private void Awake() => Instance = this;

    public void ShowMiraclePanel() => miraclePanel.SetActive(true);
    public void HideMiraclePanel() => miraclePanel.SetActive(false);
    public void ShowTimerPanel() => timerPanel.SetActive(true);
    public void HideTimerPanel() => timerPanel.SetActive(false);
    public void SetLevelText(int lvlNumb) => levelText.text = lvlNumb + "";
    public void SetRoomText(int roomNumb) => roomsText.text = roomNumb + "";
    public void ShowGameMenuPanel()
    {
        Time.timeScale = 0;
        gameMenuPanel.SetActive(true);
    }
    public void HideGameMenuPanel()
    {
        Time.timeScale = 1;
        gameMenuPanel.SetActive(false);
    }

    public void ShowAskPanel() => askMenuPanel.SetActive(true);
    public void HideAskPanel() => askMenuPanel.SetActive(false);
    public void ShowGameOverScreen(object sender, EventArgs e)
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);

        currLevelText.text = statisticsManager.GetCurrLevel() + "";
        bestLevelText.text = statisticsManager.GetBestLevel() + "";
        currRoomsText.text = statisticsManager.GetCurrRooms() + "";
        bestRoomsText.text = statisticsManager.GetBestRooms() + "";
        currCoinsText.text = statisticsManager.GetCurrCoins() + "";
        allCoinsText.text = statisticsManager.GetAllCoins() + "";
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
}
