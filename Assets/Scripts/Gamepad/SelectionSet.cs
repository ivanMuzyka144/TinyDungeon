using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SelectionSet 
{
    public abstract void AddSelectionObject(ISelectable selectionObject, bool isFirstSelection);

    public abstract void SwitchSelection();
    public abstract void BackSwitchSelection();

    public abstract void MakeFirstSelection();
    public abstract void CancelFirstSelection();
    public abstract void MakeSecondSelection();

    public abstract void SelectFirstObject();
    public abstract void SelectSecondObject();

    public abstract void MakeSelectionAction();

}
