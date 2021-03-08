using System.Collections;
using System.Collections.Generic;
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

    public List<RoomType> GenerateTypesForRoom()
    {
        bool shouldAddTopType = (Random.value > 0.5f && !startRefusedTypes.Contains(RoomType.TopDoor))
                                || startAcceptedTypes.Contains(RoomType.TopDoor);
        bool shouldAddBottomType = (Random.value > 0.5f && !startRefusedTypes.Contains(RoomType.BottomDoor))
                                || startAcceptedTypes.Contains(RoomType.BottomDoor);
        bool shouldAddLeftType = (Random.value > 0.5f && !startRefusedTypes.Contains(RoomType.LeftDoor))
                                || startAcceptedTypes.Contains(RoomType.LeftDoor);
        bool shouldAddRightType = (Random.value > 0.5f && !startRefusedTypes.Contains(RoomType.RightDoor))
                                || startAcceptedTypes.Contains(RoomType.RightDoor);

        if (shouldAddTopType)
            generatedTypes.Add(RoomType.TopDoor);
        if (shouldAddBottomType)
            generatedTypes.Add(RoomType.BottomDoor);
        if (shouldAddLeftType)
            generatedTypes.Add(RoomType.LeftDoor);
        if (shouldAddRightType)
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

    //public List<RoomType> GetGeneratedTypes()
    //{
    //    return generatedTypes;
    //}
}
