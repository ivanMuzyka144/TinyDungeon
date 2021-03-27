using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoHolder : MonoBehaviour
{
    [SerializeField] private bool isPlaceForDomino;

    private Domino domino;
    private DominoPresenter dominoPresenter;

    private void Awake()
    {
        dominoPresenter = GetComponent<DominoPresenter>();
    }

    public void SetDomino(Domino domino)
    {
        this.domino = domino;
        dominoPresenter.SetTopValue(domino.GetNumberValue(DominoPlace.Top));
        dominoPresenter.SetBottomValue(domino.GetNumberValue(DominoPlace.Bottom));
    }
}
