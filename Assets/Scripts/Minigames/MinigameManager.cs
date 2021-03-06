﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager Instance { get; private set; }

    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject timeEndedPanel;
    [Space(10)]
    [SerializeField] private MiracleParticle miracleParticle;
    [Space(10)]
    [SerializeField] private GameAudioManager gameAudioManager;

    private GameStateManager gameStateManager;
    private Player player;
    private MinigameTimer minigameTimer;
    private MiniGameExecutor miniGameExecutor;
    private StatisticsManager statisticsManager;


    private void Awake() => Instance = this;

    public void Activate()
    {
        gameStateManager = GameStateManager.Instance;
        player = Player.Instance;
        statisticsManager = StatisticsManager.Instance;
        minigameTimer = GetComponent<MinigameTimer>();
        miniGameExecutor = GetComponent<MiniGameExecutor>();
        minigameTimer.Activate();
        miniGameExecutor.Activate();
    }

    public void StartMinigame(object sender, EventArgs e)
    {
        Room currentRoom = player.GetCurrentRoom();
        RoomCategoryType roomCategoryType = currentRoom.GetCategory();
        if(roomCategoryType == RoomCategoryType.MinigameRoom
            && currentRoom.IsActiveForPlaying())
        {
            miniGameExecutor.Execute(currentRoom.GetMinigameInfo(), 
                                     currentRoom.transform.position, 
                                     DifficultyType.Easy);
            minigameTimer.StartTimer(currentRoom.GetMinigameInfo().GetTime());
        }
        else
        {
            gameStateManager.EndCurrentState();
            //gameStateManager.ChangeState(GameStateType.PlayerSelectDoor);
        }
    }

    public void WinMiniGame()
    {
        gameAudioManager.PlayWinSound();
        Room currentRoom = player.GetCurrentRoom();
        currentRoom.ActivateRoomTorches(GetCurrentMinigame());
        currentRoom.DeactivatePlaying();
        minigameTimer.InterruptTimer();
        miniGameExecutor.HideGame(MiniGameResultType.Win);
        gameStateManager.SetMinigameResult(MiniGameResultType.Win);
        StartCoroutine(ShowWinPanel(1f));
    }
    public void LoseMiniGame()
    {
        gameAudioManager.PlayLooseSound();
        player.RemoveLife();
        minigameTimer.InterruptTimer();
        miniGameExecutor.HideGame(MiniGameResultType.Lose);
        gameStateManager.SetMinigameResult(MiniGameResultType.Lose);
        StartCoroutine(ShowLosePanel(1f));
    }

    public void UseMiracleForMiniGame()
    {
        if (player.HasMiracle() && GetCurrentMinigame() != null)
        {
            miracleParticle.PlayParticle();
            Room currentRoom = player.GetCurrentRoom();
            currentRoom.ActivateRoomTorches(GetCurrentMinigame());
            currentRoom.DeactivatePlaying();
            player.RemoveMiracle();
            SkipWithMiracle();
        }
    }
    public void UseMiracleForMiniGame(bool shouldShowPosition)
    {
        if (player.HasMiracle() && GetCurrentMinigame() != null)
        {
            Room currentRoom = player.GetCurrentRoom();
            miracleParticle.PlayParticle(currentRoom.transform.position);
            currentRoom.ActivateRoomTorches(GetCurrentMinigame());
            currentRoom.DeactivatePlaying();
            player.RemoveMiracle();
            SkipWithMiracle();
        }
    }

    private void SkipWithMiracle()
    {
        gameAudioManager.PlayMiracleSound();
        miniGameExecutor.HideGame(MiniGameResultType.UseMiracle);
        minigameTimer.InterruptTimer();
        gameStateManager.SetMinigameResult(MiniGameResultType.UseMiracle);
        
    }

    public void  EndTimeMinigame()
    {
        gameAudioManager.PlayLooseSound();
        player.RemoveLife();
        miniGameExecutor.HideGame(MiniGameResultType.TimeOver);
        gameStateManager.SetMinigameResult(MiniGameResultType.TimeOver);
        StartCoroutine(ShowTimeEndedPanel(1f));

    }

    public SelectionSet GenerateSelectionSet()
    {
        SelectionSet setToReturn = null;

        Room currentRoom = player.GetCurrentRoom();
        RoomCategoryType roomCategoryType = currentRoom.GetCategory();
        if (roomCategoryType == RoomCategoryType.MinigameRoom
            && currentRoom.IsActiveForPlaying())
        {
            setToReturn = miniGameExecutor.GenerateSelectionSet();
        }
        
        return setToReturn;
    }

    public MinigameInfo GetCurrentMinigame()
    {
        return miniGameExecutor.GetCurrentMinigame();
    }

    IEnumerator ShowWinPanel(float sec)
    {
        winPanel.SetActive(true);
        yield return new WaitForSeconds(sec);
        statisticsManager.OnRoomCompleted();
        winPanel.SetActive(false);
    }

    IEnumerator ShowLosePanel(float sec)
    {
        losePanel.SetActive(true);
        yield return new WaitForSeconds(sec);
        losePanel.SetActive(false);
    }
    IEnumerator ShowTimeEndedPanel(float sec)
    {
        timeEndedPanel.SetActive(true);
        yield return new WaitForSeconds(sec);
        timeEndedPanel.SetActive(false);
    }
}