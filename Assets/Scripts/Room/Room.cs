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
    [SerializeField] private CategoryCollection categoryCollection;

    private RoomTypesGenerator roomTypesGenerator;
    private RoomWallsMaker roomWallMaker;
    private RoomDoorMaker roomDoorMaker;
    private RoomLocator roomLocator;
    private RoomCategorySetter roomCategorySetter;

    public void Activate()
    {
        roomTypesGenerator = GetComponent<RoomTypesGenerator>();
        roomWallMaker = GetComponent<RoomWallsMaker>();
        roomDoorMaker = GetComponent<RoomDoorMaker>();
        roomLocator = GetComponent<RoomLocator>();
        roomCategorySetter = GetComponent<RoomCategorySetter>();
        roomTypesGenerator.Activate();
        roomWallMaker.Activate();
        roomDoorMaker.Activate(this);
        roomCategorySetter.Activate();
    }

    #region DoorsPlaceholdersGeneration
    public void GenerateDoors()
    {
        List<RoomType> generatedTypes = roomTypesGenerator.GenerateTypesForRoom();
        roomWallMaker.GenerateDoors(generatedTypes);
        roomDoorMaker.GenerateDoors(generatedTypes);
    }

    public List<RoomPlaceHolder> GeneratePlaceholders()
    {
        return roomTypesGenerator.GeneratePlaceHolders(this);
    }
    #endregion

    #region GetSetStartTypes

    public void SetStartAcceptedType(RoomType roomType) =>
                            roomTypesGenerator.AddStartAcceptedType(roomType);
    public void SetStartRefusedType(RoomType roomType) =>
                            roomTypesGenerator.AddStartRefusedType(roomType);

    public bool HasStartType(RoomType roomType)
    {
        return roomTypesGenerator.HasStartType(roomType);
    }

    public bool HasGeneratedType(RoomType roomType)
    {
        return roomTypesGenerator.HasGeneratedType(roomType);
    }

    #endregion

    #region SetRelativeRoom
    public void SetRelativeForNewRoom(Room oldRoom, RoomType roomType)
    {
        if (oldRoom.HasGeneratedType(ReverseType(roomType)))
        {
            SetStartAcceptedType(roomType);
            roomLocator.SetRelatedRoom(oldRoom, roomType);
            roomTypesGenerator.AddConnectedType(roomType);
        }
        else
        {
            SetStartRefusedType(roomType);
        }
    }

    public void SetRelativeForOldRoom(Room newRoom, RoomType roomType)
    {
        if (newRoom.HasStartType(ReverseType(roomType)))
        {
            roomLocator.SetRelatedRoom(newRoom, roomType);
            roomTypesGenerator.AddConnectedType(roomType);
        }
    }

    public Room GetRelativeRoom(RoomType roomType)
    {
        return roomLocator.GetRelativeRoom(roomType);
    }
    #endregion

    #region Categories

    public RoomCategoryType GetCategory()
    {
        return roomCategorySetter.GetRoomCategory();
    }

    public MinigameInfo GetMinigameInfo()
    {
        return roomCategorySetter.GetMinigameInfo();
    }

    public List<MinigameInfo> GetRelativeMinigameInfo()
    {
        return roomLocator.GetRelativeMinigameInfo();
    }

    public void SetStartCategory() => roomCategorySetter.SetStartRoomCategory();

    public void SetFinishDoorCategory() => roomCategorySetter.SetFinishDoorRoomCategory();

    public void SetFinishCategory() => roomCategorySetter.SetFinishRoomCategory();

    public void SetMinigameCategory(MinigameInfo minigameInfo) 
                            => roomCategorySetter.SetMinigameRoomCategory(minigameInfo);

    #endregion

    #region MakingRoomFull
    public void CheckForFullness()
    {
        if (!roomTypesGenerator.isFull())
        {
            RepairRoom();
        }
    }

    private void RepairRoom()
    {
        List<RoomType> roomTypesForRemove = new List<RoomType>();

        foreach (RoomType roomType in roomTypesGenerator.GetDisconnectedRooms())
        {
            roomWallMaker.AddClosedDoor(roomType);
            roomDoorMaker.RemoveDoor(roomType);
            roomTypesForRemove.Add(roomType);
        }
        foreach (RoomType roomTypeForDelete in roomTypesForRemove)
        {
            roomTypesGenerator.RemoveGeneratedType(roomTypeForDelete);
        }
    }
    #endregion

    public List<Door> GetDoors()
    {
        return roomDoorMaker.GetCurrentDoors();
    }

    public Door GetDoor(RoomType roomType)
    {
        return roomDoorMaker.GetDoor(roomType);
    }

    public Transform GetDoorHolder(RoomType roomType)
    {
        return roomDoorMaker.GetDoorHolder(roomType);
    }

    public static RoomType ReverseType(RoomType inputRoomType)
    {
        RoomType outputRoomType = RoomType.TopDoor;

        switch (inputRoomType)
        {
            case RoomType.TopDoor:
                outputRoomType = RoomType.BottomDoor;
                break;
            case RoomType.BottomDoor:
                outputRoomType = RoomType.TopDoor;
                break;
            case RoomType.LeftDoor:
                outputRoomType = RoomType.RightDoor;
                break;
            case RoomType.RightDoor:
                outputRoomType = RoomType.LeftDoor;
                break;
        }

        return outputRoomType;
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