using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomItemHolder : MonoBehaviour
{
    private RoomItemPresenter roomItemPresenter;
    private bool hasItem;
    private Item item; 
    public void Activate()
    {
        roomItemPresenter = GetComponent<RoomItemPresenter>();
    }

    public void ActivatePresenter()
    {
        roomItemPresenter.MakeActive();
    }

    public void SetItem(Item item)
    {
        this.item = item;
        hasItem = true;
    }

    public bool HasItem()
    {
        return hasItem;
    }

    public Item GetItem(Action afterAnimAction)
    {
        hasItem = false;
        roomItemPresenter.MakeEffectFor(item, afterAnimAction);
        return item;
    }
}
