using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;
using System;
using UnityEngine.Rendering;

public class MiniGameExecutor : MonoBehaviour
{
    [SerializeField] private Volume volume;
    [Space(10)]
    [SerializeField] private List<MiniGame> miniGames = new List<MiniGame>();

    private Dictionary<MinigameInfo, MiniGame> miniGamesDictionary = new Dictionary<MinigameInfo, MiniGame>();

    private MiniGame currentMiniGame;

    private UIManager uiManager;
    private GameStateManager gameStateManager;

    public void Activate()
    {
        uiManager = UIManager.Instance;
        gameStateManager = GameStateManager.Instance;

        foreach (MiniGame miniGame in miniGames)
        {
            miniGamesDictionary.Add(miniGame.GetMinigameInfo(), miniGame);
            miniGame.Activate();
        }
    }
    public void Execute(MinigameInfo minigameInfo, Vector3 position, DifficultyType difficultyType)
    {
        currentMiniGame = miniGamesDictionary[minigameInfo];

        currentMiniGame.transform.position = position;

        volume.profile.components[0].active = true;

        currentMiniGame.ShowMiniGame();

        Action afterAnimAction = () =>
        {
            uiManager.ShowMiraclePanel();
            currentMiniGame.EnableMiniGame();
        };

        currentMiniGame.transform.positionTransition(position + new Vector3(0, 7, 0), 1)
                                 .EventTransition(afterAnimAction, 1);
    }

    public void HideGame()
    {
        currentMiniGame.DisableMiniGame();
        uiManager.HideMiraclePanel();

        Action afterAnimAction = () =>
        {
            volume.profile.components[0].active = false;
            currentMiniGame.RenewMiniGame();
            gameStateManager.EndCurrentState();
        };

        currentMiniGame.transform.positionTransition(currentMiniGame.transform.position - new Vector3(0,10, 0), 1)
                                 .EventTransition(afterAnimAction, 1);
    }
   
}
