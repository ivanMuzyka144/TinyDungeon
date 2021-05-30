using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoverSetter : MonoBehaviour
{
    public abstract void SetMover(Topology topology);
    public abstract void DestroyMover(Topology topology);
    public abstract void ClearPlacesForDomino(Topology topology);
}
