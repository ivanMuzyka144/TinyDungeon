using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPatternHolder : MonoBehaviour
{
    [SerializeField] List<RoomPattern> patternStrings = new List<RoomPattern>();
    
    public RoomPattern GetRandomPatternFor()
    {
        return null;
    }

}

[Serializable]
public class RoomPattern
{
    public bool Top;
    public bool Bottom;
    public bool Left;
    public bool Right;

}
