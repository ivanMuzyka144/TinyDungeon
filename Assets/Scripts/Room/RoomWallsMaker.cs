using System.Collections.Generic;
using UnityEngine;

public class RoomWallsMaker : MonoBehaviour
{
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

    public void GenerateDoors(List<RoomType> roomTypes)
    {
        RoomType[] allTypes = { RoomType.TopDoor, RoomType.BottomDoor, 
                                RoomType.LeftDoor, RoomType.RightDoor};

        foreach(RoomType roomType in allTypes)
        {
            if (roomTypes.Contains(roomType))
            {
                AddOpenDoor(roomType);
            }
            else
            {
                AddClosedDoor(roomType);
            }
        }
    }

    private void AddOpenDoor(RoomType roomType)
    {
        switch (roomType)
        {
            case RoomType.TopDoor:
                topWallOpen.SetActive(true);
                topWallClosed.SetActive(false);
                break;
            case RoomType.BottomDoor:
                bottomWallOpen.SetActive(true);
                bottomWallClosed.SetActive(false);
                break;
            case RoomType.LeftDoor:
                leftWallOpen.SetActive(true);
                leftWallClosed.SetActive(false);
                break;
            case RoomType.RightDoor:
                rightWallOpen.SetActive(true);
                rightWallClosed.SetActive(false);
                break;
        }
    }

    public void AddClosedDoor(RoomType roomType)
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

    
}
