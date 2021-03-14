using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Room currentRoom;
    private RoomType doorType;


    private GameStateManager gameStateManager;

    private DoorShower doorShower;
    private DoorAnimationMaker doorAnimationMaker;
    private DoorSelector doorSelector;
    //mesh renedee add
    public void Activate()
    {
        gameStateManager = GameStateManager.Instance;
        doorShower = DoorShower.Instance;
        
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
    public void ShowDoorBackAnim(Vector3 cameraRotation)
    {
        doorSelector.Disable();

        switch (doorType)
        {
            case RoomType.TopDoor:
                doorAnimationMaker.MakeAnimTopBack(cameraRotation);
                break;
            case RoomType.BottomDoor:
                doorAnimationMaker.MakeAnimBottomBack(cameraRotation);
                break;
            case RoomType.LeftDoor:
                doorAnimationMaker.MakeAnimLeftBack(cameraRotation);
                break;
            case RoomType.RightDoor:
                doorAnimationMaker.MakeAnimRightBack(cameraRotation);
                break;
        }
    }

    public void ShowDoorOpenAnim(Transform doorHolder)
    {
        switch (doorType)
        {
            case RoomType.TopDoor:
                doorAnimationMaker.MakeAnimTopOpen(doorHolder);
                break;
            case RoomType.BottomDoor:
                doorAnimationMaker.MakeAnimBottomOpen(doorHolder);
                break;
            case RoomType.LeftDoor:
                doorAnimationMaker.MakeAnimLeftOpen(doorHolder);
                break;
            case RoomType.RightDoor:
                doorAnimationMaker.MakeAnimRightOpen(doorHolder);
                break;
        }
    }

    public void ShowDoorCloseAnim(Transform doorHolder)
    {
        switch (doorType)
        {
            case RoomType.TopDoor:
                doorAnimationMaker.MakeAnimTopClose(doorHolder);
                break;
            case RoomType.BottomDoor:
                doorAnimationMaker.MakeAnimBottomClose(doorHolder);
                break;
            case RoomType.LeftDoor:
                doorAnimationMaker.MakeAnimLeftClose(doorHolder);
                break;
            case RoomType.RightDoor:
                doorAnimationMaker.MakeAnimRightClose(doorHolder);
                break;
        }
    }

    public void OnUpAnimationEnded() 
    {
        doorSelector.Enable();
    }

    public void OnDoorSelected()
    {
        gameStateManager.SetDoorDirection(doorType);
        doorShower.ShowDoorsBackAnim();
    }

    public void OnBackAnimationEnded() 
    {
        doorSelector.Disable();
        gameStateManager.SetState(GameState.DoorsOpen);
    }

    public void OnOpenAnimationEnded()
    {
        gameStateManager.SetState(GameState.PlayerMove);
    }

    public void OnCloseAnimationEnded()
    {
        gameStateManager.SetState(GameState.PlayerMinigame);
    }
}
