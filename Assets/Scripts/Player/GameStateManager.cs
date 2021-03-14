using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }

    private DoorShower doorShower;
    private Player player;
    private MinigameSimulator minigameSimulator;

    private GameState currentState;
    private RoomType selectedDoorDirection;
    
    private void Awake() => Instance = this;

    public void Activate()
    {
        doorShower = DoorShower.Instance;
        player = Player.Instance;
        minigameSimulator = MinigameSimulator.Instance;
    }

    public void SetState(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.PlayerSelectDoor:
                currentState = GameState.PlayerSelectDoor;
                doorShower.ShowDoorsUpAnim();
                break;
            case GameState.DoorsOpen:
                if(currentState == GameState.PlayerSelectDoor)
                {
                    currentState = GameState.DoorsOpen;
                    doorShower.ShowTwoDoorsOpenAnim(selectedDoorDirection);
                }
                break;
            case GameState.PlayerMove:
                if (currentState == GameState.DoorsOpen)
                {
                    currentState = GameState.PlayerMove;
                    player.MoveToAnotherRoom(selectedDoorDirection);
                }
                break;
            case GameState.DoorsClose:
                if (currentState == GameState.PlayerMove)
                {
                    currentState = GameState.DoorsClose;
                    doorShower.ShowTwoDoorsCloseAnim(selectedDoorDirection);
                }
                break;
            case GameState.PlayerMinigame:
                if (currentState == GameState.DoorsClose)
                {
                    currentState = GameState.PlayerMinigame;
                    minigameSimulator.StartMinigame();
                }
                break;
        }
    }

    public void SetDoorDirection(RoomType roomType)
    {
        selectedDoorDirection = roomType;
    }
}

public enum GameState
{
    PlayerSelectDoor,
    DoorsOpen,
    PlayerMove,
    DoorsClose,
    PlayerMinigame
}
