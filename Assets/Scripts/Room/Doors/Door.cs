using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject doorLock;

    private Room currentRoom;
    private RoomType doorType;

    private GameStateManager gameStateManager;
    private Player player;

    private DoorShower doorShower;
    private DoorAnimationMaker doorAnimationMaker;
    private DoorSelector doorSelector;

    private bool isLocked;
    
    public void Activate()
    {
        gameStateManager = GameStateManager.Instance;
        doorShower = DoorShower.Instance;
        
        doorAnimationMaker = GetComponent<DoorAnimationMaker>();
        doorSelector = GetComponent<DoorSelector>();
        doorAnimationMaker.Activate();
        doorSelector.Activate();

        player = Player.Instance;
    }
    
    public void LockDoor()
    {
        isLocked = true;
        doorLock.SetActive(true);
    }

    public void UnlockDoor()
    {
        isLocked = false;
        doorLock.SetActive(false);
        player.RemoveKey();
    }

    public bool IsDoorLocked()
    {
        return isLocked;
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
                                         doorSelector.Disable(); 
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

    public void OnDoorSelected()
    {
        if (isLocked)
        {
            if (player.HasKey())
            {
                UnlockDoor();
            }
            else
            {
                Debug.Log("SorryItLocked");
            }
        }
        else
        {
            gameStateManager.SetDoorDirection(doorType);//<----Problem
            gameStateManager.EndCurrentState();
        }
        
    }

    public ISelectable GetSelector()
    {
        return doorSelector;
    }

    public RoomType GetDoorType()
    {
        return doorType;
    }
}
