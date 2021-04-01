using Lean.Transition;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DominoSelector : MonoBehaviour, ISelectable
{

    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material selectedMaterial;
    [SerializeField] private float selectionHeight;
    [SerializeField] private float selectionHeightTime;
    [SerializeField] private float backTime;
    [Space(10)]
    [SerializeField] private DominoHolder dominoHolder;
    [SerializeField] private MeshRenderer meshRenderer;

    private bool isActive;
    private bool effectActivated;

    private Vector3 startPosition;
    private Vector3 currentBackPosition;
    private Vector3 finishPosition;



    private bool isSelected;

    public void Enable()
    {
        isActive = true;
        startPosition = transform.position;
        currentBackPosition = startPosition;
        finishPosition = transform.position + new Vector3(0,0, - selectionHeight);
    }

    public void Disable()
    {
        isActive = false;
        meshRenderer.material = defaultMaterial;
    }

    public void Activate()
    {
        meshRenderer.material = defaultMaterial;

        Action afterAnimAction = () =>
        {
            isActive = true;
            dominoHolder.OnDominoHasSet();
        };

        transform.positionTransition(currentBackPosition, backTime)
                  .EventTransition(afterAnimAction, backTime); 
    }

    public void OnSelected()
    {
        if (isActive && !effectActivated)
        {
            effectActivated = true;
            meshRenderer.material = selectedMaterial;
            transform.positionTransition(finishPosition, selectionHeightTime);

        }
        isSelected = true;
    }

    public void OnDeselected()
    {
        if (isActive)
        {
            effectActivated = false;
            meshRenderer.material = defaultMaterial;
            transform.positionTransition(currentBackPosition, selectionHeightTime);
        }
        isSelected = false;
    }

    public bool IsSelected()
    {
        return isSelected;
    }

    public bool IsActive()
    {
        return isActive;
    }

    public void OnStillSelected()
    {
        if (isActive)
        {
            OnSelected();
        }
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
