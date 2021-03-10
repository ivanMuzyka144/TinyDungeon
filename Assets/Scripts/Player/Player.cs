using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    private PlayerMover playerMover;

    private void Awake()
    {
        Instance = this;
    }

    public void Activate()
    {
        playerMover = GetComponent<PlayerMover>();
        Debug.Log(playerMover);
    }

    public void SpawnPlayer(Vector3 startPosition) => playerMover.SpawnPlayer(startPosition);
}
