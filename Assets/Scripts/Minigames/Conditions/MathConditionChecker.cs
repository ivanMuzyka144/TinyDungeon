using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathConditionChecker : ConditionChecker
{
    private PlaceForDomino placeForDominoValue;
    public override void Configurate(Topology topology)
    {
        placeForDominoValue = topology.GetSmallPlacesDominos()[0].GetComponent<PlaceForDomino>();
    }

    public override ConditionResult CheckCondition()
    {
        ConditionResult conditionResult = ConditionResult.NotReady;

        if (placeForDominoValue.HasDomino())
        {
            conditionResult = placeForDominoValue.IsDominoCorrect() ? ConditionResult.Win : ConditionResult.Lose;
        }

        return conditionResult;
    }
}
