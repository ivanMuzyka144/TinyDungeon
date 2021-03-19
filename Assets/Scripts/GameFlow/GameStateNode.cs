using System;

public class GameStateNode 
{
    private GameStateType previousState;
    private GameStateType thisState;
    private GameStateType nextState;

    public EventHandler OnStateStarted;
    public EventHandler OnStateEnded;
    

    public GameStateNode(GameStateType thisState, GameStateType previousState, GameStateType nextState)
    {
        this.thisState = thisState;
        this.previousState = previousState;
        this.nextState = nextState;
    }

    public GameStateType GetPreviousState()
    {
        return previousState;
    }

    public GameStateType GetGameStateType()
    {
        return thisState;
    }

    public GameStateType GetNextStateType()
    {
        return nextState;
    }
}
