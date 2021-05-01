using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator Instance { get; private set; }

    [SerializeField] private float maxRooms;
    [Space(10)]
    [SerializeField] private Transform startPoint;
    [Space(10)]
    [SerializeField] private Room room_PB;

    private Dictionary<Vector3, RoomPlaceHolder> placeHolderPositionDictionary = new Dictionary<Vector3, RoomPlaceHolder>();
    private Dictionary<Vector3, Room> roomsPositionDictionary = new Dictionary<Vector3, Room>();

    private Queue<RoomPlaceHolder> acceptedPlaceholdersQueue = new Queue<RoomPlaceHolder>();

    private float height;
    private float width;

    private void Awake() => Instance = this;

    public List<Room> MakeLevel()
    {
        height = RoomOptions.Instance.GetHeight();
        width = RoomOptions.Instance.GetWidth();

        SetFirstRoom();
        GenerateLevel();

        List<Room> rooms = roomsPositionDictionary.Values.ToList();
        return rooms;
    }

    public void SetFirstRoom()
    {
        Room room = Instantiate(room_PB);
        room.transform.position = startPoint.position;
        room.Activate();

        room.SetStartAcceptedType(RoomType.TopDoor);
        room.SetStartAcceptedType(RoomType.BottomDoor);
        room.SetStartAcceptedType(RoomType.LeftDoor);
        room.SetStartAcceptedType(RoomType.RightDoor);

        room.GenerateDoors();
        room.SetStartCategory();

        roomsPositionDictionary.Add(startPoint.position, room);

        AcceptPlaceholders(room.GeneratePlaceholders());
    }

    private void GenerateLevel()
    {
        if (acceptedPlaceholdersQueue.Count > 0 && roomsPositionDictionary.Count != maxRooms)
        {
            RoomPlaceHolder roomPlaceHolder = acceptedPlaceholdersQueue.Dequeue();
            Room room = CreateRoom(roomPlaceHolder.position);
            AcceptPlaceholders(room.GeneratePlaceholders());

            GenerateLevel();
        }
        else
        {
            if(roomsPositionDictionary.Count != maxRooms)
            {
                List<Room> acceptedRooms = new List<Room>();

                foreach (Room room in roomsPositionDictionary.Values)
                {
                    Vector3 topRoomPosition = room.transform.position + new Vector3(height, 0, 0);
                    if (!roomsPositionDictionary.ContainsKey(topRoomPosition))
                    {
                        acceptedRooms.Add(room);
                    }
                }
                Room roomForChanging = acceptedRooms[Random.Range(0, acceptedRooms.Count)];

                roomForChanging.SetStartAcceptedType(RoomType.TopDoor);
                roomForChanging.GenerateDoors();
                AcceptPlaceholders(roomForChanging.GeneratePlaceholders());
                GenerateLevel();
            }
            else
            {
                GenerateFinishRooms();

                CheckFullness();
            }
        }
    }

    private void GenerateFinishRooms()
    {
        List<Room> acceptedRooms = new List<Room>();

        foreach(Room room in roomsPositionDictionary.Values)
        {
            Vector3 topRoomPosition = room.transform.position + new Vector3(height, 0, 0);
            if(!roomsPositionDictionary.ContainsKey(topRoomPosition))
            {
                acceptedRooms.Add(room);
            }
        }
        Room roomWithFinishDoor = acceptedRooms[Random.Range(0, acceptedRooms.Count)];

        //Room finishRoom = CreateRoom(roomWithFinishDoor.transform.position + new Vector3(height, 0, 0));


        Room finishRoom = Instantiate(room_PB);
        finishRoom.transform.position = roomWithFinishDoor.transform.position + new Vector3(height, 0, 0);
        finishRoom.Activate();
        roomsPositionDictionary.Add(finishRoom.transform.position, finishRoom);

        //SetRelativeRoomsFor(finishRoom);
        finishRoom.SetRelativeForFinish(roomWithFinishDoor, RoomType.BottomDoor);
        roomWithFinishDoor.SetRelativeForFinish(finishRoom, RoomType.TopDoor);


        roomWithFinishDoor.GenerateDoors();
        roomWithFinishDoor.LockTopDoor();
        finishRoom.GenerateDoors();



        //roomWithFinishDoor.SetRelativeForNewRoom(finishRoom, RoomType.BottomDoor);
        //finishRoom.SetRelativeForOldRoom(roomWithFinishDoor, RoomType.TopDoor);

        roomWithFinishDoor.SetFinishDoorCategory();
        finishRoom.SetFinishCategory();
    }

    public void CheckFullness()
    {
        foreach (Room room in roomsPositionDictionary.Values)
        {
            room.CheckForFullness();
        }
    }

    private Room CreateRoom(Vector3 position)
    {
        Room room = Instantiate(room_PB);
        room.transform.position = position;
        room.Activate();

        SetRelativeRoomsFor(room);

        room.GenerateDoors();
        roomsPositionDictionary.Add(position, room);
        return room;
    }

    private void AcceptPlaceholders(List<RoomPlaceHolder> roomPlaceHolders)
    {
        foreach (RoomPlaceHolder placeHolder in roomPlaceHolders)
        {
            AcceptPlaceholder(placeHolder);
        }
    }

    private void AcceptPlaceholder(RoomPlaceHolder roomPlaceHolder)
    {
        if (!roomsPositionDictionary.ContainsKey(roomPlaceHolder.position)
            && !placeHolderPositionDictionary.ContainsKey(roomPlaceHolder.position))
        {
            acceptedPlaceholdersQueue.Enqueue(roomPlaceHolder);
            placeHolderPositionDictionary.Add(roomPlaceHolder.position, roomPlaceHolder);
        }
    }


    private void SetRelativeRoomsFor(Room room)
    {
        Vector3 topRelativeRoomPos = room.transform.position + new Vector3(height, 0, 0);
        Vector3 bottomRelativeRoomPos = room.transform.position + new Vector3(-height, 0, 0);
        Vector3 leftRelativeRoomPos = room.transform.position + new Vector3(0, 0, width);
        Vector3 rightRelativeRoomPos = room.transform.position + new Vector3(0, 0, -width);

        if (roomsPositionDictionary.ContainsKey(topRelativeRoomPos))
        {
            Room topRelativeRoom = roomsPositionDictionary[topRelativeRoomPos];

            room.SetRelativeForNewRoom(topRelativeRoom, RoomType.TopDoor);
            topRelativeRoom.SetRelativeForOldRoom(room, RoomType.BottomDoor);
        }
        if (roomsPositionDictionary.ContainsKey(bottomRelativeRoomPos))
        {
            Room bottomRelativeRoom = roomsPositionDictionary[bottomRelativeRoomPos];

            room.SetRelativeForNewRoom(bottomRelativeRoom, RoomType.BottomDoor);
            bottomRelativeRoom.SetRelativeForOldRoom(room, RoomType.TopDoor);
        }
        if (roomsPositionDictionary.ContainsKey(leftRelativeRoomPos))
        {
            Room leftRelativeRoom = roomsPositionDictionary[leftRelativeRoomPos];

            room.SetRelativeForNewRoom(leftRelativeRoom, RoomType.LeftDoor);
            leftRelativeRoom.SetRelativeForOldRoom(room, RoomType.RightDoor);
        }
        if (roomsPositionDictionary.ContainsKey(rightRelativeRoomPos))
        {
            Room rightRelativeRoom = roomsPositionDictionary[rightRelativeRoomPos];

            room.SetRelativeForNewRoom(rightRelativeRoom, RoomType.RightDoor);
            rightRelativeRoom.SetRelativeForOldRoom(room, RoomType.LeftDoor);
        }
    }
}
