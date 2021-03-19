using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemHolder : MonoBehaviour
{
    private GameStateManager gameStateManager;

    public void Activate()
    {
        gameStateManager = GameStateManager.Instance;
    }
    public void CollectItem(Room room)
    {
        if (room.HasItem())
        {
            room.GetItem();
        }
        gameStateManager.ChangeState(GameStateType.PlayerSelectDoor);
    }
}
