using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Domino 
{
    private DominoValueHolder topValueHolder;
    private DominoValueHolder bottomValueHolder;

    public Domino()
    {
        topValueHolder = new DominoValueHolder();
        bottomValueHolder = new DominoValueHolder();
    }

    #region GettersSetters
    public void SetDominoValue(int number, DominoPlace dominoValuePlace)
                        => SetDominoHolder(new DominoValue(number), dominoValuePlace);
    public void SetDominoValue(string letter, DominoPlace dominoValuePlace)
                        => SetDominoHolder(new DominoValue(letter), dominoValuePlace);
    public void SetDominoValue(DominoColor dominoColor, DominoPlace dominoValuePlace)
                        => SetDominoHolder(new DominoValue(dominoColor), dominoValuePlace);

    public int GetNumberValue(DominoPlace dominoValuePlace)
    {
        DominoValueHolder dominoValueHolder = GetValueHolder(dominoValuePlace);
        return dominoValueHolder.GetNumberValue();
    }
    public string GetLetterValue(DominoPlace dominoValuePlace)
    {
        DominoValueHolder dominoValueHolder = GetValueHolder(dominoValuePlace);
        return dominoValueHolder.GetLetterValue();
    }

    public DominoColor GetColorValue(DominoPlace dominoValuePlace)
    {
        DominoValueHolder dominoValueHolder = GetValueHolder(dominoValuePlace);
        return dominoValueHolder.GetColorValue();
    }


    private void SetDominoHolder(DominoValue dominoValue, DominoPlace dominoValuePlace)
    {
        DominoValueHolder dominoValueHolder = GetValueHolder(dominoValuePlace);

        dominoValueHolder.SetValue(dominoValue);
    }

    private DominoValueHolder GetValueHolder(DominoPlace dominoValuePlace)
    {
        DominoValueHolder returnHolder = dominoValuePlace == DominoPlace.Top? topValueHolder : bottomValueHolder;
        return returnHolder;
    }

    #endregion
}