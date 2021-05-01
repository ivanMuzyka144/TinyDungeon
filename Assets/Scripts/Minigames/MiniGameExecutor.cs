using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;
using System;

public class MiniGameExecutor : MonoBehaviour
{
    //[SerializeField] private Volume volume;
    [Space(10)]
    [SerializeField] private List<MiniGame> miniGames = new List<MiniGame>();

    private Dictionary<MinigameInfo, MiniGame> miniGamesDictionary = new Dictionary<MinigameInfo, MiniGame>();

    private MiniGame currentMiniGame;

    private UIManager uiManager;
    private PostProcessingManager postProcessingManager;
    private GameStateManager gameStateManager;
    private Player player;

    public void Activate()
    {
        uiManager = UIManager.Instance;
        postProcessingManager = PostProcessingManager.Instance;
        gameStateManager = GameStateManager.Instance;
        player = Player.Instance;

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

        postProcessingManager.FocusOnDomino();

        currentMiniGame.ShowMiniGame();

        Action afterAnimAction = () =>
        {
            uiManager.ShowMiraclePanel();
            uiManager.ShowTimerPanel();
            currentMiniGame.EnableMiniGame();
        };

        currentMiniGame.transform.positionTransition(position + new Vector3(0, 7, 0), 1)
                                 .EventTransition(afterAnimAction, 1);
    }

    public void HideGame(MiniGameResultType result)
    {
        currentMiniGame.DisableMiniGame();

        uiManager.HideMiraclePanel();
        uiManager.HideTimerPanel();

        Action afterAnimAction = () =>
        {
            postProcessingManager.FocusOnRoom();
            currentMiniGame.RenewMiniGame();
            if (player.IsAlive())
            {
                gameStateManager.EndCurrentState();
            }
        };

        currentMiniGame.transform.positionTransition(currentMiniGame.transform.position - new Vector3(0,13, 0), 1)
                                 .EventTransition(afterAnimAction, 1);
    }
   
}
