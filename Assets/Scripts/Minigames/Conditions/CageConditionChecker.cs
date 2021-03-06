﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageConditionChecker : ConditionChecker
{
    private List<int> numbersForHidding = new List<int>();

    private List<DominoHolder> mypPlacesForDomino = new List<DominoHolder>();

    private PlatformManager platformManager;
    private DoubleSelectionSet currentDoubleSelectionSet;
    public void AddNumbersForHidding(int numb)
    {
        numbersForHidding.Add(numb);
    }
    public override void Configurate(Topology topology)
    {
        platformManager = PlatformManager.Instance;
        List<DominoHolder> questionDominos = topology.GetAllQuestionDominos();
        List<DominoHolder> placesForDomino = topology.GetSmallPlacesDominos();

        foreach (DominoHolder dominoHolder in placesForDomino)
        {
            dominoHolder.gameObject.SetActive(false);
        }
        mypPlacesForDomino.Clear();

        for ( int i =0; i< questionDominos.Count; i++)
        {
            if (numbersForHidding.Contains(i))
            {
                questionDominos[i].gameObject.SetActive(false);
                placesForDomino[i].gameObject.SetActive(true);
                mypPlacesForDomino.Add(placesForDomino[i]);
                placesForDomino[i].transform.position = questionDominos[i].transform.position;
                placesForDomino[i].transform.rotation = questionDominos[i].transform.rotation;
            }
            else
            {
                placesForDomino[i].gameObject.SetActive(false);
                questionDominos[i].gameObject.SetActive(true);
            }
        }
        numbersForHidding.Clear();

        if(platformManager.GetCurrentPlatform() == PlatformType.Console)
        {
            UpdateSelectionSet();
        }
    }

    public void SetSelectionSet(DoubleSelectionSet doubleSelectionSet)
    {
        currentDoubleSelectionSet = doubleSelectionSet;
    }
    private void UpdateSelectionSet()
    {
        currentDoubleSelectionSet.SetActiveElements(mypPlacesForDomino);
    }
    public override ConditionResult CheckCondition()
    {
        ConditionResult returnResult = ConditionResult.NotReady;
        bool result = true;
        foreach(DominoHolder dominoHolder in mypPlacesForDomino)
        {
            PlaceForDomino placeForDomino = dominoHolder.GetComponent<PlaceForDomino>();
            result = result & placeForDomino.IsDominoCorrect();
        }
        if (result)
        {
            returnResult = ConditionResult.Win;
        }

        return returnResult;
    }

    public List<DominoHolder> GetPlacesForDomino()
    {
        return mypPlacesForDomino;
    }

}
