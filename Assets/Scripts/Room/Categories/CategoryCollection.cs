using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoryCollection : MonoBehaviour
{
    public static CategoryCollection Instance { get; private set; }

    [SerializeField] List<RoomCategory> roomCategories = new List<RoomCategory>();

    private RoomCategory startRoom;
    private RoomCategory finishRoom;
    private RoomCategory finishDoorRoom;

    private List<RoomCategory> minigameRooms = new List<RoomCategory>();
    private List<RoomCategory> bonusRooms = new List<RoomCategory>();

    private Dictionary<MinigameInfo, RoomCategory> minigameRoomDictionary = new Dictionary<MinigameInfo, RoomCategory>();
    private void Awake() => Instance = this;
    public void Activate()
    {
        foreach(RoomCategory roomCategory in roomCategories)
        {
            switch (roomCategory.roomCategoryType)
            {
                case RoomCategoryType.StartRoom:
                    startRoom = roomCategory;
                    break;
                case RoomCategoryType.FinishDoorRoom:
                    finishDoorRoom = roomCategory;
                    break;
                case RoomCategoryType.FinishRoom:
                    finishRoom = roomCategory;
                    break;
                case RoomCategoryType.MinigameRoom:
                    minigameRooms.Add(roomCategory);
                    break;
                case RoomCategoryType.BonusRoom:
                    bonusRooms.Add(roomCategory);
                    break;
            }
        }

        foreach(RoomCategory minigamesCategory in minigameRooms)
        {
            minigameRoomDictionary.Add(minigamesCategory.GetMinigameInfo(), minigamesCategory);
        }
    }
    
    public RoomCategory GetStartRoomCategory()
    {
        return startRoom;
    }

    public RoomCategory GetFinishDoorRoomCategory()
    {
        return finishDoorRoom;
    }

    public RoomCategory GetFinishRoomCategory()
    {
        return finishRoom;
    }

    public RoomCategory GetMinigameRoomCategory(MinigameInfo minigameInfo)
    {
        return minigameRoomDictionary[minigameInfo];
    }
}
