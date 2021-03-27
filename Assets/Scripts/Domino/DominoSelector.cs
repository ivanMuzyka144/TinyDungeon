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
    [SerializeField] private MeshRenderer meshRenderer;


    private bool isActive;
    private bool effectActivated;

    private Vector3 startPosition;
    private Vector3 finishPosition;

    private bool isSelected;

    public void Enable()
    {
        isActive = true;
        startPosition = transform.position;
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

        Action afterAnimAction = () => isActive = true;

        transform.positionTransition(startPosition, backTime)
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
            transform.positionTransition(startPosition, selectionHeightTime);
        }
        isSelected = false;
    }

    public bool IsSelected()
    {
        return isSelected;
    }

    public void TryToActivateEffect()
    {
        if (isActive)
        {
            OnSelected();
        }
    }


}
