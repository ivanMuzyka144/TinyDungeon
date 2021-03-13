using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Room currentRoom;
    private RoomType doorType;

    private DoorAnimationMaker doorAnimationMaker;
    private DoorSelector doorSelector;
    //mesh renedee add
    public void Activate()
    {
        doorAnimationMaker = GetComponent<DoorAnimationMaker>();
        doorSelector = GetComponent<DoorSelector>();
        doorAnimationMaker.Activate();
    }
    
    public void SetDoorInfo(Room room, RoomType type)
    {
        currentRoom = room;
        doorType = type;
    }
    public void ShowDoorUpAnim(Vector3 cameraRotation)
    {
        switch (doorType)
        {
            case RoomType.TopDoor:
                doorAnimationMaker.MakeAnimTopUp(cameraRotation);
                break;
            case RoomType.BottomDoor:
                doorAnimationMaker.MakeAnimBottomUp(cameraRotation);
                break;
            case RoomType.LeftDoor:
                doorAnimationMaker.MakeAnimLeftUp(cameraRotation);
                break;
            case RoomType.RightDoor:
                doorAnimationMaker.MakeAnimRightUp(cameraRotation);
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

    public void OnUpAnimationEnded() 
    {
        doorSelector.Enable();
    }

    public void OnBackAnimationEnded() 
    {
        doorSelector.Disable();
    }
}
