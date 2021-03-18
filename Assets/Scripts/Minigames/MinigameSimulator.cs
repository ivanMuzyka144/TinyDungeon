using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameSimulator : MonoBehaviour
{
    public static MinigameSimulator Instance { get; private set; }

    [SerializeField] private GameObject minigamePanel;

    private GameStateManager gameStateManager;
    private void Awake() => Instance = this;

    public void Activate()
    {
        gameStateManager = GameStateManager.Instance;
    }

    public void StartMinigame(object sender, EventArgs e)
    {
        minigamePanel.SetActive(true);
        StartCoroutine(EndMinigame(1.5f));
    }

    IEnumerator EndMinigame(float sec)
    {
        yield return new WaitForSeconds(sec);
        minigamePanel.SetActive(false);
        gameStateManager.SetState(GameStateType.PlayerSelectDoor);
    }
}