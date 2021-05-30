using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager Instance { get; private set; }

    [SerializeField] private PlatformType currentPlatform;

    private void Awake() => Instance = this;
    public PlatformType GetCurrentPlatform()
    {
        return currentPlatform;
    }
}

public enum PlatformType
{
    PC = 0,
    Mobile = 1,
    Console = 2,
    VR = 3
}