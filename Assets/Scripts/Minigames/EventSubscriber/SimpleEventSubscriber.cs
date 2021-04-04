using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEventSubscriber : EventSubscriber
{
    public override void SubscribeToEvent(Topology topology, TinyGameSimulator tinyGameSimulator)
    {
        foreach (DominoHolder answerDomino in topology.GetAllAnswerDominos())
        {
            answerDomino.OnDominoSet += tinyGameSimulator.CheckCondition;
        }
    }
}
