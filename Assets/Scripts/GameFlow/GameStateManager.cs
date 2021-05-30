using System;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }

    private DoorShower doorShower;
    private AnimationManager animationManager;
    private Player player;
    private MinigameManager minigameSimulator;
    private UIManager uiManager;
    private GamepadSelectionManager gamepadSelectionManager;
    private PlatformManager platformManager;

    private GameStateNode currentNode;
    private RoomType selectedDoorDirection;
    private MiniGameResultType lastMinigameResult;

    private Dictionary<GameStateType, GameStateNode> gameStateDictionary = new Dictionary<GameStateType, GameStateNode>();

    private PlatformType currentPlatform;
    private void Awake() => Instance = this;

    public void Activate()
    {
        doorShower = DoorShower.Instance;
        animationManager = AnimationManager.Instance;
        player = Player.Instance;
        minigameSimulator = MinigameManager.Instance;
        uiManager = UIManager.Instance;
        gamepadSelectionManager = GamepadSelectionManager.Instance;
        platformManager = PlatformManager.Instance;

        animationManager.Activate();

        GameStateNode selectionDoorNode = new GameStateNode(GameStateType.PlayerSelectDoor,
                                                     new[] { GameStateType.PlayerMinigame},
                                                    new [] {GameStateType.PlayerMove});
        GameStateNode movemntNode = new GameStateNode(GameStateType.PlayerMove,
                                              new [] { GameStateType.PlayerSelectDoor },
                                               new[] { GameStateType.PlayerMinigame,
                                                        GameStateType.Finish,});
        GameStateNode minigameNode = new GameStateNode(GameStateType.PlayerMinigame,
                                                new[] { GameStateType.PlayerMove},
                                                new [] {GameStateType.PlayerSelectDoor,
                                                        GameStateType.GameOver,});
        GameStateNode gameOverNode = new GameStateNode(GameStateType.GameOver,
                                               new[] { GameStateType.PlayerMinigame},
                                               new[] { GameStateType.None});
        GameStateNode finishNode = new GameStateNode(GameStateType.Finish,
                                               new[] { GameStateType.PlayerMove },
                                               new[] { GameStateType.None });

        currentPlatform = platformManager.GetCurrentPlatform();

        selectionDoorNode.OnStateStarted += doorShower.ShowDoorsUpAnim;
        selectionDoorNode.OnStateEnded += doorShower.ShowDoorsBackAnim;

        if (currentPlatform == PlatformType.Console)
        {
            gamepadSelectionManager.Activate();
            selectionDoorNode.OnStateStarted += gamepadSelectionManager.SetDoorSelecting;
            selectionDoorNode.OnStateEnded += gamepadSelectionManager.RemoveDoorSelecting;
        }


        movemntNode.OnStateStarted += animationManager.MakeMovementSequence;
        
       
        minigameNode.OnStateStarted += minigameSimulator.StartMinigame;
        if (currentPlatform == PlatformType.Console)
        {
            minigameNode.OnStateStarted += gamepadSelectionManager.SetMinigameSelecting;
            minigameNode.OnStateEnded += gamepadSelectionManager.RemoveMinigameSelecting;
        }
        minigameNode.OnStateEnded += player.CollectItem;



        gameOverNode.OnStateStarted += uiManager.ShowGameOverScreen;

        finishNode.OnStateStarted += animationManager.ShowFinishAnim;

        gameStateDictionary.Add(GameStateType.PlayerSelectDoor, selectionDoorNode);
        gameStateDictionary.Add(GameStateType.PlayerMove, movemntNode);
        gameStateDictionary.Add(GameStateType.PlayerMinigame, minigameNode);
        gameStateDictionary.Add(GameStateType.GameOver, gameOverNode);
        gameStateDictionary.Add(GameStateType.Finish, finishNode);
    }

    public void SetStartState()
    {
        currentNode = gameStateDictionary[GameStateType.PlayerSelectDoor];
        currentNode.OnStateStarted.Invoke(this, EventArgs.Empty);
    }
    public void EndCurrentState()
    {
        GSEventArgs gsEventArgs = new GSEventArgs();
        gsEventArgs.direction = selectedDoorDirection;
        gsEventArgs.lastMinigameResult = lastMinigameResult;

        currentNode.OnStateEnded.Invoke(this, gsEventArgs);
    }
    public void ChangeState(GameStateType gameStateType)
    {
        GameStateNode nextNode = gameStateDictionary[gameStateType];

        if(currentNode.IsPreviousFor(nextNode.GetGameStateType()))
        {
            GSEventArgs gsEventArgs = new GSEventArgs();
            gsEventArgs.direction = selectedDoorDirection;
            gsEventArgs.lastMinigameResult = lastMinigameResult;

            currentNode = nextNode;
            currentNode.OnStateStarted(this, gsEventArgs);
        }
    }

    
    public void SetDoorDirection(RoomType roomType)
    {
        selectedDoorDirection = roomType;
    }

    public void SetMinigameResult(MiniGameResultType miniGameResultType)
    {
        lastMinigameResult = miniGameResultType;
    }

    public void SetCurrentPlatform(PlatformType platformType)
    {
        currentPlatform = platformType;
    }
}

public enum GameStateType
{
    PlayerSelectDoor,
    PlayerMove,
    PlayerMinigame,
    GameOver,
    Finish,
    None
}

public enum MiniGameResultType
{
    Win,
    UseMiracle,
    Lose,
    TimeOver,
    None
}

public class GSEventArgs : EventArgs
{
    public RoomType direction;
    public MiniGameResultType lastMinigameResult;
}
