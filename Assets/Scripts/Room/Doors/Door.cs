using System;
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
        Action afterAnimAction = () => doorSelector.Enable();
        

        switch (doorType)
        {
            case RoomType.TopDoor:
                doorAnimationMaker.MakeAnimTopUp(cameraRotation, afterAnimAction);
                break;
            case RoomType.BottomDoor:
                doorAnimationMaker.MakeAnimBottomUp(cameraRotation, afterAnimAction);
                break;
            case RoomType.LeftDoor:
                doorAnimationMaker.MakeAnimLeftUp(cameraRotation, afterAnimAction);
                break;
            case RoomType.RightDoor:
                doorAnimationMaker.MakeAnimRightUp(cameraRotation, afterAnimAction);
                break;
        }
    }
    public void ShowDoorBackAnim(Vector3 cameraRotation)
    {
        doorSelector.Disable();
        Action afterAnimAction = () => { 
                                         doorSelector.Enable(); 
                                         gameStateManager.ChangeState(GameStateType.PlayerMove);
                                        };

        switch (doorType)
        {
            case RoomType.TopDoor:
                doorAnimationMaker.MakeAnimTopBack(cameraRotation, afterAnimAction);
                break;
            case RoomType.BottomDoor:
                doorAnimationMaker.MakeAnimBottomBack(cameraRotation, afterAnimAction);
                break;
            case RoomType.LeftDoor:
                doorAnimationMaker.MakeAnimLeftBack(cameraRotation, afterAnimAction);
                break;
            case RoomType.RightDoor:
                doorAnimationMaker.MakeAnimRightBack(cameraRotation, afterAnimAction);
                break;
        }
    }

    public void ShowDoorOpenAnim(Transform doorHolder, Action afterAnimAction)
    {
        switch (doorType)
        {
            case RoomType.TopDoor:
                doorAnimationMaker.MakeAnimTopOpen(doorHolder, afterAnimAction);
                break;
            case RoomType.BottomDoor:
                doorAnimationMaker.MakeAnimBottomOpen(doorHolder, afterAnimAction);
                break;
            case RoomType.LeftDoor:
                doorAnimationMaker.MakeAnimLeftOpen(doorHolder, afterAnimAction);
                break;
            case RoomType.RightDoor:
                doorAnimationMaker.MakeAnimRightOpen(doorHolder, afterAnimAction);
                break;
        }
    }

    public void ShowDoorCloseAnim(Transform doorHolder, Action afterAnimAction)
    {
        switch (doorType)
        {
            case RoomType.TopDoor:
                doorAnimationMaker.MakeAnimTopClose(doorHolder, afterAnimAction);
                break;
            case RoomType.BottomDoor:
                doorAnimationMaker.MakeAnimBottomClose(doorHolder, afterAnimAction);
                break;
            case RoomType.LeftDoor:
                doorAnimationMaker.MakeAnimLeftClose(doorHolder, afterAnimAction);
                break;
            case RoomType.RightDoor:
                doorAnimationMaker.MakeAnimRightClose(doorHolder, afterAnimAction);
                break;
        }
    }

    //public void OnUpAnimationEnded() 
    //{
    //    doorSelector.Enable();
    //}

    public void OnDoorSelected()
    {
        gameStateManager.SetDoorDirection(doorType);//<----Problem
        gameStateManager.EndCurrentState();
    }

    //public void OnBackAnimationEnded() 
    //{
    //    doorSelector.Disable();
    //    gameStateManager.ChangeState();//<----Problem
    //}

    //public void OnOpenAnimationEnded()
    //{
    //    gameStateManager.SetState(GameStateType.PlayerMove);
    //}

    //public void OnCloseAnimationEnded()
    //{
    //    gameStateManager.SetState(GameStateType.PlayerMinigame);
    //}
}
