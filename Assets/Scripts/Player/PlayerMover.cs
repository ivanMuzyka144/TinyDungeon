using UnityEngine;
using Lean.Transition;

public class PlayerMover : MonoBehaviour
{
    private Room currentRoom;
    public void SpawnPlayer(Vector3 position) => transform.position = position;

    public void SetCurrentRoom(Room room) => currentRoom = room;

    public Room GetCurrentRoom()
    {
        return currentRoom;
    }

    public void MoveToAnotherRoom(Vector3 nextPosition)
    {
        transform.positionTransition(nextPosition, 1);
    }
    
}
