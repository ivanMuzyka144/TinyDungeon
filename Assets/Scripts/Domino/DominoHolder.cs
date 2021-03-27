using UnityEngine;

public class DominoHolder : MonoBehaviour
{
    [SerializeField] private DominoType dominoType;

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
}

public enum DominoType
{
    General,
    Question,
    Answer,
    PlaceForDomino
}