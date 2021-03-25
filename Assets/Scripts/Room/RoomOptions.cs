using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomOptions : MonoBehaviour
{
    public static RoomOptions Instance { get; private set; }

    [SerializeField] private float roomHeight;
    [SerializeField] private float roomWidth;

    private void Awake() => Instance = this;

    public float GetHeight()
    {
        return roomHeight;
    }

    public float GetWidth()
    {
        return roomWidth;
    }
}
