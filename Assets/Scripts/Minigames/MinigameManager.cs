﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager Instance { get; private set; }

    [SerializeField] private GameObject minigamePanel;

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
        Debug.Log(currentRoom.GetMinigameInfo());
        RoomCategoryType roomCategoryType = currentRoom.GetCategory();
        if(roomCategoryType == RoomCategoryType.MinigameRoom)
        {
            //minigamePanel.SetActive(true);
            miniGameExecutor.Execute(currentRoom.GetMinigameInfo(), 
                                     currentRoom.transform.position, 
                                     DifficultyType.Easy);
            //minigameTimer.StartTimer(1.5f);
        }
        else
        {
            gameStateManager.ChangeState(GameStateType.PlayerSelectDoor);
        }
    }

    public void WinMiniGame()
    {
        minigameTimer.InterruptTimer();
        //minigamePanel.SetActive(false);
        miniGameExecutor.HideGame();

        gameStateManager.SetMinigameResult(MiniGameResultType.Win);
        gameStateManager.EndCurrentState();
    }
    public void LoseMiniGame()
    {
        player.RemoveLife();
        minigameTimer.InterruptTimer();
        //minigamePanel.SetActive(false);
        miniGameExecutor.HideGame();

        gameStateManager.SetMinigameResult(MiniGameResultType.Lose);
        if (player.IsAlive())
        {
            gameStateManager.EndCurrentState();
        }
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
        Debug.Log("Miracle");
        minigameTimer.InterruptTimer();
        minigamePanel.SetActive(false);
        gameStateManager.SetMinigameResult(MiniGameResultType.UseMiracle);
        gameStateManager.EndCurrentState();
    }

    public void  EndTimeMinigame()
    {
        Debug.Log("TimeEnded");
        player.RemoveLife();
        minigamePanel.SetActive(false);
        gameStateManager.SetMinigameResult(MiniGameResultType.TimeOver);
        if (player.IsAlive())
        {
            gameStateManager.EndCurrentState();
        }
    
    }

    //IEnumerator EndMinigame(float sec)
    //{
    //    yield return new WaitForSeconds(sec);
    //    minigamePanel.SetActive(false);
    //    gameStateManager.EndCurrentState();
    //}
}