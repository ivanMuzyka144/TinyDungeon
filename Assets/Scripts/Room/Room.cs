using System.Collections.Generic;
using UnityEngine;

public enum RoomType
{
    TopDoor,
    BottomDoor,
    LeftDoor,
    RightDoor
}
public class Room : MonoBehaviour
{
    private List<RoomType> roomTypes = new List<RoomType>();
    private List<RoomType> connectedTypes = new List<RoomType>();

    private RoomTypeGenerator roomTypeGenerator;
    private RoomLocator roomLocator;

    public void Activate()
    {
        roomTypeGenerator = GetComponent<RoomTypeGenerator>();
        roomLocator = GetComponent<RoomLocator>();
        roomTypeGenerator.Activate();
    }

    public void SetStartDoor(RoomType roomType)=> roomTypes.Add(roomType);
    

    public List<RoomPlaceHolder> GenerateDoors()
    {
        roomTypes = roomTypeGenerator.GenerateDoors(roomTypes);

        List<RoomPlaceHolder> roomPlaceHolders = roomTypeGenerator.GetRoomPlaceHolders(this);
        
        return roomPlaceHolders;
    }

    public void SetRelativeRoom(Room room, RoomType roomType)
    {
        if (roomTypes.Contains(roomType))
        {
            roomLocator.SetRelatedRoom(room, roomType);
            connectedTypes.Add(roomType);
        }
    }

    public void CheckForFullness()
    {
        bool isFull = roomTypes.Count == connectedTypes.Count;
        if (!isFull)
        {
            RepairRoom();
        }
    }

    private void RepairRoom()
    {
        List<RoomType> roomTypesForRemove = new List<RoomType>();
        foreach(RoomType roomType in roomTypes)
        {
            if (!connectedTypes.Contains(roomType))
            {
                roomTypeGenerator.DestroyDoor(this, roomType);
                roomTypesForRemove.Add(roomType);
            }
        }
        foreach(RoomType roomTypeForDelete in roomTypesForRemove)
        {
            roomTypes.Remove(roomTypeForDelete);
        }
    }

}

public class RoomPlaceHolder
{
    public Room parentRoom;
    public RoomType roomType;
    public Vector3 position => GetPosition();

    private float height = 10;
    private float width = 10;

    private Vector3 GetPosition()
    {
        Vector3 returnPosition = parentRoom.transform.position;

        switch (roomType)
        {
            case RoomType.TopDoor:
                returnPosition += new Vector3(height,0,0);
                break;
            case RoomType.BottomDoor:
                returnPosition += new Vector3(-height, 0, 0);
                break;
            case RoomType.LeftDoor:
                returnPosition += new Vector3(0, 0, width);
                break;
            case RoomType.RightDoor:
                returnPosition += new Vector3(0, 0, -width);
                break;
        }
        return returnPosition;
    }
}