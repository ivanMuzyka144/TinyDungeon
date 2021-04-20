using Lean.Transition;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SimpleDominoSelector : DominoSelector
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material selectedMaterial;
    [Space(10)]
    [SerializeField] private float blockSec;

    private DominoAnimator dominoAnimator;

    private bool isActivated;
    private bool isSelected;

    private bool isBlocked;
    private bool returnActionHasCalled;
    private bool effectHasBeenApplied;

    public override void Enable()
    {
        isActivated = true;

        dominoAnimator = GetComponent<DominoAnimator>();
        dominoAnimator.Activate();
    }

    public override void Disable()
    {
        isActivated = false;
        meshRenderer.material = defaultMaterial;
        //dominoAnimator.MakeStepBack(); <--- It doesnt matter
        //Debug.Log(Lean.Transition.LeanTransition.) ;
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
    }


    public override void OnSelected()
    {
        if (isActivated && !isBlocked)
        {
            isSelected = true;
            meshRenderer.material = selectedMaterial;
            dominoAnimator.MakeTowardAnim();

        }
    }
    public override void OnDeselected()
    {
        if (isActivated && !isBlocked)
        {
            isSelected = false;
            meshRenderer.material = defaultMaterial;
            dominoAnimator.MakeBackAnim();
        }
    }

    public override void MakeReturnAction()
    {
        if (!returnActionHasCalled)
        {
            isSelected = false;
            meshRenderer.material = defaultMaterial;
            dominoAnimator.MakeBackAnim();
            returnActionHasCalled = true;
        }
    }

    public override void OnStillSelected()
    {
        if (!isBlocked && !isSelected)
        {
            OnSelected();
        }
    }
    public override void Block()
    {
        isBlocked = true;
    }
    public void Unblock()
    {
        //isBlocked = false;
        returnActionHasCalled = false;
    }

    public override void  BlockForSec() => StartCoroutine(BlockCoroutine());

    IEnumerator BlockCoroutine()
    {
        isBlocked = true;
        yield return new WaitForSeconds(blockSec);
        isBlocked = false;
    }

    public override bool IsSelected()
    {
        return isSelected;
    }

    public override bool IsBlocked()
    {
        return isBlocked;
    }
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

