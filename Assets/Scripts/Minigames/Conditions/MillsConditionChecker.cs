using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillsConditionChecker : ConditionChecker
{
    private List<Mill> mills;
    public override void Configurate(Topology topology)
    {
        mills = topology.GetAllMills();
    }

    public override ConditionResult CheckCondition()
    {
        ConditionResult returnResult = ConditionResult.NotReady;

        Domino leftDomino = mills[0].GetDominoHolder(1).GetDomino();
        Domino centerLeftDomino = mills[1].GetDominoHolder(3).GetDomino();
        Domino centerRightDomino = mills[1].GetDominoHolder(1).GetDomino();
        Domino rightDomino = mills[2].GetDominoHolder(3).GetDomino();

        int leftValue = leftDomino.GetNumberValue(DominoPlace.Top);
        int centerLeftValue = centerLeftDomino.GetNumberValue(DominoPlace.Top);
        int centerRightValue = centerRightDomino.GetNumberValue(DominoPlace.Top);
        int rightValue = rightDomino.GetNumberValue(DominoPlace.Top);

        if((leftValue == centerLeftValue) && (centerRightValue == rightValue))
        {
            returnResult = ConditionResult.Win;
        }
        

        return returnResult;
    }
}
