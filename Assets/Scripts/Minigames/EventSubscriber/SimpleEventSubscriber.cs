using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEventSubscriber : EventSubscriber
{
    public override void SubscribeToEvent(Topology topology, MiniGame miniGame)
    {
        foreach (DominoHolder answerDomino in topology.GetAllAnswerDominos())
        {
            answerDomino.OnDominoSet += miniGame.CheckCondition;
        }
    }

    public override void UnsubscribeToEvent(Topology topology, MiniGame miniGame)
    {
        foreach (DominoHolder answerDomino in topology.GetAllAnswerDominos())
        {
            answerDomino.OnDominoSet -= miniGame.CheckCondition;
        }
    }
}
