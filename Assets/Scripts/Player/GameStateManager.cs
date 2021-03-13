using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }

    private GameState currentState;

    private DoorShower doorShower;
    private Player player;

    
    private void Awake() => Instance = this;

    public void Activate()
    {
        doorShower = DoorShower.Instance;
    }

    public void SetState(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.PlayerSelectDoor:
                doorShower.ShowDoorsUpAnim();
                break;
            case GameState.PlayerMove:
                doorShower.ShowDoorsBackAnim();
                break;
            case GameState.PlayerMinigame:
                break;
        }
    }
}

public enum GameState
{
    PlayerSelectDoor,
    PlayerMove,
    PlayerMinigame
}
