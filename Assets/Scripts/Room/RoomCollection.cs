using System.Collections.Generic;
using System.Linq;
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

    private ItemsGenerator itemsGenerator;

    private void Awake() => Instance = this;

    public void Activate()
    {
        itemsGenerator = GetComponent<ItemsGenerator>();
    }

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

    public void SpawnItems()
    {
        List<Item> generatedItems = itemsGenerator.GenerateItems();
        System.Random rnd = new System.Random();
        List<Room> roomsForItems = rooms.OrderBy(i => rnd.Next())
                                        .Take(generatedItems.Count)
                                        .ToList();
        for(int i = 0; i< roomsForItems.Count; i++)
        {
            roomsForItems[i].SetItem(generatedItems[i]);
        }
    }

    public Vector3 GetSpawnPosition()
    {
        return startRoom.transform.position;
    }

    public Room GetStartRoom()
    {
        return startRoom;
    }
}
