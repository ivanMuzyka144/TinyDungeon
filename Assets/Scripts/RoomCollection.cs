using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCollection : MonoBehaviour
{
    [SerializeField] private CategoryPalette categoryPalette;
    public static RoomCollection Instance { get; private set; }

    private List<Room> rooms = new List<Room>();

    private Room startRoom;
    private Room finishDoorRoom;
    private Room finishRoom;
    private List<Room> minigameRooms = new List<Room>();

    private void Awake() => Instance = this;

    public void SetRoomCollection(List<Room> roomCollection)
    {
        rooms = roomCollection;
    }

    public void ProcessRooms()
    {
        foreach(Room room in rooms)
        {
            switch (room.GetCategory())
            {
                case RoomCategoryType.StartRoom:
                    startRoom = room;
                    break;
                case RoomCategoryType.FinishDoorRoom:
                    finishDoorRoom = room;
                    break;
                case RoomCategoryType.FinishRoom:
                    finishRoom = room;
                    break;
                default:
                    minigameRooms.Add(room);
                    break;
            }
        }
    }

    public void ColorRooms()
    {
        foreach (Room room in minigameRooms)
        {
            List<MinigameInfo> minigameInfoList = room.GetRelativeMinigameInfo();
            MinigameInfo correctColor = categoryPalette.GenerateColorFor(minigameInfoList);
            room.SetMinigameCategory(correctColor);
        }
    }
}
