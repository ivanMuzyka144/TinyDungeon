using System;

public class GameStateNode 
{
    private GameStateType thisState;
    private GameStateType nextState;

    public EventHandler OnStateStarted;
    public EventHandler OnStateEnded;
    

    public GameStateNode(GameStateType thisState, GameStateType nextState)
    {
        this.thisState = thisState;
        this.nextState = nextState;
    }

    public GameStateType GetGameStateType()
    {
        return thisState;
    }

    public GameStateType GetNextStateType()
    {
        return thisState;
    }
}
