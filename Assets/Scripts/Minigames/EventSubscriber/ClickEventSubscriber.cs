using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEventSubscriber : EventSubscriber
{
    public override void SubscribeToEvent(Topology topology, MiniGame miniGame)
    {
        foreach (DominoHolder answerDomino in topology.GetAllAnswerDominos())
        {
            answerDomino.OnDominoClicked += miniGame.CheckCondition;
        }
    }

    public override void UnsubscribeToEvent(Topology topology, MiniGame miniGame)
    {
        foreach (DominoHolder answerDomino in topology.GetAllAnswerDominos())
        {
            answerDomino.OnDominoClicked -= miniGame.CheckCondition;
        }
    }
}
