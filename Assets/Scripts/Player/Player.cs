using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    private PlayerMover playerMover;


    private void Awake()
    {
        Instance = this;
    }

    public void Activate()
    {
        playerMover = GetComponent<PlayerMover>();

        playerMover.Activate();
    }

    public void SpawnPlayer(Vector3 startPosition) => playerMover.SpawnPlayer(startPosition);

    public void SetCurrentRoom(Room currentRoom) => playerMover.SetCurrentRoom(currentRoom);
    public Room GetCurrentRoom()
    {
        return playerMover.GetCurrentRoom();
    }

    public void MoveToAnotherRoom(RoomType directionType)
    {
        Room nextRoom = playerMover.GetCurrentRoom().GetRelativeRoom(directionType);

        playerMover.MoveToAnotherRoom(nextRoom.transform.position);

        playerMover.SetCurrentRoom(nextRoom);
    }
}
