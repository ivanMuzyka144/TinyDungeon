using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SingleSelectionSet : SelectionSet
{
    private List<ISelectable> selectionObjects = new List<ISelectable>();
    private Dictionary<RoomType, ISelectable> doorSelectionDict = new Dictionary<RoomType, ISelectable>();

    private ISelectable currentSelectedObject;

    public override void AddSelectionObject(ISelectable selectionObject, bool isFirstSelection)
    {
        selectionObjects.Add(selectionObject);
        if(selectionObjects.Count == 1)
        {
            currentSelectedObject = selectionObject;
        }
    }
    public void AddWithType(RoomType roomType, ISelectable selectionObject)
    {
        doorSelectionDict.Add(roomType, selectionObject);
        selectionObjects.Add(selectionObject);
        if (selectionObjects.Count == 1)
        {
            currentSelectedObject = selectionObject;
        }
    }

    public void MakeSelection()
    {
        if (currentSelectedObject != null)
            currentSelectedObject.OnSelected();
    }
   

    public override void SwitchSelection()
    {
        int indexOfCurrentSelection = selectionObjects.IndexOf(currentSelectedObject);

        if (indexOfCurrentSelection + 1 == selectionObjects.Count)
        {
            currentSelectedObject.OnDeselected();
            currentSelectedObject = selectionObjects[0];
        }
        else
        {
            currentSelectedObject.OnDeselected();
            currentSelectedObject = selectionObjects[indexOfCurrentSelection + 1];
        }
    }

    public override void BackSwitchSelection()
    {
        int indexOfCurrentSelection = selectionObjects.IndexOf(currentSelectedObject);

        if (indexOfCurrentSelection - 1 < 0)
        {
            currentSelectedObject.OnDeselected();
            currentSelectedObject = selectionObjects[selectionObjects.Count-1];
        }
        else
        {
            currentSelectedObject.OnDeselected();
            currentSelectedObject = selectionObjects[indexOfCurrentSelection - 1];
        }
    }

    public void SwitchWithType( RoomType doorType)
    {
        if (doorSelectionDict.ContainsKey(doorType))
        {
            if(currentSelectedObject != doorSelectionDict[doorType])
            {
                currentSelectedObject.OnDeselected();
                currentSelectedObject = doorSelectionDict[doorType];
            }

        }
    }

    public override void MakeSelectionAction()
    {
        if(currentSelectedObject!= null)
        {
            currentSelectedObject.MakeSelectionAction();
        }
    }

    public override void SelectFirstObject()
    {
        if (currentSelectedObject != null)
            currentSelectedObject.OnSelected();
    }

    public override void MakeFirstSelection(){ }
    public override void CancelFirstSelection() { }
    public override void MakeSecondSelection() { }
    public override void SelectSecondObject() { }
}
