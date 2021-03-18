using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomItemHolder : MonoBehaviour
{
    [SerializeField] private RoomItemPresenter roomItemPresenter;
    private bool hasItem;
    private Item item; 
    public void Activate()
    {
        roomItemPresenter = GetComponent<RoomItemPresenter>();
    }

    public void ActivatePresenter()
    {

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

    public Item GetItem()
    {
        hasItem = false;
        roomItemPresenter.MakeEffectFor(item);
        return item;
    }
}
