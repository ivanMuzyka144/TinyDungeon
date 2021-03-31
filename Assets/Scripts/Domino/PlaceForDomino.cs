﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceForDomino : MonoBehaviour
{
    public DominoHolder dominoInZone;
    public DominoHolder myHolder;

    private void Awake()
    {
        myHolder = GetComponent<DominoHolder>();
    }

    public bool HasDomino()
    {
        return dominoInZone != null;
    }

    public bool IsDominoCorrect()
    {
        Domino myDomino = myHolder.GetDomino();
        Domino inZoneDomino = dominoInZone.GetDomino();

        bool topResult = myDomino.GetNumberValue(DominoPlace.Top) == inZoneDomino.GetNumberValue(DominoPlace.Top);
        bool bottomResult = myDomino.GetNumberValue(DominoPlace.Bottom) == inZoneDomino.GetNumberValue(DominoPlace.Bottom);

        return topResult && bottomResult;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<DominoHolder>() != null)
        {
            if(dominoInZone == null) 
            {
                dominoInZone = other.GetComponent<DominoHolder>();

                dominoInZone.SetPlaceForDominoPosition(transform.position);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<DominoHolder>() != null 
            && other.GetComponent<DominoHolder>() == dominoInZone)
        {
            dominoInZone.RemovePlaceForDominoPosition();
            dominoInZone = null;

        }
    }
}