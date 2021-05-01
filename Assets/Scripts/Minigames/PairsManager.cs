using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PairsManager : MonoBehaviour
{
    private bool isRecording;
    private DominoHolder firstDominoHolder;
    private DominoHolder secondDominoHolder;

    private int howManyPairsAreEquel;

    public void StartRecording()
    {
        isRecording = true;
    }

    public void StopRecording()
    {
        isRecording = false;
    }

    public bool IsRecording()
    {
        return isRecording;
    }

    public int GetEqualPartsCount()
    {
        return howManyPairsAreEquel;
    }

    public void AddDominoHolder(DominoHolder dominoHolder)
    {
        if (firstDominoHolder != null)
        {
            secondDominoHolder = dominoHolder;
        }
        else
        {
            firstDominoHolder = dominoHolder;
        }
    }

    public void CheckCondition()
    {
        if (firstDominoHolder != null && secondDominoHolder != null)
        {
            Domino lastOpenedDomino = firstDominoHolder.GetDomino();
            Domino currentDomino = secondDominoHolder.GetDomino();

            if (lastOpenedDomino.EquealToNormalDomino(currentDomino))
            {
                howManyPairsAreEquel++;

                firstDominoHolder = null;
                secondDominoHolder = null;
            }
            else
            {
                firstDominoHolder.MakeBackRotation();// nie tut proveriat
                secondDominoHolder.MakeBackRotation();
                firstDominoHolder = null;
                secondDominoHolder = null;
            }
        }
    }

    public void Clear()
    {
        howManyPairsAreEquel = 0;
        firstDominoHolder = null;
        secondDominoHolder = null;
    }

}
