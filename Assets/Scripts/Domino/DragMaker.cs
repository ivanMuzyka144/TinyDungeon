﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;

public class DragMaker : MonoBehaviour
{
    [SerializeField] private DominoSelector dominoSelector;
    [Space(10)]
    [SerializeField] private float dragVelocity;

    private PlatformManager platformManager;
    private PlatformType currentType;
    private VRSelectionManager vrSelectionManager;

    private bool canDrag;
    private bool isDragged;
    private bool dragApplied;

    public void Enable()
    { 
        canDrag = true;
        platformManager = PlatformManager.Instance;
        currentType = platformManager.GetCurrentPlatform();

        vrSelectionManager = VRSelectionManager.Instance;
    }
    public void Disable() 
    { 
        canDrag = false; 
    }

    private void Update()
    {
        if(currentType == PlatformType.VR)
        {
            if (canDrag && currentType != PlatformType.Console)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0)
                    && dominoSelector.IsSelected()
                    && !dominoSelector.IsBlocked()
                    && isDragged == false)
                {
                    isDragged = true;
                    dragApplied = false;
                    dominoSelector.Block();
                }
                else if (Input.GetKeyUp(KeyCode.Mouse0) && isDragged == true)
                {
                    dominoSelector.MakeReturnAction();
                    isDragged = false;
                }

                if (isDragged)
                {
                    OnVRDrag();
                }
            }
        }
        else
        {
            if (canDrag && currentType != PlatformType.Console)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0)
                    && dominoSelector.IsSelected()
                    && !dominoSelector.IsBlocked()
                    && isDragged == false)
                {
                    isDragged = true;
                    dominoSelector.Block();
                }
                else if (Input.GetKeyUp(KeyCode.Mouse0) && isDragged == true)
                {
                    dominoSelector.MakeReturnAction();
                    isDragged = false;
                }

                if (isDragged)
                {
                    OnDrag();
                }
            }
        }
        
    }

    public void MakeAutomaticDrag(PlaceForDomino placeForDomino, Action afterAnimAction)
    {
        transform.positionTransition(placeForDomino.transform.position, 0.5f)
            .EventTransition(afterAnimAction, 0.5f);
    }

    private void OnDrag()
    {
        float dz = Camera.main.transform.position.y - transform.position.y;

        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dz);
        Vector3 point = Camera.main.ScreenToWorldPoint(mousePosition);
        point.y = gameObject.transform.position.y;

        gameObject.transform.position = point;
        //gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,
        //                                                    point, dragVelocity * Time.deltaTime);
    }

    private void OnVRDrag()
    {
        if (!dragApplied)
        {
            Vector3 handPoint = vrSelectionManager.GetHandPoint();
            gameObject.transform.positionTransition(handPoint, 0.2f);

            dragApplied = true;
        }
        
    }
}