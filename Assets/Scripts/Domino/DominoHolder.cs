using System;
using UnityEngine;

public class DominoHolder : MonoBehaviour
{
    [SerializeField] private DominoType dominoType;

    public EventHandler OnDominoSet;

    private Domino domino;
    private DominoPresenter dominoPresenter;
    private DominoSelector dominoSelector;
    private DragMaker dragMaker;


    private void Awake()
    {
        dominoPresenter = GetComponent<DominoPresenter>();
        dominoSelector = GetComponent<DominoSelector>();
        dragMaker = GetComponent<DragMaker>();

        if(dominoType == DominoType.Answer)
        {
            dragMaker.SetDrag(true);
        }
    }

    public void SetDomino(Domino domino)
    {
        this.domino = domino;
        if (dominoType != DominoType.PlaceForDomino)
        {
            dominoPresenter.SetTopValue(domino.GetNumberValue(DominoPlace.Top));
            dominoPresenter.SetBottomValue(domino.GetNumberValue(DominoPlace.Bottom));
        }
        if(dominoType == DominoType.Answer)
        {
            dominoSelector.Enable();
        }
    }

    public void SetPlaceForDominoPosition(Vector3 placeForDominoPosition) 
    {
        dominoSelector.SetPlaceForDominoPosition(placeForDominoPosition);
    }

    public void RemovePlaceForDominoPosition() 
    {
        dominoSelector.RemovePlaceForDominoPosition();
    }

    public void OnDominoHasSet()
    {
        OnDominoSet?.Invoke(this, EventArgs.Empty);
    }

    public Domino GetDomino()
    {
        return domino;
    }
}

public enum DominoType
{
    General,
    Question,
    Answer,
    PlaceForDomino
}
