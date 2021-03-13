using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }

    private GameState currentState;

    private DoorShower doorShower;
    private Player player;

    private RoomType selectedDoorDirection;
    
    private void Awake() => Instance = this;

    public void Activate()
    {
        doorShower = DoorShower.Instance;
        player = Player.Instance;
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
            case GameState.PlayerMinigame:
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
    PlayerMinigame
}
