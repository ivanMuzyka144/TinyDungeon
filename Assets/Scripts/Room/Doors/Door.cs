using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Room currentRoom;
    private RoomType doorType;

    private DoorAnimationMaker doorAnimationMaker;

    private void Start()
    {
        doorAnimationMaker = GetComponent<DoorAnimationMaker>();
    }
    
    public void SetDoorInfo(Room room, RoomType type)
    {
        currentRoom = room;
        doorType = type;
    }
    public void ShowDoorUpAnim()
    {
        switch (doorType)
        {
            case RoomType.TopDoor:
                doorAnimationMaker.MakeAnimTopUp();
                break;
            case RoomType.BottomDoor:
                doorAnimationMaker.MakeAnimBottomUp();
                break;
            case RoomType.LeftDoor:
                doorAnimationMaker.MakeAnimLeftUp();
                break;
            case RoomType.RightDoor:
                doorAnimationMaker.MakeAnimRightUp();
                break;
        }
    }
    public void ShowDoorBackAnim()
    {
        switch (doorType)
        {
            case RoomType.TopDoor:
                doorAnimationMaker.MakeAnimTopBack();
                break;
            case RoomType.BottomDoor:
                doorAnimationMaker.MakeAnimBottomBack();
                break;
            case RoomType.LeftDoor:
                doorAnimationMaker.MakeAnimLeftBack();
                break;
            case RoomType.RightDoor:
                doorAnimationMaker.MakeAnimRightBack();
                break;
        }
    }
}
