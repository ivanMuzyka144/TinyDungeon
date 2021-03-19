using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomItemPresenter : MonoBehaviour
{
    [SerializeField] private Box box;

    public void MakeActive()
    {
        box.Activate();
    }
    public void MakeEffectFor(Item item , Action afterAnimAction)
    {
        box.MakeEffectForItem(item, afterAnimAction);
    }
}
