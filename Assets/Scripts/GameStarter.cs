using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public static GameStarter Instance { get; private set; }

    private LevelGenerator levelGenerator;
    private RoomCollection roomCollection;
    private Player player;
    private GameStateManager gameStateManager;

    private void Awake() => Instance = this;

    private void Start()
    {
        levelGenerator = LevelGenerator.Instance;
        roomCollection = RoomCollection.Instance;
        player = Player.Instance;
        gameStateManager = GameStateManager.Instance;


        List<Room> rooms = levelGenerator.MakeLevel();

        roomCollection.SetRoomCollection(rooms);
        roomCollection.ProcessRooms();
        roomCollection.ColorRooms();
        Vector3 spawnPoisition = roomCollection.GetSpawnPosition();

        player.Activate();
        player.SpawnPlayer(spawnPoisition);
        player.SetCurrentRoom(roomCollection.GetStartRoom());

        gameStateManager.Activate();
        StartCoroutine(StartDoorsAnimation(2));
    }
    IEnumerator StartDoorsAnimation(int sec)
    {
        yield return new WaitForSeconds(sec);
        gameStateManager.SetState(GameState.PlayerSelectDoor);
    }
}
