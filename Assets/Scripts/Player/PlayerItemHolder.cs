using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerItemHolder : MonoBehaviour
{
    [SerializeField] private GameAudioManager gameAudioManager;

    private GameStateManager gameStateManager;
    private UIItemPresenter uiItemPresenter;
    private ItemCollection itemCollection;

    private List<Item> collectedItems = new List<Item>();
    public void Activate()
    {
        gameStateManager = GameStateManager.Instance;
        uiItemPresenter = UIItemPresenter.Instance;
        itemCollection = ItemCollection.Instance;
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
            gameAudioManager.PlayItemSound();
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

    public int GetLifeCount()
    {
        return collectedItems.Where(n => n == itemCollection.GetLifeItem()).ToList().Count;
    }
    public int GetCoinCount()
    {
        return collectedItems.Where(n => n == itemCollection.GetCoinItem()).ToList().Count;
    }
    public int GetMiracleCount()
    {
        return collectedItems.Where(n => n == itemCollection.GetMiracleItem()).ToList().Count;
    }
}
