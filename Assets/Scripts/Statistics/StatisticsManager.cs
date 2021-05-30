using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsManager : MonoBehaviour
{
    public static StatisticsManager Instance { get; private set; }

    private GameStateManager gameStateManager;
    private UIManager uiManager;
    private Player player;

    private void Awake() => Instance = this;
    
    public void Activate()
    {
        uiManager = UIManager.Instance;
        player = Player.Instance;
        gameStateManager = GameStateManager.Instance;

        int planformId = PlayerPrefs.GetInt("currentPlatform");
        gameStateManager.SetCurrentPlatform((PlatformType)planformId);

        int currentLevel = PlayerPrefs.GetInt("currentLevel");
        int currentRooms = PlayerPrefs.GetInt("currentRooms");
        uiManager.SetLevelText(currentLevel);
        uiManager.SetRoomText(currentRooms);

        if (currentLevel == 1)
        {
            int startLife = PlayerPrefs.GetInt("startLife");
            int startCoins = PlayerPrefs.GetInt("startCoins");
            int startMiracles = PlayerPrefs.GetInt("startMiracles");
            player.SetStartItems(startLife, startCoins, startMiracles);
        }
        else
        {
            int currLife = PlayerPrefs.GetInt("currLife");
            int currCoins = PlayerPrefs.GetInt("currCoins");
            int currMiracles = PlayerPrefs.GetInt("currMiracles");
            player.SetStartItems(currLife, currCoins, currMiracles);
        }

    }

    public void OnRoomCompleted()
    {
        int currentRooms = PlayerPrefs.GetInt("currentRooms");
        int bestRooms = PlayerPrefs.GetInt("bestRooms");
        currentRooms++;
        PlayerPrefs.SetInt("currentRooms", currentRooms);
        if (currentRooms > bestRooms)
        {
            PlayerPrefs.SetInt("bestRooms", currentRooms);
        }
        uiManager.SetRoomText(currentRooms);
    }

    public void OnLevelCompleted()
    {
        int currentLevel = PlayerPrefs.GetInt("currentLevel");
        int bestLevel = PlayerPrefs.GetInt("bestLevel");
        currentLevel ++;
        PlayerPrefs.SetInt("currentLevel", currentLevel);
        if (currentLevel > bestLevel)
        {
            PlayerPrefs.SetInt("bestLevel", currentLevel);
        }

        PlayerPrefs.SetInt("currLife", player.GetLifeCount());
        PlayerPrefs.SetInt("currCoins", player.GetCoinCount());
        PlayerPrefs.SetInt("currMiracles", player.GetMiracleCount());

        int allCoins = PlayerPrefs.GetInt("allCoins");
        allCoins += PlayerPrefs.GetInt("currCoins");
        PlayerPrefs.SetInt("allCoins", allCoins);
    }

    public int GetCurrLevel()
    {
        return PlayerPrefs.GetInt("currentLevel");
    }
    public int GetBestLevel()
    {
        return PlayerPrefs.GetInt("bestLevel");
    }
    public int GetCurrRooms()
    {
        return PlayerPrefs.GetInt("currentRooms");
    }
    public int GetBestRooms()
    {
        return PlayerPrefs.GetInt("bestRooms");
    }
    public int GetCurrCoins()
    {
        return PlayerPrefs.GetInt("currentRooms");
    }
    public int GetAllCoins()
    {
        return PlayerPrefs.GetInt("allCoins");
    }



}
