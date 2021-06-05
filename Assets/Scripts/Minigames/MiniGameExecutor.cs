using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;
using System;

public class MiniGameExecutor : MonoBehaviour
{
    [Space(10)]
    [SerializeField] private List<MiniGame> miniGames = new List<MiniGame>();
    [SerializeField] private List<MiniGame> vrMiniGames = new List<MiniGame>();

    private Dictionary<MinigameInfo, MiniGame> miniGamesDictionary = new Dictionary<MinigameInfo, MiniGame>();

    private MiniGame currentMiniGame;

    private UIManager uiManager;
    private PostProcessingManager postProcessingManager;
    private GameStateManager gameStateManager;
    private Player player;
    private PlatformManager platformManager;
    private PlatformType currentPlatform;

    public void Activate()
    {
        uiManager = UIManager.Instance;
        postProcessingManager = PostProcessingManager.Instance;
        gameStateManager = GameStateManager.Instance;
        player = Player.Instance;

        platformManager = PlatformManager.Instance;
        currentPlatform = platformManager.GetCurrentPlatform();

        if(currentPlatform == PlatformType.VR)
        {
            foreach (MiniGame miniGame in vrMiniGames)
            {
                miniGamesDictionary.Add(miniGame.GetMinigameInfo(), miniGame);
                miniGame.Activate();
            }
        }
        else
        {
            foreach (MiniGame miniGame in miniGames)
            {
                miniGamesDictionary.Add(miniGame.GetMinigameInfo(), miniGame);
                miniGame.Activate();
            }
        }
        
    }
    public void Execute(MinigameInfo minigameInfo, Vector3 position, DifficultyType difficultyType)
    {
        currentMiniGame = miniGamesDictionary[minigameInfo];

        currentMiniGame.transform.position = position;


        currentMiniGame.ShowMiniGame();

        Action afterAnimAction = () =>
        {
            uiManager.ShowMiraclePanel();
            uiManager.ShowTimerPanel();
            currentMiniGame.EnableMiniGame();
        };

        if (currentPlatform == PlatformType.VR)
        {
            currentMiniGame.transform.positionTransition(position + new Vector3(0, 4, 0), 1)
                                 .EventTransition(afterAnimAction, 1);
        }
        else
        {
            currentMiniGame.transform.positionTransition(position + new Vector3(0, 5, 0), 1)
                                 .EventTransition(afterAnimAction, 1);
            postProcessingManager.FocusOnDomino();
        }
    }

    public void HideGame(MiniGameResultType result)
    {
        currentMiniGame.DisableMiniGame();

        uiManager.HideMiraclePanel();
        uiManager.HideTimerPanel();

        Action afterAnimAction = () =>
        {
            postProcessingManager.FocusOnRoom();
            currentMiniGame.ClearPlacesForDomino();
            currentMiniGame.RenewMiniGame();
            if (player.IsAlive())
            {
                gameStateManager.EndCurrentState();
            }
        };

        currentMiniGame.transform.positionTransition(currentMiniGame.transform.position - new Vector3(0,10, 0), 1)
                                 .EventTransition(afterAnimAction, 1);
    }

    public SelectionSet GenerateSelectionSet()
    {
        return currentMiniGame.GenerateSelectionSet();
    }

    public MinigameInfo GetCurrentMinigame()
    {
        return currentMiniGame.GetMinigameInfo();
    }
}
