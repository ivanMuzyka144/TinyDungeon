using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCollection : MonoBehaviour
{
    public static RoomCollection Instance { get; private set; }

    private List<Room> rooms = new List<Room>();

    private void Awake() => Instance = this;

    public void SetRoomCollection(List<Room> roomCollection)
    {
        rooms = roomCollection;
    }
}
