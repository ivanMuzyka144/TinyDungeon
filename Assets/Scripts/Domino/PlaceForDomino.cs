using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceForDomino : MonoBehaviour
{
    [SerializeField] private DominoHolder myHolder;
    [SerializeField] private DominoPresenter dominoPresenter;

    private DominoHolder dominoInZone;

    public bool HasDomino()
    {
        return dominoInZone != null;
    }

    public bool IsDominoCorrect()
    {
        Domino myDomino = myHolder.GetDomino();
        Domino inZoneDomino = dominoInZone.GetDomino();
        bool returnValue = false;

        if (myHolder.HasWholeValue())
        {
            returnValue = inZoneDomino.EquealToWholeDomino(myDomino);
        }
        else
        {
            returnValue = inZoneDomino.EquealToNormalDomino(myDomino);
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
            Debug.Log("Enter: " + gameObject.name);

            if(dominoInZone == null) 
            {
                dominoInZone = other.GetComponent<DominoHolder>();

                dominoInZone.SetPlaceForDomino(this);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<DominoHolder>() != null 
            && other.GetComponent<DominoHolder>() == dominoInZone)
        {
            Debug.Log("Exit: " + gameObject.name);
            dominoInZone.RemovePlaceForDominoPosition(this);
            dominoInZone = null;

            //dominoPresenter.ShowText();

        }
    }
}
