using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private FirstPersonMovement firstPersonMovement;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private Collider collider;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform animationModel;
    [Space(10)]
    [SerializeField] private GameAudioManager gameAudioManager;

    private bool isAlive;

    private PlayerMover playerMover;
    private PlayerItemHolder playerItemHolder;
    private ItemCollection itemCollection;
    private GameStateManager gameStateManager;
    private PlatformManager platformManager;
    private PlatformType currentPlatform;

    private void Awake()
    {
        Instance = this;
    }

    public void Activate()
    {
        isAlive = true;

        itemCollection = ItemCollection.Instance;
        gameStateManager = GameStateManager.Instance;
        platformManager = PlatformManager.Instance;

        playerMover = GetComponent<PlayerMover>();
        playerItemHolder = GetComponent<PlayerItemHolder>();

        currentPlatform = platformManager.GetCurrentPlatform();
        gameAudioManager = GameAudioManager.Instance;
        playerMover.Activate();
        playerItemHolder.Activate();
    }

    public void DisablePlayerPhysics()
    {
        if(currentPlatform == PlatformType.VR)
        {
            firstPersonMovement.enabled = false;
            collider.enabled = false;
            rigidbody.isKinematic = true;
        }
    }

    public void EnablePlayerPhysics()
    {
        if (currentPlatform == PlatformType.VR)
        {
            firstPersonMovement.enabled = true;
            collider.enabled = true;
            rigidbody.isKinematic = false;
        }
    }

    public void SpawnPlayer(Vector3 startPosition) => playerMover.SpawnPlayer(startPosition);

    public void SetCurrentRoom(Room currentRoom) => playerMover.SetCurrentRoom(currentRoom);
    public Room GetCurrentRoom()
    {
        return playerMover.GetCurrentRoom();
    }

    public void MoveToAnotherRoom(RoomType directionType, Action afterAnimAction)
    {
        DisablePlayerPhysics();

        Room nextRoom = playerMover.GetCurrentRoom().GetRelativeRoom(directionType);

        Vector3 offset = Vector3.zero;

        if(currentPlatform == PlatformType.VR)
        {
            switch (directionType)
            {
                case RoomType.TopDoor:
                    offset = new Vector3(-3,0,0);
                    break;
                case RoomType.BottomDoor:
                    offset = new Vector3(3, 0, 0);
                    break;
                case RoomType.RightDoor:
                    offset = new Vector3(0, 0, 5);
                    break;
                case RoomType.LeftDoor:
                    offset = new Vector3(0, 0, -5);
                    break;
            }
        }

        Vector3 nextPosition = nextRoom.transform.position + offset;
        nextPosition.y = transform.position.y;

        Debug.Log("wqwq"+ playerMover);
        playerMover.MoveToAnotherRoom(nextPosition, afterAnimAction);
        
        gameAudioManager.PlayRunningSound();
        playerMover.SetCurrentRoom(nextRoom);
    }

    public void SetIdleAnimation()
    {
        //animationModel.localEulerAngles = new Vector3(0, 270, 0);
        if(currentPlatform != PlatformType.VR)
        animator.SetBool("isRunning", false);
    }

    public void SetMoveAnimation( RoomType direction)
    {
        if (currentPlatform != PlatformType.VR)
        {
            switch (direction)
            {
                case RoomType.TopDoor:
                    animationModel.localEulerAngles = new Vector3(0, 90, 0);
                    break;
                case RoomType.RightDoor:
                    animationModel.localEulerAngles = new Vector3(0, 180, 0);
                    break;
                case RoomType.BottomDoor:
                    animationModel.localEulerAngles = new Vector3(0, 270, 0);
                    break;
                case RoomType.LeftDoor:
                    animationModel.localEulerAngles = new Vector3(0, 0, 0);
                    break;
            }
            if (currentPlatform != PlatformType.VR)
                animator.SetBool("isRunning", true);
        }
    }

    public void SetVictoryAnimation()
    {
        //animationModel.localEulerAngles = new Vector3(0, 270, 0);
        if (currentPlatform != PlatformType.VR)
            animator.SetTrigger("Victory");
    }

    public void SetLoseAnimation()
    {
        //animationModel.localEulerAngles = new Vector3(0, 270, 0);
        if (currentPlatform != PlatformType.VR)
            animator.SetTrigger("Defeat");
    }

    public void CollectItem(object sender, EventArgs e)
    {
        GSEventArgs gsEventArgs = e as GSEventArgs;
        MiniGameResultType miniGameResultType = gsEventArgs.lastMinigameResult;

        if (miniGameResultType == MiniGameResultType.Win || 
            miniGameResultType == MiniGameResultType.UseMiracle)
        {
            Room currentRoom = GetCurrentRoom();
            playerItemHolder.CollectItem(currentRoom);
        }
        else
        {
            //gameStateManager.EndCurrentState();
            gameStateManager.ChangeState(GameStateType.PlayerSelectDoor);
        }
    }

    public bool HasMiracle()
    {
        return playerItemHolder.HasItem(itemCollection.GetMiracleItem());
    }

    public void SetStartItems(int lifeCount, int coinsCount, int miraclesCount)
    {
        List<Item> startItems = new List<Item>();

        for (int i = 0; i < lifeCount; i++)
        {
            startItems.Add(itemCollection.GetLifeItem());
        }
        for (int i = 0; i < coinsCount; i++)
        {
            startItems.Add(itemCollection.GetCoinItem());
        }
        for (int i = 0; i < miraclesCount; i++)
        {
            startItems.Add(itemCollection.GetMiracleItem());
        }

        startItems.Add(itemCollection.GetKeyItem());//<---------------------

        playerItemHolder.SetStartItems(startItems);
    }


    public void RemoveLife()
    {
        if (playerItemHolder.HasItem(itemCollection.GetLifeItem()))
        {
            playerItemHolder.RemoveItem(itemCollection.GetLifeItem());
        }
        else
        {
            isAlive = false;
            gameAudioManager.PlayGameOverSound();
            gameStateManager.ChangeState(GameStateType.GameOver);
        }
    }

    public bool IsAlive()
    {
        return isAlive;
    }

    public void RemoveMiracle()
    {
        playerItemHolder.RemoveItem(itemCollection.GetMiracleItem());
    }

    public bool HasKey()
    {
        return playerItemHolder.HasItem(itemCollection.GetKeyItem());
    }

    public void RemoveKey()
    {
        playerItemHolder.RemoveItem(itemCollection.GetKeyItem());
    }

    public int GetLifeCount()
    {
        return playerItemHolder.GetLifeCount();
    }
    public int GetCoinCount()
    {
        return playerItemHolder.GetCoinCount();
    }
    public int GetMiracleCount()
    {
        return playerItemHolder.GetMiracleCount();
    }

}
