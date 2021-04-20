using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceRecorder : MonoBehaviour
{
    public static SequenceRecorder Instance { get; private set; }

    private List<Blinker> questionBlinkers;
    private List<Blinker> answerContainer = new List<Blinker>();

    private int howManyRounds;
    private int currentRound;

    private bool blinkingIsShowing;

    private ConditionResult currResult;

    private void Awake() => Instance = this;

    public void Configurate(List<Blinker> questionBlinkers)
    {
        this.questionBlinkers = questionBlinkers;
        howManyRounds = questionBlinkers.Count;
        currentRound = 1;
        currResult = ConditionResult.NotReady;
        ShowSequence();
    }
    public void ShowSequence()
    {
        List<Blinker> sequenceForShowing = new List<Blinker>();

        for(int i=0; i< currentRound; i++)
        {
            sequenceForShowing.Add(questionBlinkers[i]);
        }
        blinkingIsShowing = true;
        BlinkNext(0, sequenceForShowing);
    }

    public void BlinkNext(int currIndex, List<Blinker> randomQuestionSequence)
    {
        if (currIndex + 1 < randomQuestionSequence.Count)
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
            randomQuestionSequence[currIndex].MakeLastBlink();
        }

    }  

    public bool IsBlinkingShowing()
    {
        return blinkingIsShowing;
    }

    public void StartShowingStatus() => blinkingIsShowing = true;
    public void EndShowingStatus() => blinkingIsShowing = false;

    public void Record(Blinker blinker)
    {
        answerContainer.Add(blinker);
        bool isCorrect = true;
        for(int i = 0; i < answerContainer.Count; i++)
        {
            Domino questionDomino = questionBlinkers[i].GetComponent<DominoHolder>().GetDomino();
            Domino answerDomino = answerContainer[i].GetComponent<DominoHolder>().GetDomino();

            isCorrect = isCorrect && answerDomino.EquealToNormalDomino(questionDomino);
        }

        if (isCorrect)
        {
            if (answerContainer.Count == currentRound)
            {
                if (currentRound == howManyRounds)
                {
                    answerContainer.Clear();
                    currResult = ConditionResult.Win;
                }
                else
                {
                    currentRound++;
                    answerContainer.Clear();
                    ShowSequence();
                }
            }
        }
        else
        {
            answerContainer.Clear();
            currResult = ConditionResult.Lose;
        }
    }

    public ConditionResult GetResult()
    {
        return currResult;
    }
}
