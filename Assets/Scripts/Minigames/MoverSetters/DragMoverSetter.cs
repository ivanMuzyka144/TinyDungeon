﻿using System.Collections;
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
    }
}