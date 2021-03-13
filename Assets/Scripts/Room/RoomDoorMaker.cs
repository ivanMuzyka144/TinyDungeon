using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomDoorMaker : MonoBehaviour
{
    [SerializeField] private Door topDoor;
    [SerializeField] private Door bottomDoor;
    [SerializeField] private Door leftDoor;
    [SerializeField] private Door rightDoor;

    private Dictionary<RoomType, Door> allDoorsDictionary = new Dictionary<RoomType, Door>();
    private Dictionary<RoomType, Door> currentDoorsDictionary = new Dictionary<RoomType, Door>();
    public void Activate(Room currentRoom)
    {
        topDoor.SetDoorInfo(currentRoom, RoomType.TopDoor);
        bottomDoor.SetDoorInfo(currentRoom, RoomType.BottomDoor);
        leftDoor.SetDoorInfo(currentRoom, RoomType.LeftDoor);
        rightDoor.SetDoorInfo(currentRoom, RoomType.RightDoor);

        allDoorsDictionary.Add(RoomType.TopDoor, topDoor);
        allDoorsDictionary.Add(RoomType.BottomDoor, bottomDoor);
        allDoorsDictionary.Add(RoomType.LeftDoor, leftDoor);
        allDoorsDictionary.Add(RoomType.RightDoor, rightDoor);
    }

    public void GenerateDoors(List<RoomType> roomTypes)
    {
        foreach(RoomType roomType in roomTypes)
        {
            allDoorsDictionary[roomType].gameObject.SetActive(true);
            currentDoorsDictionary.Add(roomType, allDoorsDictionary[roomType]);
        }
    }

    public void RemoveDoor(RoomType roomType)
    {
        currentDoorsDictionary[roomType].gameObject.SetActive(false);
        currentDoorsDictionary.Remove(roomType);
    }

    public List<Door> GetCurrentDoors()
    {
        return currentDoorsDictionary.Values.ToList();
    }
}