using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomTypesGenerator : MonoBehaviour
{
    private List<RoomType> startAcceptedTypes = new List<RoomType>();
    private List<RoomType> startRefusedTypes = new List<RoomType>();
    private List<RoomType> generatedTypes = new List<RoomType>();
    private List<RoomType> connectedTypes = new List<RoomType>();

    public void AddStartAcceptedType(RoomType startType) => startAcceptedTypes.Add(startType);
    public void AddStartRefusedType(RoomType startType) => startRefusedTypes.Add(startType);
    public void AddConnectedType(RoomType connectedType) => connectedTypes.Add(connectedType);

    private RoomPatternHolder patternHolder;

    public void Activate()
    {
        patternHolder = GetComponent<RoomPatternHolder>();
    }

    public List<RoomType> GenerateTypesForRoom()
    {
        bool shouldAddTopType = startAcceptedTypes.Contains(RoomType.TopDoor);
        bool shouldAddBottomType =  startAcceptedTypes.Contains(RoomType.BottomDoor);
        bool shouldAddLeftType = startAcceptedTypes.Contains(RoomType.LeftDoor);
        bool shouldAddRightType = startAcceptedTypes.Contains(RoomType.RightDoor);

        RoomPattern roomPattern= new RoomPattern(shouldAddTopType, shouldAddBottomType, 
                                        shouldAddLeftType, shouldAddRightType);

        RoomPattern newRoomPattern = patternHolder.GetRandomPatternFor(roomPattern);

        if (newRoomPattern.top)
            generatedTypes.Add(RoomType.TopDoor);
        if (newRoomPattern.bottom)
            generatedTypes.Add(RoomType.BottomDoor);
        if (newRoomPattern.left)
            generatedTypes.Add(RoomType.LeftDoor);
        if (newRoomPattern.right)
            generatedTypes.Add(RoomType.RightDoor);

        return generatedTypes;
    }

    public List<RoomPlaceHolder> GeneratePlaceHolders(Room room)
    {
        List<RoomPlaceHolder> newPlaceHolders = new List<RoomPlaceHolder>();

        foreach (RoomType roomType in generatedTypes)
        {
            RoomPlaceHolder roomPlaceHolder = new RoomPlaceHolder();

            roomPlaceHolder.parentRoom = room;
            roomPlaceHolder.roomType = roomType;

            newPlaceHolders.Add(roomPlaceHolder);
        }

        return newPlaceHolders;
    }

    public bool HasStartType(RoomType roomType)
    {
        return startAcceptedTypes.Contains(roomType);
    }


    public bool HasGeneratedType(RoomType roomType)
    {
        return generatedTypes.Contains(roomType);
    }

    public bool isFull()
    {
        return connectedTypes.Count == generatedTypes.Count;
    }

    public List<RoomType> GetDisconnectedRooms()
    {
        return generatedTypes.Except(connectedTypes).ToList<RoomType>();
    }

    public void RemoveGeneratedType(RoomType roomType) => generatedTypes.Remove(roomType);
}

