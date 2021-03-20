using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemHolder : MonoBehaviour
{
    private GameStateManager gameStateManager;
    private UIItemPresenter uiItemPresenter;

    private List<Item> collectedItems = new List<Item>();
    public void Activate()
    {
        gameStateManager = GameStateManager.Instance;
        uiItemPresenter = UIItemPresenter.Instance;
    }

    public void SetStartItems(List<Item> startItems)
    {
        collectedItems.AddRange(startItems);
        uiItemPresenter.UpdatePresenter(collectedItems);
    }

    public void CollectItem(Room room)
    {
        if (room.HasItem())
        {
            Action afterAnimAction = () =>
                                         {
                                             uiItemPresenter.UpdatePresenter(collectedItems);
                                             gameStateManager.ChangeState(GameStateType.PlayerSelectDoor);
                                         };

            Item collectedItem = room.GetItem(afterAnimAction);
            collectedItems.Add(collectedItem);
        }
        else
        {
            gameStateManager.ChangeState(GameStateType.PlayerSelectDoor);
        }
    }

    public bool HasItem(Item item)
    {
        return collectedItems.Contains(item);
    }

    public void RemoveItem(Item item)
    {
        collectedItems.Remove(item);
        uiItemPresenter.UpdatePresenter(collectedItems);
    }
}
