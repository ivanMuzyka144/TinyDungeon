using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillsRotatorSetter : MoverSetter
{
    public override void SetMover(Topology topology)
    {
        foreach (Mill mill in topology.GetAllMills())
        {
            mill.EnableSelector();
            mill.EnableRotator();
        }
    }


    public override void DestroyMover(Topology topology)
    {
        foreach (Mill mill in topology.GetAllMills())
        {
            mill.DisableSelector();
            mill.DisableRotator();
        }
    }

    public override void ClearPlacesForDomino(Topology topology)
    {

    }
}
