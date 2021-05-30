using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillsSelector : DominoSelector
{
    [SerializeField] private List<MeshRenderer> meshRenderers = new List<MeshRenderer>();
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

    }

    public override void Disable()
    {
        isActivated = false;
        isSelected = false;
        foreach(MeshRenderer meshRenderer in meshRenderers)
        {
            meshRenderer.material = defaultMaterial;
        }
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
    }


    public override void OnSelected()
    {
        if (isActivated && !isBlocked)
        {
            isSelected = true;
            foreach (MeshRenderer meshRenderer in meshRenderers)
            {
                meshRenderer.material = selectedMaterial;
            }
        }
    }
    public override void OnDeselected()
    {
        if (isActivated && !isBlocked)
        {
            isSelected = false;
            foreach (MeshRenderer meshRenderer in meshRenderers)
            {
                meshRenderer.material = defaultMaterial;
            }
        }
    }

    public override void MakeReturnAction()
    {
        if (!returnActionHasCalled)
        {
            isSelected = false;
            foreach (MeshRenderer meshRenderer in meshRenderers)
            {
                meshRenderer.material = defaultMaterial;
            }
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
        returnActionHasCalled = false;
    }

    public override void BlockForSec() => StartCoroutine(BlockCoroutine());

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

    public override void MakeSelectionAction()
    {
        OnSelectionActionCalled?.Invoke(this, EventArgs.Empty);
    }
}
