using Lean.Transition;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DominoSelector : MonoBehaviour, ISelectable
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material selectedMaterial;

    private DominoAnimator dominoAnimator;

    private bool isActivated;
    private bool isSelected;

    private bool isBlocked;
    private bool returnActionHasCalled;
    private bool effectHasBeenApplied;

    public void Enable()
    {
        isActivated = true;

        dominoAnimator = GetComponent<DominoAnimator>();
        dominoAnimator.Activate();
    }
    public void OnSelected()
    {
        if (isActivated && !isBlocked)
        {
            Debug.Log("SELECTED");
            isSelected = true;
            meshRenderer.material = selectedMaterial;
            dominoAnimator.MakeTowardAnim();

        }
    }
    public void OnDeselected()
    {
        if (isActivated && !isBlocked)
        {
            Debug.Log("DESELECTED");
            isSelected = false;
            meshRenderer.material = defaultMaterial;
            dominoAnimator.MakeBackAnim();
        }
    }

    public void MakeReturnAction()
    {
        if (!returnActionHasCalled)
        {
            isSelected = false;
            meshRenderer.material = defaultMaterial;
            dominoAnimator.MakeBackAnim();
            returnActionHasCalled = true;
        }
    }

    public void OnStillSelected()
    {
        if (!isBlocked && !isSelected)
        {
            OnSelected();
        }
    }
    public void Block()
    {
        isBlocked = true;
    }
    public void Unblock()
    {
        isBlocked = false;
        returnActionHasCalled = false;
    }

    public bool IsSelected()
    {
        return isSelected;
    }

    public bool IsBlocked()
    {
        return isBlocked;
    }



    //[SerializeField] private Material defaultMaterial;
    //[SerializeField] private Material selectedMaterial;
    //[SerializeField] private float selectionHeight;
    //[SerializeField] private float selectionHeightTime;
    //[SerializeField] private float backTime;
    //[Space(10)]
    //[SerializeField] private DominoHolder dominoHolder;
    //[SerializeField] private MeshRenderer meshRenderer;

    //private bool isActive;
    //private bool effectActivated;

    //private Vector3 startPosition;
    //private Vector3 currentBackPosition;
    //private Vector3 finishPosition;



    //private bool isSelected;

    //public void Enable()
    //{
    //    isActive = true;
    //    startPosition = transform.position;
    //    currentBackPosition = startPosition;
    //    finishPosition = transform.position + new Vector3(0,0, - selectionHeight);
    //}

    //public void Disable()
    //{
    //    isActive = false;
    //    meshRenderer.material = defaultMaterial;
    //}

    //public void Activate()
    //{
    //    meshRenderer.material = defaultMaterial;

    //    Action afterAnimAction = () =>
    //    {
    //        isActive = true;
    //        dominoHolder.OnDominoHasSet();
    //    };

    //    transform.positionTransition(currentBackPosition, backTime)
    //              .EventTransition(afterAnimAction, backTime); 
    //}

    //public void OnSelected()
    //{
    //    if (isActive && !effectActivated)
    //    {
    //        effectActivated = true;
    //        meshRenderer.material = selectedMaterial;
    //        transform.positionTransition(finishPosition, selectionHeightTime);

    //    }
    //    isSelected = true;
    //}

    //public void OnDeselected()
    //{
    //    if (isActive)
    //    {
    //        effectActivated = false;
    //        meshRenderer.material = defaultMaterial;
    //        transform.positionTransition(currentBackPosition, selectionHeightTime);
    //    }
    //    isSelected = false;
    //}

    //public bool IsSelected()
    //{
    //    return isSelected;
    //}

    //public bool IsActive()
    //{
    //    return isActive;
    //}

    //public void OnStillSelected()
    //{
    //    if (isActive)
    //    {
    //        OnSelected();
    //    }
    //}

    //public void SetPlaceForDominoPosition(Vector3 placeForDominoPosition)
    //{
    //    currentBackPosition = placeForDominoPosition;
    //    finishPosition = placeForDominoPosition + new Vector3(0, 0, -selectionHeight);
    //}

    //public void RemovePlaceForDominoPosition() 
    //{
    //    currentBackPosition = startPosition;
    //    finishPosition = startPosition + new Vector3(0, 0, -selectionHeight);
    //}

}
