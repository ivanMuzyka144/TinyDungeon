using System;
using UnityEngine;

public class DominoHolder : MonoBehaviour
{
    [SerializeField] private DominoType dominoType;
    [SerializeField] private bool hasWholeValue;

    public EventHandler OnDominoSet;

    private Domino domino;
    private DominoPresenter dominoPresenter;
    private DominoSelector dominoSelector;
    private DominoAnimator dominoAnimator;
    private DragMaker dragMaker;


    private void Awake()
    {
        dominoPresenter = GetComponent<DominoPresenter>();
        dominoSelector = GetComponent<DominoSelector>();
        dominoAnimator = GetComponent<DominoAnimator>();
        dragMaker = GetComponent<DragMaker>();
    }

    public void SetDomino(Domino domino)
    {
        this.domino = domino;
        if (dominoType != DominoType.PlaceForDomino)
        {
            switch (domino.GetDominoValueType(DominoPlace.Top))
            {
                case DominoValueType.Number:
                    dominoPresenter.SetTopValue(domino.GetNumberValue(DominoPlace.Top));
                    break;
                case DominoValueType.Letter:
                    dominoPresenter.SetTopValue(domino.GetLetterValue(DominoPlace.Top));
                    break;
            }

            switch (domino.GetDominoValueType(DominoPlace.Bottom))
            {
                case DominoValueType.Number:
                    dominoPresenter.SetBottomValue(domino.GetNumberValue(DominoPlace.Bottom));
                    break;
                case DominoValueType.Letter:
                    dominoPresenter.SetBottomValue(domino.GetLetterValue(DominoPlace.Bottom));
                    break;
            }
        }
        else if( dominoType == DominoType.PlaceForDomino)
        {
            if (hasWholeValue)
            {
                switch (domino.GetDominoValueType(DominoPlace.Whole))
                {
                    case DominoValueType.Number:
                        dominoPresenter.SetWholeValue(domino.GetNumberValue(DominoPlace.Whole));
                        break;
                    case DominoValueType.Letter:
                        dominoPresenter.SetWholeValue(domino.GetLetterValue(DominoPlace.Whole));
                        break;
                }
            }
        }
    }

    public void SetPlaceForDominoPosition(Vector3 placeForDominoPosition) 
    {
        dominoAnimator.SetPlaceForDominoPosition(placeForDominoPosition);
    }

    public void SetStartPosition()
    {
        dominoAnimator.SetStartPosition();
    }
    public void HideAllValueModels()
    {
        dominoPresenter.HideAllValueModels();
    }

    public void RemovePlaceForDominoPosition() 
    {
        dominoAnimator.RemovePlaceForDominoPosition();
    }

    public void OnDominoHasSet()
    {
        OnDominoSet?.Invoke(this, EventArgs.Empty);
    }

    public Domino GetDomino()
    {
        return domino;
    }
    public void EnableSelector() => dominoSelector.Enable();

    public void EnableDragMaker() => dragMaker.Enable();

    public void DisableSelector() => dominoSelector.Disable();

    public void DisableDragMaker() => dragMaker.Disable();

    public bool HasWholeValue()
    {
        return hasWholeValue;
    }
}

public enum DominoType
{
    General,
    Question,
    Answer,
    PlaceForDomino
}
