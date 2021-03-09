using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoryCollection : MonoBehaviour
{
    [SerializeField] List<RoomCategory> roomCategories = new List<RoomCategory>();

    private RoomCategory startRoom;
    private RoomCategory finishRoom;
    private RoomCategory finishDoorRoom;

    private List<RoomCategory> minigameRooms = new List<RoomCategory>();
    private List<RoomCategory> bonusRooms = new List<RoomCategory>();

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

}
