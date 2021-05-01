using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorSetter : MoverSetter
{
    public override void SetMover(Topology topology)
    {
        foreach (DominoHolder answerDomino in topology.GetAllAnswerDominos())
        {
            answerDomino.EnableSelector();
            answerDomino.EnableRotator();
        }
    }
    public override void DestroyMover(Topology topology)
    {
        foreach (DominoHolder answerDomino in topology.GetAllAnswerDominos())
        {
            answerDomino.DisableSelector();
            answerDomino.DisableRotator();
        }
    }

}
