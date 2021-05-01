using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PairsConditionChecker : ConditionChecker
{
    [SerializeField] private PairsManager pairsManager;

    private int howManyPairs;

    private List<DominoHolder> answerDominos;
    public override void Configurate(Topology topology)
    {
        howManyPairs = topology.GetAllAnswerDominos().Count / 2;
        answerDominos = topology.GetAllAnswerDominos();
    }
    public override ConditionResult CheckCondition()
    {
        bool isMinigameSolved = pairsManager.GetEqualPartsCount() == howManyPairs;

        ConditionResult returnResult = ConditionResult.NotReady;

        if (isMinigameSolved)
        {
            returnResult = ConditionResult.Win;
            pairsManager.Clear();

            foreach (DominoHolder dominoHolder in answerDominos)
            {
                dominoHolder.MakeBackRotation();
            }
        }

        return returnResult;
    }

    
}
