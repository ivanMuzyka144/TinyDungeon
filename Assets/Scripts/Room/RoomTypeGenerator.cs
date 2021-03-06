using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTypeGenerator : MonoBehaviour
{
    [SerializeField] private Transform topSpawner;
    [SerializeField] private Transform bottomSpawner;
    [SerializeField] private Transform leftSpawner;
    [SerializeField] private Transform rightSpawner;
    [Space(10)]
    [SerializeField] private GameObject topWallOpen;
    [SerializeField] private GameObject topWallClosed;
    [SerializeField] private GameObject bottomWallOpen;
    [SerializeField] private GameObject bottomWallClosed;
    [SerializeField] private GameObject leftWallOpen;
    [SerializeField] private GameObject leftWallClosed;
    [SerializeField] private GameObject rightWallOpen;
    [SerializeField] private GameObject rightWallClosed;

    private Dictionary<RoomType, GameObject> openWallsDictionary = new Dictionary<RoomType, GameObject>();
    private Dictionary<RoomType, GameObject> closedWallsDictionary = new Dictionary<RoomType, GameObject>();

    private List<RoomType> newTypes = new List<RoomType>();

    public void Activate()
    {
        openWallsDictionary.Add(RoomType.TopDoor, topWallOpen);
        openWallsDictionary.Add(RoomType.BottomDoor, bottomWallOpen);
        openWallsDictionary.Add(RoomType.LeftDoor, leftWallOpen);
        openWallsDictionary.Add(RoomType.RightDoor, rightWallOpen);

        closedWallsDictionary.Add(RoomType.TopDoor, topWallClosed);
        closedWallsDictionary.Add(RoomType.BottomDoor, bottomWallClosed);
        closedWallsDictionary.Add(RoomType.LeftDoor, leftWallClosed);
        closedWallsDictionary.Add(RoomType.RightDoor, rightWallClosed);

    }

    public List<RoomType> GenerateDoors(List<RoomType> selectedTypes)
    {
        GenerateDoorForType(RoomType.TopDoor, selectedTypes.Contains(RoomType.TopDoor));
        GenerateDoorForType(RoomType.BottomDoor, selectedTypes.Contains(RoomType.BottomDoor));
        GenerateDoorForType(RoomType.LeftDoor, selectedTypes.Contains(RoomType.LeftDoor));
        GenerateDoorForType(RoomType.RightDoor, selectedTypes.Contains(RoomType.RightDoor));

        return newTypes;
    }

    public void DestroyDoor(Room room, RoomType roomType)
    {
        switch (roomType)
        {
            case RoomType.TopDoor:
                topWallOpen.SetActive(false);
                topWallClosed.SetActive(true);
                break;
            case RoomType.BottomDoor:
                bottomWallOpen.SetActive(false);
                bottomWallClosed.SetActive(true);
                break;
            case RoomType.LeftDoor:
                leftWallOpen.SetActive(false);
                leftWallClosed.SetActive(true);
                break;
            case RoomType.RightDoor:
                rightWallOpen.SetActive(false);
                rightWallClosed.SetActive(true);
                break;
        }
    }

    public List<RoomPlaceHolder> GetRoomPlaceHolders(Room room)
    {
        List<RoomPlaceHolder> newPlaceHolders = new List<RoomPlaceHolder>();

        foreach(RoomType roomType in newTypes)
        {
            RoomPlaceHolder roomPlaceHolder = new RoomPlaceHolder();

            roomPlaceHolder.parentRoom = room;
            roomPlaceHolder.roomType = roomType;

            newPlaceHolders.Add(roomPlaceHolder);
        }

        return newPlaceHolders;
    }

    private void GenerateDoorForType(RoomType roomType, bool isSelected)
    {
        if (isSelected)
        {
            openWallsDictionary[roomType].SetActive(true);
            newTypes.Add(roomType);
        }
        else
        {
            bool shouldBeAdded = Random.value > 0.5f;

            if (shouldBeAdded)
            {
                openWallsDictionary[roomType].SetActive(true);
                newTypes.Add(roomType);
            }
            else
            {
                closedWallsDictionary[roomType].SetActive(true);
            }
        }
    }
}
