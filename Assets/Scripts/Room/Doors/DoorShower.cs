using System;
using System.Collections.Generic;
using UnityEngine;

public class DoorShower : MonoBehaviour
{
    public static DoorShower Instance { get; private set; }

    [SerializeField] private Transform cameraTransform;

    [SerializeField] private GameAudioManager gameAudioManager;


    private Player player;

    private Room currentRoom;

    private void Awake() => Instance = this;

    private void Start()
    {
        player = Player.Instance;
    }

    public void ShowDoorsUpAnim(object sender, EventArgs e)
    {
        currentRoom = player.GetCurrentRoom();
        List<Door> currentDoors = currentRoom.GetDoors();
        gameAudioManager.PlayZoomInSound();
        foreach (Door door in currentDoors)
        {
            door.ShowDoorUpAnim(cameraTransform.localEulerAngles);
        }

    }

    public void ShowDoorsBackAnim(object sender, EventArgs e)
    {
        gameAudioManager.PlayWoodSound();
        currentRoom = player.GetCurrentRoom();
        List<Door> currentDoors = currentRoom.GetDoors();
        gameAudioManager.PlayZoomOutSound();
        foreach (Door door in currentDoors)
        {
            door.ShowDoorBackAnim(cameraTransform.localEulerAngles);
        }
    }

    public void ShowTwoDoorsOpenAnim(RoomType direction, Action afterAnimAction)
    {
        Action emptyAction = () => { };

        Room currentRoom = player.GetCurrentRoom();
        Room wantedRoom = currentRoom.GetRelativeRoom(direction);

        gameAudioManager.PlayDoorOpensSound();

        Door currentDoor = currentRoom.GetDoor(direction);
        Door nextDoor = wantedRoom.GetDoor(Room.ReverseType(direction));

        Transform currentDoorHolder = currentRoom.GetDoorHolder(direction);
        Transform nextDoorHolder = wantedRoom.GetDoorHolder(Room.ReverseType(direction));

        currentDoor.ShowDoorOpenAnim(currentDoorHolder, afterAnimAction);
        nextDoor.ShowDoorOpenAnim(nextDoorHolder, emptyAction);
    }

    public void ShowTwoDoorsCloseAnim(RoomType direction, Action afterAnimAction)
    {
        Action emptyAction = () => 
        {
            player.EnablePlayerPhysics();
        };
        
        Room currentRoom = player.GetCurrentRoom();
        Room wantedRoom = currentRoom.GetRelativeRoom(Room.ReverseType(direction));
        gameAudioManager.PlayDoorCloseSound();
        Door currentDoor = currentRoom.GetDoor(Room.ReverseType(direction));
        Door nextDoor = wantedRoom.GetDoor(direction);


        Transform currentDoorHolder = currentRoom.GetDoorHolder(Room.ReverseType(direction));
        Transform nextDoorHolder = wantedRoom.GetDoorHolder(direction);

        currentDoor.ShowDoorCloseAnim(currentDoorHolder, afterAnimAction);
        nextDoor.ShowDoorCloseAnim(nextDoorHolder, emptyAction);
    }

    public SelectionSet GenerateSelectionSet()
    {
        SingleSelectionSet selectionSet = new SingleSelectionSet();

        currentRoom = player.GetCurrentRoom();
        List<Door> currentDoors = currentRoom.GetDoors();
        foreach (Door door in currentDoors)
        {
            selectionSet.AddWithType(door.GetDoorType(), door.GetSelector());
        }

        return selectionSet;
    }
}
