using UnityEngine;
using Lean.Transition;

public class PlayerMover : MonoBehaviour
{
    private GameStateManager gameStateManager;

    private Room currentRoom;

    private float playerSpeed = 0.75f;

    public void Activate()
    {
        gameStateManager = GameStateManager.Instance;
    }
    public void SpawnPlayer(Vector3 position) => transform.position = position;

    public void SetCurrentRoom(Room room) => currentRoom = room;

    public Room GetCurrentRoom()
    {
        return currentRoom;
    }

    public void MoveToAnotherRoom(Vector3 nextPosition)
    {
        transform.positionTransition(nextPosition, playerSpeed)
            .EventTransition(() => gameStateManager.SetState(GameStateType.DoorsClose), playerSpeed);
    }
    
}
