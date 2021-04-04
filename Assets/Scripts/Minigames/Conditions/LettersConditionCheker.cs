using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LettersConditionCheker : ConditionChecker
{
    List<PlaceForDomino> placeForDominos = new List<PlaceForDomino>();
    public override void Configurate(Topology topology)
    {
        List<DominoHolder> dominoHolders = topology.GetSmallPlacesDominos();

        foreach(DominoHolder dominoHolder in dominoHolders)
        {
            placeForDominos.Add(dominoHolder.GetComponent<PlaceForDomino>());
        }
    }
    public override ConditionResult CheckCondition()
    {
        ConditionResult conditionResult = ConditionResult.NotReady;

        int allSet = 0;
        int howManyCorrect = 0;
        foreach (PlaceForDomino placeForDomino in placeForDominos)
        {
            if (placeForDomino.HasDomino())
            {
                allSet++;
                if (placeForDomino.IsDominoCorrect())
                {
                    howManyCorrect++;
                }
            }
        }

        if(allSet == placeForDominos.Count)
        {
            if(howManyCorrect == placeForDominos.Count)
            {
                conditionResult = ConditionResult.Win;
            }
            else
            {
                conditionResult = ConditionResult.Lose;
            }
        }

        return conditionResult;
    }

}
