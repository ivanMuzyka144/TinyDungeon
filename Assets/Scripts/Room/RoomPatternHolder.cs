using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPatternHolder : MonoBehaviour
{
    [SerializeField] List<RoomPattern> patterns = new List<RoomPattern>();

    public RoomPattern GetRandomPatternFor(RoomPattern currentPattern)
    {
        List<RoomPattern> acceptedPatterns = new List<RoomPattern>();

        foreach(RoomPattern roomPattern in patterns)
        {
            if (roomPattern.IsSimilar(currentPattern))
            {
                acceptedPatterns.Add(roomPattern);
            }
        }

        int randomNumber = UnityEngine.Random.Range(0, acceptedPatterns.Count);
        RoomPattern randomPattern = acceptedPatterns[randomNumber]; 
        

        return randomPattern;
    }

}

[Serializable]
public class RoomPattern
{
    public bool top;
    public bool bottom;
    public bool left;
    public bool right;

    public RoomPattern(bool topValue, bool bottomValue, bool leftValue, bool rightValue)
    {
        top = topValue;
        bottom = bottomValue;
        left = leftValue;
        right = rightValue;
    }

    public bool IsSimilar(RoomPattern pattern)
    {
        bool isTopOkay = pattern.top ? pattern.top && top : true;
        bool isBottomOkay = pattern.bottom ? pattern.bottom && bottom : true;
        bool isLeftOkay = pattern.left ? pattern.left && left : true;
        bool isRightOkay = pattern.right ? pattern.right && right : true;

        bool isSimilar = isTopOkay && isBottomOkay && isLeftOkay && isRightOkay;

        return isSimilar;
    }
}
