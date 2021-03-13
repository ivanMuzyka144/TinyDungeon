using System.Collections.Generic;
using UnityEngine;

public class DoorShower : MonoBehaviour
{
    public static DoorShower Instance { get; private set; }

    [SerializeField] private Transform cameraTransform;


    private Player player;

    private Room currentRoom;

    private void Awake() => Instance = this;

    private void Start()
    {
        player = Player.Instance;
    }

    public void ShowDoorsUpAnim()
    {
        currentRoom = player.GetCurrentRoom();
        List<Door> currentDoors = currentRoom.GetDoors();
        foreach(Door door in currentDoors)
        {
            door.ShowDoorUpAnim(cameraTransform.localEulerAngles);
        }
    }

    public void ShowDoorsBackAnim()
    {
        currentRoom = player.GetCurrentRoom();
        List<Door> currentDoors = currentRoom.GetDoors();
        foreach (Door door in currentDoors)
        {
            door.ShowDoorBackAnim(cameraTransform.localEulerAngles);
        }
    }
}
