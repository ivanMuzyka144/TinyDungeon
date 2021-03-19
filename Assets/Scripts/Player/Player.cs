using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    private PlayerMover playerMover;
    private PlayerItemHolder playerItemHolder;


    private void Awake()
    {
        Instance = this;
    }

    public void Activate()
    {
        playerMover = GetComponent<PlayerMover>();
        playerItemHolder = GetComponent<PlayerItemHolder>();

        playerMover.Activate();
        playerItemHolder.Activate();
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

        playerMover.MoveToAnotherRoom(nextRoom.transform.position, afterAnimAction);

        playerMover.SetCurrentRoom(nextRoom);
    }

    public void CollectItem(object sender, EventArgs e)
    {
        Room currentRoom = GetCurrentRoom();
        playerItemHolder.CollectItem(currentRoom);
    }
}
