using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Domino
{
    private DominoValueHolder topValueHolder;
    private DominoValueHolder bottomValueHolder;
    private DominoValueHolder wholeValueHolder;
    public Domino()
    {
        topValueHolder = new DominoValueHolder();
        bottomValueHolder = new DominoValueHolder();
        wholeValueHolder = new DominoValueHolder();
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
        dominoValueHolder.SetDominoValueType(dominoValue.GetDominoType());
    }
    private DominoValueHolder GetValueHolder(DominoPlace dominoValuePlace)
    {
        DominoValueHolder returnHolder = null; //= dominoValuePlace == DominoPlace.Top? topValueHolder : bottomValueHolder;
        switch (dominoValuePlace)
        {
            case DominoPlace.Top:
                returnHolder = topValueHolder;
                break;
            case DominoPlace.Bottom:
                returnHolder = bottomValueHolder;
                break;
            case DominoPlace.Whole:
                returnHolder = wholeValueHolder;
                break;
        }
        return returnHolder;
    }

    public DominoValueType GetDominoValueType(DominoPlace dominoValuePlace)
    {
        DominoValueHolder dominoValueHolder = GetValueHolder(dominoValuePlace);
        DominoValue dominoValue;
        return dominoValueHolder.GetDominoValueType();
    }

    public bool HasValueHolder(DominoPlace dominoPlace)
    {
        DominoValueHolder dominoValueHolder = GetValueHolder(dominoPlace);
        return dominoValueHolder != null;
    }

    public bool EquealToNormalDomino(Domino anotherDomino)
    {
        bool isTopCorrect = false;
        bool isBottomCorrect = false;
        DominoValueType anotherTopType = anotherDomino.GetDominoValueType(DominoPlace.Top);
        DominoValueType anotherBottomType = anotherDomino.GetDominoValueType(DominoPlace.Bottom);
        if (topValueHolder.GetDominoValueType() == anotherTopType
            && bottomValueHolder.GetDominoValueType() == anotherBottomType)
        {
            switch (anotherTopType)
            {
                case DominoValueType.Number:
                    isTopCorrect = topValueHolder.GetNumberValue() == anotherDomino.GetNumberValue(DominoPlace.Top);
                    break;
                case DominoValueType.Letter:
                    isTopCorrect = topValueHolder.GetLetterValue() == anotherDomino.GetLetterValue(DominoPlace.Top);
                    break;
            }
            switch (anotherBottomType)
            {
                case DominoValueType.Number:
                    isBottomCorrect = bottomValueHolder.GetNumberValue() == anotherDomino.GetNumberValue(DominoPlace.Bottom);
                    break;
                case DominoValueType.Letter:
                    isBottomCorrect = bottomValueHolder.GetLetterValue() == anotherDomino.GetLetterValue(DominoPlace.Bottom);
                    break;
            }
        }

        return isTopCorrect && isBottomCorrect;
    }


    public bool EquealToWholeDomino(Domino anotherDomino)
    {
        bool isTopCorrect = false;
        bool isBottomCorrect = false;

        DominoValueType anotherWholeType = anotherDomino.GetDominoValueType(DominoPlace.Whole);

        if (topValueHolder.GetDominoValueType() == anotherWholeType
            || bottomValueHolder.GetDominoValueType() == anotherWholeType)
        {
            switch (anotherWholeType)
            {
                case DominoValueType.Number:
                    isTopCorrect = topValueHolder.GetNumberValue() == anotherDomino.GetNumberValue(DominoPlace.Whole);
                    break;
                case DominoValueType.Letter:
                    isTopCorrect = topValueHolder.GetLetterValue() == anotherDomino.GetLetterValue(DominoPlace.Whole);
                    break;
            }
            switch (anotherWholeType)
            {
                case DominoValueType.Number:
                    isBottomCorrect = bottomValueHolder.GetNumberValue() == anotherDomino.GetNumberValue(DominoPlace.Whole);
                    break;
                case DominoValueType.Letter:
                    isBottomCorrect = bottomValueHolder.GetLetterValue() == anotherDomino.GetLetterValue(DominoPlace.Whole);
                    break;
            }
        }

        return isTopCorrect || isBottomCorrect;
    }

    #endregion
}