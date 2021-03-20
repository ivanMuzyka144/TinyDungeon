using System;
using System.Collections.Generic;

public class GameStateNode 
{
    private List<GameStateType> previousStates = new List<GameStateType>();
    private GameStateType thisState;
    private List<GameStateType> nextStates = new List<GameStateType>();

    public EventHandler OnStateStarted;
    public EventHandler OnStateEnded;
    

    public GameStateNode(GameStateType thisState, 
                        GameStateType[] previousStates, 
                        GameStateType[] nextStates)
    {
        this.thisState = thisState;
        this.previousStates.AddRange(previousStates);
        this.nextStates.AddRange(nextStates);
    }


    public GameStateType GetGameStateType()
    {
        return thisState;
    }

    public bool IsPreviousFor(GameStateType gameStateType)
    {
        return nextStates.Contains(gameStateType);
    }
}
