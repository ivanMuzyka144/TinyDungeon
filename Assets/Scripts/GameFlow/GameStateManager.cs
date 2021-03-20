using System;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }

    private DoorShower doorShower;
    private AnimationManager animationManager;
    private Player player;
    private MinigameSimulator minigameSimulator;
    private UIManager uiManager;

    private GameStateNode currentNode;
    private RoomType selectedDoorDirection;

    private Dictionary<GameStateType, GameStateNode> gameStateDictionary = new Dictionary<GameStateType, GameStateNode>();

    private void Awake() => Instance = this;

    public void Activate()
    {
        doorShower = DoorShower.Instance;
        animationManager = AnimationManager.Instance;
        player = Player.Instance;
        minigameSimulator = MinigameSimulator.Instance;
        uiManager = UIManager.Instance;

        animationManager.Activate();

        GameStateNode selectionDoorNode = new GameStateNode(GameStateType.PlayerSelectDoor,
                                                     new[] { GameStateType.PlayerMinigame},
                                                    new [] {GameStateType.PlayerMove});
        GameStateNode movemntNode = new GameStateNode(GameStateType.PlayerMove,
                                              new [] { GameStateType.PlayerSelectDoor },
                                               new[] { GameStateType.PlayerMinigame});
        GameStateNode minigameNode = new GameStateNode(GameStateType.PlayerMinigame,
                                                new[] { GameStateType.PlayerMove},
                                                new [] {GameStateType.PlayerSelectDoor,
                                                        GameStateType.GameOver,
                                                        GameStateType.Finish,});
        GameStateNode gameOverNode = new GameStateNode(GameStateType.GameOver,
                                               new[] { GameStateType.PlayerMinigame},
                                               new[] { GameStateType.None});

        selectionDoorNode.OnStateStarted += doorShower.ShowDoorsUpAnim;
        selectionDoorNode.OnStateEnded += doorShower.ShowDoorsBackAnim;

        movemntNode.OnStateStarted += animationManager.MakeMovementSequence;

        minigameNode.OnStateStarted += minigameSimulator.StartMinigame;
        minigameNode.OnStateEnded += player.CollectItem;

        gameOverNode.OnStateStarted += uiManager.ShowGameOverScreen;

        gameStateDictionary.Add(GameStateType.PlayerSelectDoor, selectionDoorNode);
        gameStateDictionary.Add(GameStateType.PlayerMove, movemntNode);
        gameStateDictionary.Add(GameStateType.PlayerMinigame, minigameNode);
        gameStateDictionary.Add(GameStateType.GameOver, gameOverNode);
    }

    public void SetStartState()
    {
        currentNode = gameStateDictionary[GameStateType.PlayerSelectDoor];
        currentNode.OnStateStarted.Invoke(this, EventArgs.Empty);
    }
    public void EndCurrentState()
    {
        currentNode.OnStateEnded.Invoke(this, EventArgs.Empty);
    }
    public void ChangeState(GameStateType gameStateType)
    {
        
        GameStateNode nextNode = gameStateDictionary[gameStateType];

        if(currentNode.IsPreviousFor(nextNode.GetGameStateType()))
        {
            GSEventArgs gsEventArgs = new GSEventArgs();
            gsEventArgs.direction = selectedDoorDirection;

            nextNode.OnStateStarted(this, gsEventArgs);
            currentNode = nextNode;
        }
    }

    
    public void SetDoorDirection(RoomType roomType)
    {
        selectedDoorDirection = roomType;
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

public class GSEventArgs : EventArgs
{
    public RoomType direction;
}
