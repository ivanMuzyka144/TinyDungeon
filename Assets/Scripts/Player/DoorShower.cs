using System.Collections.Generic;
using UnityEngine;

public class DoorShower : MonoBehaviour
{
    public static DoorShower Instance { get; private set; }

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
        List<Door> currentDoors = new List<Door>();
        foreach(Door door in currentDoors)
        {
            door.ShowDoorUpAnim();
        }
    }

    public void ShowDoorsBackAnim()
    {
        currentRoom = player.GetCurrentRoom();
        List<Door> currentDoors = new List<Door>();
        foreach (Door door in currentDoors)
        {
            door.ShowDoorBackAnim();
        }
    }
}
