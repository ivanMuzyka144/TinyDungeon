using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public static GameStarter Instance { get; private set; }

    private LevelGenerator levelGenerator;

    private void Awake() => Instance = this;

    private void Start()
    {
        levelGenerator = LevelGenerator.Instance;

        levelGenerator.MakeLevel();
    }
}
