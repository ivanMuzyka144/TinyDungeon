using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }

    private AnimationManager animationManager;

    private DoorShower doorShower;
    private Player player;
    private MinigameSimulator minigameSimulator;

    private GameStateNode currentNode;
    private RoomType selectedDoorDirection;

    private Dictionary<GameStateType, GameStateNode> gameStateDictionary = new Dictionary<GameStateType, GameStateNode>();

    private void Awake() => Instance = this;

    public void Activate()
    {
        animationManager = AnimationManager.Instance;
        doorShower = DoorShower.Instance;
        player = Player.Instance;
        minigameSimulator = MinigameSimulator.Instance;

        GameStateNode selectionDoorNode = new GameStateNode(GameStateType.PlayerSelectDoor, 
                                                            GameStateType.PlayerMove);
        GameStateNode movemntNode = new GameStateNode(GameStateType.PlayerMove,
                                                      GameStateType.PlayerMinigame);
        GameStateNode minigameNode = new GameStateNode(GameStateType.PlayerMinigame,
                                                      GameStateType.PlayerSelectDoor);

        selectionDoorNode.OnStateStarted += doorShower.ShowDoorsUpAnim;
        selectionDoorNode.OnStateEnded += doorShower.ShowDoorsBackAnim;
        movemntNode.OnStateStarted += animationManager.MakeMovementSequence;
        //movemntNode.OnStateEnded += 
        minigameNode.OnStateStarted += minigameSimulator.StartMinigame;

        gameStateDictionary.Add(GameStateType.PlayerSelectDoor, selectionDoorNode);
        gameStateDictionary.Add(GameStateType.PlayerMove, movemntNode);
        gameStateDictionary.Add(GameStateType.PlayerMinigame, minigameNode);
    }

    public void SetStartState()
    {
        currentNode = gameStateDictionary[GameStateType.PlayerSelectDoor];
        currentNode.OnStateEnded.Invoke(this, EventArgs.Empty);
    }
    public void EndCurrentState()
    {
        currentNode.OnStateEnded.Invoke(this, EventArgs.Empty);
    }
    public void ChangeState()
    {
        GameStateNode nextNode = gameStateDictionary[currentNode.GetNextStateType()];

        GSEventArgs gsEventArgs = new GSEventArgs();
        gsEventArgs.direction = selectedDoorDirection;

        nextNode.OnStateStarted(this, EventArgs.Empty);
        currentNode = nextNode;
    }

    //public void SetState(GameStateType gameState)
    //{
    //    switch (gameState)
    //    {
    //        case GameStateType.PlayerSelectDoor:
    //            Room room = player.GetCurrentRoom();
    //            if (room.HasItem())
    //                room.GetItem();
    //            ///---------
    //            currentState = GameStateType.PlayerSelectDoor;
    //            doorShower.ShowDoorsUpAnim();
    //            break;
    //        case GameStateType.DoorsOpen:
    //            if(currentState == GameStateType.PlayerSelectDoor)
    //            {
    //                currentState = GameStateType.DoorsOpen;
    //                doorShower.ShowTwoDoorsOpenAnim(selectedDoorDirection);
    //            }
    //            break;
    //        case GameStateType.PlayerMove:
    //            if (currentState == GameStateType.DoorsOpen)
    //            {
    //                currentState = GameStateType.PlayerMove;
    //                player.MoveToAnotherRoom(selectedDoorDirection);
    //            }
    //            break;
    //        case GameStateType.DoorsClose:
    //            if (currentState == GameStateType.PlayerMove)
    //            {
    //                currentState = GameStateType.DoorsClose;
    //                doorShower.ShowTwoDoorsCloseAnim(selectedDoorDirection);
    //            }
    //            break;
    //        case GameStateType.PlayerMinigame:
    //            if (currentState == GameStateType.DoorsClose)
    //            {
    //                currentState = GameStateType.PlayerMinigame;
    //                minigameSimulator.StartMinigame();
    //            }
    //            break;
    //    }
    //}

    public void SetDoorDirection(RoomType roomType)
    {
        selectedDoorDirection = roomType;
    }
}

public enum GameStateType
{
    PlayerSelectDoor,
    PlayerMove,
    PlayerMinigame
}

public class GSEventArgs : EventArgs
{
    public RoomType direction;
}
