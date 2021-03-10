﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{   
    public static GameStarter Instance { get; private set; }

    private LevelGenerator levelGenerator;
    private RoomCollection roomCollection;
    private Player player;

    private void Awake() => Instance = this;

    private void Start()
    {
        levelGenerator = LevelGenerator.Instance;
        roomCollection = RoomCollection.Instance;
        player = Player.Instance;
        
        List<Room> rooms = levelGenerator.MakeLevel();

        roomCollection.SetRoomCollection(rooms);
        roomCollection.ProcessRooms();
        roomCollection.ColorRooms();
        Vector3 spawnPoisition = roomCollection.GetSpawnPosition();

        player.Activate();
        player.SpawnPlayer(spawnPoisition);
    }
}
