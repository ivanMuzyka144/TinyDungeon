using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VRGameOverPanel : MonoBehaviour
{
    [SerializeField] private Text currLevelText;
    [SerializeField] private Text bestLevelText;
    [SerializeField] private Text currRoomsText;
    [SerializeField] private Text bestRoomsText;
    [SerializeField] private Text currCoinsText;
    [SerializeField] private Text allCoinsText;

    private StatisticsManager statisticsManager;
    private void Start()
    {
        statisticsManager = StatisticsManager.Instance;
        currLevelText.text = statisticsManager.GetCurrLevel() + "";
        bestLevelText.text = statisticsManager.GetBestLevel() + "";
        currRoomsText.text = statisticsManager.GetCurrRooms() + "";
        bestRoomsText.text = statisticsManager.GetBestRooms() + "";
        currCoinsText.text = statisticsManager.GetCurrCoins() + "";
        allCoinsText.text = statisticsManager.GetAllCoins() + "";
    }
    public void TryAgain()
    {
        SceneManager.LoadScene("VRGameScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("StartVRScene");
    }
    
}
