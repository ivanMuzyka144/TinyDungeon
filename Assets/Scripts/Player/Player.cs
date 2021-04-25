using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    private bool isAlive;

    private PlayerMover playerMover;
    private PlayerItemHolder playerItemHolder;
    private ItemCollection itemCollection;
    private GameStateManager gameStateManager;

    private void Awake()
    {
        Instance = this;
    }

    public void Activate()
    {
        isAlive = true;

        itemCollection = ItemCollection.Instance;
        gameStateManager = GameStateManager.Instance;

        playerMover = GetComponent<PlayerMover>();
        playerItemHolder = GetComponent<PlayerItemHolder>();

        playerMover.Activate();
        playerItemHolder.Activate();

        SetStartItems();
    }

    public void SpawnPlayer(Vector3 startPosition) => playerMover.SpawnPlayer(startPosition);

    public void SetCurrentRoom(Room currentRoom) => playerMover.SetCurrentRoom(currentRoom);
    public Room GetCurrentRoom()
    {
        return playerMover.GetCurrentRoom();
    }

    public void MoveToAnotherRoom(RoomType directionType, Action afterAnimAction)
    {
        Room nextRoom = playerMover.GetCurrentRoom().GetRelativeRoom(directionType);

        Debug.Log(nextRoom);

        playerMover.MoveToAnotherRoom(nextRoom.transform.position, afterAnimAction);

        playerMover.SetCurrentRoom(nextRoom);
    }

    public void CollectItem(object sender, EventArgs e)
    {
        GSEventArgs gsEventArgs = e as GSEventArgs;
        MiniGameResultType miniGameResultType = gsEventArgs.lastMinigameResult;
        if (miniGameResultType == MiniGameResultType.Win || 
            miniGameResultType == MiniGameResultType.UseMiracle)
        {
            Room currentRoom = GetCurrentRoom();
            playerItemHolder.CollectItem(currentRoom);
        }
        else
        {
            gameStateManager.ChangeState(GameStateType.PlayerSelectDoor);
        }
    }

    public bool HasMiracle()
    {
        return playerItemHolder.HasItem(itemCollection.GetMiracleItem());
    }

    private void SetStartItems()
    {
        List<Item> startItems = new List<Item>();
        startItems.Add(itemCollection.GetLifeItem());
        startItems.Add(itemCollection.GetLifeItem());
        startItems.Add(itemCollection.GetLifeItem());
        startItems.Add(itemCollection.GetMiracleItem());
        startItems.Add(itemCollection.GetMiracleItem());
        playerItemHolder.SetStartItems(startItems);
    }


    public void RemoveLife()
    {
        if (playerItemHolder.HasItem(itemCollection.GetLifeItem()))
        {
            playerItemHolder.RemoveItem(itemCollection.GetLifeItem());
        }
        else
        {
            isAlive = false;
            gameStateManager.ChangeState(GameStateType.GameOver);
        }
    }

    public bool IsAlive()
    {
        return isAlive;
    }

    public void RemoveMiracle()
    {
        playerItemHolder.RemoveItem(itemCollection.GetMiracleItem());
    }
}
