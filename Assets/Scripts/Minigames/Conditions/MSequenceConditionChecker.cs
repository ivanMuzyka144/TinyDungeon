using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;
using System;

public class MSequenceConditionChecker : ConditionChecker
{
    private List<Blinker> questionsBlinkers = new List<Blinker>();
    public override void Configurate(Topology topology)
    {
        foreach(DominoHolder dominoHolder in topology.GetAllQuestionDominos())
        {
            questionsBlinkers.Add(dominoHolder.GetComponent<Blinker>());
        }

        List<Blinker> randomQuestionSequence = new List<Blinker>();

        for(int i = 0; i< 3; i++)
        {
            randomQuestionSequence.Add(questionsBlinkers[UnityEngine.Random.Range(0, questionsBlinkers.Count)]);
        }

        StartBlinking(randomQuestionSequence);
    }
    public override ConditionResult CheckCondition()
    {
        return ConditionResult.NotReady;
    }

    public void StartBlinking(List<Blinker> randomQuestionSequence)
    {
        BlinkNext(0, randomQuestionSequence);
    }

    public void BlinkNext(int currIndex, List<Blinker> randomQuestionSequence)
    {
        Debug.Log(currIndex);
        if(currIndex+1 < randomQuestionSequence.Count)
        {
            Action afterAnimAction = () =>
            {
                randomQuestionSequence[currIndex].MakeNomalMaterial();
                BlinkNext(currIndex + 1, randomQuestionSequence);
            };
            randomQuestionSequence[currIndex].MakeBlink(afterAnimAction);
        }
        else
        {
            randomQuestionSequence[currIndex].MakeBlink();
        }
        
    }
}
