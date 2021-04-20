using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventSubscriber : MonoBehaviour
{
    public abstract void SubscribeToEvent(Topology topology, MiniGame miniGame);

    public abstract void UnsubscribeToEvent(Topology topology, MiniGame miniGame);
}
