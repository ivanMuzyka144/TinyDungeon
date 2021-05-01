using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;

public class PlaceForDomino : MonoBehaviour
{
    [SerializeField] private DominoHolder myHolder;
    [SerializeField] private DominoPresenter dominoPresenter;

    private DominoHolder dominoInZone;
    private Vector3 startDominoRotation;

    public bool HasDomino()
    {
        return dominoInZone != null;
    }

    public bool IsDominoCorrect()
    {
        Domino myDomino = myHolder.GetDomino();
        bool returnValue = false;
        if(dominoInZone != null)
        {
            Domino inZoneDomino = dominoInZone.GetDomino();
            if (myHolder.HasWholeValue())
            {
                returnValue = inZoneDomino.EquealToWholeDomino(myDomino);
            }
            else
            {
                returnValue = inZoneDomino.EquealToNormalDomino(myDomino);
            }
        }
        return returnValue;
    }

    public void HideText()
    {
        dominoPresenter.HideText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<DominoHolder>() != null)
        {

            if(dominoInZone == null) 
            {
                dominoInZone = other.GetComponent<DominoHolder>();

                dominoInZone.SetPlaceForDomino(this);

                dominoInZone.transform.rotationTransition(transform.rotation, 0.25f);
                dominoInZone.GetComponent<DominoAnimator>().MakeRotation(transform.eulerAngles);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<DominoHolder>() != null
            && other.GetComponent<DominoHolder>() == dominoInZone
            && other.transform.rotation != transform.rotation)
        {
            //dominoInZone.GetComponent<DominoAnimator>().Mw
            //    transform.rotationTransition(transform.rotation, 0.25f);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<DominoHolder>() != null 
            && other.GetComponent<DominoHolder>() == dominoInZone)
        {
            dominoInZone.RemovePlaceForDominoPosition(this);
            dominoInZone.GetComponent<DominoAnimator>().MakeNormalRotation();
            dominoInZone = null;

        }
    }
}
