using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkerSetter : MoverSetter
{
    public override void SetMover(Topology topology)
    {
        foreach (DominoHolder answerDomino in topology.GetAllAnswerDominos())
        {
            answerDomino.EnableSelector();
            answerDomino.EnableBlinker();
        }
    }

    public override void DestroyMover(Topology topology)
    {
        foreach (DominoHolder answerDomino in topology.GetAllAnswerDominos())
        {
            answerDomino.DisableSelector();
            answerDomino.DisableBlinker();
        }
        foreach (DominoHolder placeForDomino in topology.GetSmallPlacesDominos())
        {
            placeForDomino.DisableSelector();
        }
    }

    public override void ClearPlacesForDomino(Topology topology)
    {
    }
}
