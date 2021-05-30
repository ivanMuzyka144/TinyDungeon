using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMoverSetter : MoverSetter
{
    public override void SetMover(Topology topology)
    {
        foreach(DominoHolder answerDomino in topology.GetAllAnswerDominos())
        {
            answerDomino.EnableSelector();
            answerDomino.EnableDragMaker();
        }

        foreach (DominoHolder placeForAnswer in topology.GetSmallPlacesDominos())
        {
            placeForAnswer.EnableSelector();
        }
    }

    public override void DestroyMover(Topology topology)
    {
        foreach (DominoHolder answerDomino in topology.GetAllAnswerDominos())
        {
            answerDomino.DisableSelector();
            answerDomino.DisableDragMaker();
        }

        foreach (DominoHolder placeForAnswer in topology.GetSmallPlacesDominos())
        {
            placeForAnswer.DisableSelector();
        }
    }

    public override void ClearPlacesForDomino(Topology topology)
    {
        foreach (DominoHolder placeForAnswer in topology.GetSmallPlacesDominos())
        {
            placeForAnswer.DisableSelector();
            placeForAnswer.GetComponent<PlaceForDomino>().RemoveDomino();
        }
    }
}
