using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillsEventSubscriber : EventSubscriber
{
    public override void SubscribeToEvent(Topology topology, MiniGame miniGame)
    {
        foreach (Mill mill in topology.GetAllMills())
        {
            mill.OnMillRotated += miniGame.CheckCondition;
        }
    }

    public override void UnsubscribeToEvent(Topology topology, MiniGame miniGame)
    {
        foreach (Mill mill in topology.GetAllMills())
        {
            mill.OnMillRotated -= miniGame.CheckCondition;
        }
    }
}
