using Lean.Transition;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoAnimator : MonoBehaviour
{
    [SerializeField] private float selectionHeight;
    [SerializeField] private float selectionHeightTime;
    [SerializeField] private float backTime;

    private Vector3 startPosition;
    private Vector3 currentBackPosition;
    private Vector3 finishPosition;

    private DominoSelector dominoSelector;

    public void Activate()
    {
        dominoSelector = GetComponent<DominoSelector>();

        startPosition = transform.position;
        currentBackPosition = startPosition;
        finishPosition = transform.position + new Vector3(0, 0, -selectionHeight);
    }
    public void MakeTowardAnim()
    {
        transform.positionTransition(finishPosition, selectionHeightTime);
    }
    public void MakeBackAnim()
    {
        Action afterAnimAction = () =>
        {
            dominoSelector.Unblock();
        };

        transform.positionTransition(startPosition, backTime)//;
                 .EventTransition(afterAnimAction, backTime);
    }
}
