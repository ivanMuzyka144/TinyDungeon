using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }

    [SerializeField] Player player_PB;

    private GameState currentState;

    private Player player;
    
    private void Awake() => Instance = this;

    private void SetState(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.PlayerSpawn:
                break;
            case GameState.PlayerSelectDoor:
                break;
            case GameState.PlayerMove:
                break;
            case GameState.PlayerMinigame:
                break;
        }
    }
}

public enum GameState
{
    PlayerSpawn,
    PlayerSelectDoor,
    PlayerMove,
    PlayerMinigame
}
