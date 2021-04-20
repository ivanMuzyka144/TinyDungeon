using Lean.Transition;
using System;
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
    private SimpleDominoSelector dominoSelector;

    public void Activate()
    {
        dominoHolder = GetComponent<DominoHolder>();
        dominoSelector = GetComponent<SimpleDominoSelector>();

        startPosition = transform.position;
        currentBackPosition = startPosition;
        finishPosition = transform.position + new Vector3(0, selectionHeight, 0);
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

    public void MakeStepBack()
    {
        transform.position = transform.position - new Vector3(0, selectionHeight, 0);
    }

        public void SetPlaceForDominoPosition(Vector3 placeForDominoPosition)
    {
        currentBackPosition = placeForDominoPosition;
        finishPosition = placeForDominoPosition + new Vector3(0, selectionHeight, 0);
    }

    public void SetStartPosition()
    {
        transform.position = new Vector3(startPosition.x, transform.position.y, startPosition.z);
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
    }

    public void RemovePlaceForDominoPosition()
    {
        currentBackPosition = startPosition;
        finishPosition = startPosition + new Vector3(0, selectionHeight, 0);
    }
}
