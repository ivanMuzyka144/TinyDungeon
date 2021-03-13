using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }

    [SerializeField] Player player_PB;

    private GameState currentState;

    private DoorShower doorShower;
    private Player player;

    
    private void Awake() => Instance = this;

    private void SetState(GameState gameState)
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
