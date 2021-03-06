using System.Collections;
using System.Collections.Generic;
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
    private Dictionary<Vector3,Room> roomsPositionDictionary = new Dictionary<Vector3, Room>();
    
    private Queue<RoomPlaceHolder> acceptedPlaceholdersQueue = new Queue<RoomPlaceHolder>();

    private float height = 10;
    private float width = 10;

    private void Awake() => Instance = this;
    
    public void MakeLevel()
    {
        SetFirstRoom();
        GenerateLevel();
    }

    public void SetFirstRoom()
    {
        Room room = CreateRoomAtPosition(startPoint.position);
        
        room.SetStartDoor(RoomType.TopDoor);
        room.SetStartDoor(RoomType.BottomDoor);
        room.SetStartDoor(RoomType.LeftDoor);
        room.SetStartDoor(RoomType.RightDoor);

        List<RoomPlaceHolder> roomPlaceHolders = room.GenerateDoors();

        foreach (RoomPlaceHolder roomPlaceHolder in roomPlaceHolders)
        {
            AcceptPlaceholder(roomPlaceHolder);
        }

        roomsPositionDictionary.Add(startPoint.position, room);
    }

    private void GenerateLevel()
    {
        if (acceptedPlaceholdersQueue.Count > 0 && roomsPositionDictionary.Count < maxRooms)
        {
            RoomPlaceHolder roomPlaceHolder = acceptedPlaceholdersQueue.Dequeue();

            Room room = CreateRoomAtPosition(roomPlaceHolder.position);

            room.SetStartDoor(ReverseType(roomPlaceHolder.roomType));
            roomsPositionDictionary.Add(room.transform.position, room);
            List<RoomPlaceHolder> roomPlaceHolders = room.GenerateDoors();
            SetRelativeRoomsFor(room);

            foreach (RoomPlaceHolder placeHolder in roomPlaceHolders)
            {
                AcceptPlaceholder(placeHolder);
            }

            GenerateLevel();
        }
        else
        {
            foreach(Room room in roomsPositionDictionary.Values)
            {
                room.CheckForFullness();
            }
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
            room.SetRelativeRoom(topRelativeRoom, RoomType.TopDoor);
            topRelativeRoom.SetRelativeRoom(room, RoomType.BottomDoor);
        }
        if (roomsPositionDictionary.ContainsKey(bottomRelativeRoomPos))
        {
            Room bottomRelativeRoom = roomsPositionDictionary[bottomRelativeRoomPos];
            room.SetRelativeRoom(bottomRelativeRoom, RoomType.BottomDoor);
            bottomRelativeRoom.SetRelativeRoom(room, RoomType.TopDoor);
        }
        if (roomsPositionDictionary.ContainsKey(leftRelativeRoomPos))
        {
            Room leftRelativeRoom = roomsPositionDictionary[leftRelativeRoomPos];
            room.SetRelativeRoom(leftRelativeRoom, RoomType.LeftDoor);
            leftRelativeRoom.SetRelativeRoom(room, RoomType.RightDoor);
        }
        if (roomsPositionDictionary.ContainsKey(rightRelativeRoomPos))
        {
            Room rightRelativeRoom = roomsPositionDictionary[rightRelativeRoomPos];
            room.SetRelativeRoom(rightRelativeRoom, RoomType.RightDoor);
            rightRelativeRoom.SetRelativeRoom(room, RoomType.LeftDoor);
        }

        //if (roomsPositionDictionary[bottomRelativeRoom])
        //    room.SetRelativeRoom(roomsPositionDictionary[bottomRelativeRoom], RoomType.BottomDoor);
        //if (roomsPositionDictionary[leftRelativeRoom])
        //    room.SetRelativeRoom(roomsPositionDictionary[leftRelativeRoom], RoomType.LeftDoor);
        //if (roomsPositionDictionary[rightRelativeRoom])
        //    room.SetRelativeRoom(roomsPositionDictionary[rightRelativeRoom], RoomType.RightDoor);
    }


    private RoomType ReverseType(RoomType inputRoomType)
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

    private Room CreateRoomAtPosition(Vector3 position)
    {
        Room room = Instantiate(room_PB);
        room.transform.position = position;
        room.Activate();
        return room;
    }
}
