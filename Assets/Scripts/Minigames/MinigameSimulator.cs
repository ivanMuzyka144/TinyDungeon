using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameSimulator : MonoBehaviour
{
    public static MinigameSimulator Instance { get; private set; }

    [SerializeField] private GameObject minigamePanel;

    private GameStateManager gameStateManager;
    private Player player;
    private MinigameTimer minigameTimer;

    private void Awake() => Instance = this;

    public void Activate()
    {
        gameStateManager = GameStateManager.Instance;
        player = Player.Instance;
        minigameTimer = GetComponent<MinigameTimer>();
        minigameTimer.Activate();
    }

    public void StartMinigame(object sender, EventArgs e)
    {
        minigamePanel.SetActive(true);
        minigameTimer.StartTimer(1.5f);
    }

    public void WinMiniGame()
    {
        minigameTimer.InterruptTimer();
        minigamePanel.SetActive(false);
        gameStateManager.EndCurrentState();
    }
    public void LoseMiniGame()
    {
        Debug.Log("LOSE");
        player.RemoveLife();
        minigameTimer.InterruptTimer();
        minigamePanel.SetActive(false);
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
        gameStateManager.EndCurrentState();
    }

    public void  EndTimeMinigame()
    {
        Debug.Log("TimeEnded");
        player.RemoveLife();
        minigamePanel.SetActive(false);
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