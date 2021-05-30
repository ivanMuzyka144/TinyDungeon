using Lean.Transition;
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
    private MinigameManager minigameSimulator;
    private StatisticsManager statisticsManager;

    private void Awake() => Instance = this;

    private void Start()
    {
        Time.timeScale = 1;

        levelGenerator = LevelGenerator.Instance;
        roomCollection = RoomCollection.Instance;
        player = Player.Instance;
        gameStateManager = GameStateManager.Instance;
        minigameSimulator = MinigameManager.Instance;
        statisticsManager = StatisticsManager.Instance;

        List<Room> rooms = levelGenerator.MakeLevel();

        roomCollection.Activate();
        roomCollection.SetRoomCollection(rooms);
        roomCollection.ProcessRooms();
        roomCollection.ColorRooms();
        roomCollection.SpawnItems();
        Vector3 spawnPoisition = roomCollection.GetSpawnPosition();

        player.Activate();
        player.SpawnPlayer(spawnPoisition);
        player.SetCurrentRoom(roomCollection.GetStartRoom());

        gameStateManager.Activate();

        minigameSimulator.Activate();

        statisticsManager.Activate();

        StartCoroutine(StartDoorsAnimation(1));
    }
    IEnumerator StartDoorsAnimation(int sec)
    {
        yield return new WaitForSeconds(sec);
        gameStateManager.SetStartState();
    }
}
