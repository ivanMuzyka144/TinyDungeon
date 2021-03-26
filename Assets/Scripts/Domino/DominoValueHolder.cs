using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoValueHolder 
{
    private DominoValue dominoValue;

    public DominoValueHolder() { }

    public void SetValue(DominoValue dominoValue) => this.dominoValue = dominoValue;

    public int GetNumberValue()
    {
        return dominoValue.GetNumberValue();
    }
    public string GetLetterValue()
    {
        return dominoValue.GetLetterValue();
    }
    public DominoColor GetColorValue()
    {
        return dominoValue.GetColorValue();
    }

    public static DominoPlace ReversePlaceValue(DominoPlace dominoValuePlace)
    {
        DominoPlace returnValue = dominoValuePlace == DominoPlace.Top ?
                                                           DominoPlace.Bottom :
                                                           DominoPlace.Top;
        return returnValue;
    }

}

public class DominoValue
{
    private DominoValueType dominoValueType;

    private int numberValue;
    private string letterValue;
    private DominoColor colorValue;

    public DominoValue(int number)
    {
        dominoValueType = DominoValueType.Number;
        numberValue = number;
    }

    public DominoValue(string letter)
    {
        dominoValueType = DominoValueType.Letter;
        letterValue = letter;
    }

    public DominoValue(DominoColor color)
    {
        dominoValueType = DominoValueType.Number;
        colorValue = color;
    }

    public DominoValueType GetDominoType()
    {
        return dominoValueType;
    }

    public int GetNumberValue()
    {
        return numberValue;
    }

    public string GetLetterValue()
    {
        return letterValue;
    }
    public DominoColor GetColorValue()
    {
        return colorValue;
    }

}
public enum DominoValueType
{
    Number,
    Letter,
    Color
}

public enum DominoColor
{
    Red,
    Yellow,
    Green,
    Blue
}

public enum DominoPlace
{
    Top,
    Bottom
}


