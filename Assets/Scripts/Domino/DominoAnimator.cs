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

    private DominoHolder dominoHolder;
    private DominoSelector dominoSelector;

    public void Activate()
    {
        dominoHolder = GetComponent<DominoHolder>();
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
            dominoHolder.OnDominoHasSet();
            dominoSelector.Unblock();
        };

        transform.positionTransition(currentBackPosition, backTime)
                 .EventTransition(afterAnimAction, backTime);
    }

    public void SetPlaceForDominoPosition(Vector3 placeForDominoPosition)
    {
        currentBackPosition = placeForDominoPosition;
        finishPosition = placeForDominoPosition + new Vector3(0, 0, -selectionHeight);
    }

    public void RemovePlaceForDominoPosition()
    {
        currentBackPosition = startPosition;
        finishPosition = startPosition + new Vector3(0, 0, -selectionHeight);
    }
}
