using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DominoSelector : MonoBehaviour, ISelectable
{
    public EventHandler OnSelectionActionCalled;
    public abstract void OnDeselected();
    public abstract void OnSelected();
    public abstract void OnStillSelected();
    public abstract bool IsSelected();
    public abstract bool IsBlocked();
    public abstract void Block();
    public abstract void MakeReturnAction();
    public abstract void Enable();
    public abstract void Disable();
    public abstract void BlockForSec();
    public abstract void MakeSelectionAction();

    public GameObject GetObject()
    {
        return gameObject;
    }
}
