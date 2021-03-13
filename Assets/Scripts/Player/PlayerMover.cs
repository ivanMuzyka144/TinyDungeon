using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private Room currentRoom;
    public void SpawnPlayer(Vector3 position) => transform.position = position;

    public void SetCurrentRoom(Room room) => currentRoom = room;

    public Room GetCurrentRoom()
    {
        return currentRoom;
    }
    
}
