using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager Instance { get; private set; }

    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    private GameStateManager gameStateManager;
    private Player player;
    private MinigameTimer minigameTimer;
    private MiniGameExecutor miniGameExecutor;

    private void Awake() => Instance = this;

    public void Activate()
    {
        gameStateManager = GameStateManager.Instance;
        player = Player.Instance;
        minigameTimer = GetComponent<MinigameTimer>();
        miniGameExecutor = GetComponent<MiniGameExecutor>();
        minigameTimer.Activate();
        miniGameExecutor.Activate();
    }

    public void StartMinigame(object sender, EventArgs e)
    {
        Room currentRoom = player.GetCurrentRoom();
        RoomCategoryType roomCategoryType = currentRoom.GetCategory();
        if(roomCategoryType == RoomCategoryType.MinigameRoom)
        {
            miniGameExecutor.Execute(currentRoom.GetMinigameInfo(), 
                                     currentRoom.transform.position, 
                                     DifficultyType.Easy);
        }
        else
        {
            gameStateManager.ChangeState(GameStateType.PlayerSelectDoor);
        }
    }

    public void WinMiniGame()
    {
        minigameTimer.InterruptTimer();
        miniGameExecutor.HideGame();

        StartCoroutine(ShowWinPanel(1f));
    }
    public void LoseMiniGame()
    {
        player.RemoveLife();
        minigameTimer.InterruptTimer();
        miniGameExecutor.HideGame();

        StartCoroutine(ShowLosePanel(1f));
    }

    public void UseMiracleForMiniGame()
    {
        if (player.HasMiracle())
        {
            player.RemoveMiracle();
            SkipWithMiracle();
        }
    }

    private void SkipWithMiracle()
    {
        miniGameExecutor.HideGame();
        minigameTimer.InterruptTimer();
        gameStateManager.SetMinigameResult(MiniGameResultType.UseMiracle);
        
    }

    public void  EndTimeMinigame()
    {
        Debug.Log("TimeEnded");
        player.RemoveLife();
        gameStateManager.SetMinigameResult(MiniGameResultType.TimeOver);
        if (player.IsAlive())
        {
            gameStateManager.EndCurrentState();
        }
    
    }

    IEnumerator ShowWinPanel(float sec)
    {
        winPanel.SetActive(true);
        yield return new WaitForSeconds(sec);
        winPanel.SetActive(false);
        gameStateManager.SetMinigameResult(MiniGameResultType.Win);
        //gameStateManager.EndCurrentState();
    }

    IEnumerator ShowLosePanel(float sec)
    {
        losePanel.SetActive(true);
        yield return new WaitForSeconds(sec);
        losePanel.SetActive(false);
        gameStateManager.SetMinigameResult(MiniGameResultType.Lose);
        if (player.IsAlive())
        {
            gameStateManager.EndCurrentState();
        }
    }
}