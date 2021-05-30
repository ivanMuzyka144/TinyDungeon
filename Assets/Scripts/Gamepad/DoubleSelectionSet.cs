using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSelectionSet : SelectionSet
{
    private List<ISelectable> firstSelectionObjects = new List<ISelectable>();

    private List<ISelectable> unselectedSecondObjects = new List<ISelectable>();
    private List<ISelectable> selectedSecondObjects = new List<ISelectable>();

    private ISelectable firstSelectedObject;
    private ISelectable secondSelectedObject;

    private bool firstObjectHasSelected;
    public override void AddSelectionObject(ISelectable selectionObject, bool isFirstSelection)
    {
        if (isFirstSelection)
        {
            firstSelectionObjects.Add(selectionObject);
            if (firstSelectionObjects.Count == 1)
            {
                firstSelectedObject = selectionObject;
            }
        }
        else
        {
            unselectedSecondObjects.Add(selectionObject);
            if (unselectedSecondObjects.Count == 1)
            {
                secondSelectedObject = selectionObject;
            }
        }
    }

    public override void SwitchSelection()
    {
        if (firstObjectHasSelected)
        {
            int indexOfCurrentSelection = unselectedSecondObjects.IndexOf(secondSelectedObject);

            if (indexOfCurrentSelection + 1 == unselectedSecondObjects.Count)
            {
                secondSelectedObject.OnDeselected();
                secondSelectedObject = unselectedSecondObjects[0];
            }
            else
            {
                secondSelectedObject.OnDeselected();
                secondSelectedObject = unselectedSecondObjects[indexOfCurrentSelection + 1];
            }
        }
        else
        {
            int indexOfCurrentSelection = firstSelectionObjects.IndexOf(firstSelectedObject);

            if (indexOfCurrentSelection + 1 == firstSelectionObjects.Count)
            {
                firstSelectedObject.OnDeselected();
                firstSelectedObject = firstSelectionObjects[0];
            }
            else
            {
                firstSelectedObject.OnDeselected();
                firstSelectedObject = firstSelectionObjects[indexOfCurrentSelection + 1];
            }
        }
    }

    public override void BackSwitchSelection()
    {
        if (firstObjectHasSelected)
        {
            int indexOfCurrentSelection = unselectedSecondObjects.IndexOf(secondSelectedObject);

            if (indexOfCurrentSelection - 1 < 0)
            {
                secondSelectedObject.OnDeselected();
                secondSelectedObject = unselectedSecondObjects[unselectedSecondObjects.Count - 1];
            }
            else
            {
                secondSelectedObject.OnDeselected();
                secondSelectedObject = unselectedSecondObjects[indexOfCurrentSelection - 1];
            }
        }
        else
        {
            int indexOfCurrentSelection = firstSelectionObjects.IndexOf(firstSelectedObject);

            if (indexOfCurrentSelection - 1 < 0)
            {
                firstSelectedObject.OnDeselected();
                firstSelectedObject = firstSelectionObjects[firstSelectionObjects.Count - 1];
            }
            else
            {
                firstSelectedObject.OnDeselected();
                firstSelectedObject = firstSelectionObjects[indexOfCurrentSelection - 1];
            }
        }
    }

    public override void MakeFirstSelection()
    {
        firstObjectHasSelected = true;
    }

    public override void CancelFirstSelection()
    {
        firstObjectHasSelected = false;
        if (secondSelectedObject != null)
            secondSelectedObject.OnDeselected();
    }

    public override void MakeSecondSelection()
    {
        throw new System.NotImplementedException();
    }

    public override void MakeSelectionAction()
    {
        DominoHolder dominoHolder = firstSelectedObject.GetObject().GetComponent<DominoHolder>();
        PlaceForDomino placeForDomino = secondSelectedObject.GetObject().GetComponent<PlaceForDomino>();

        Action afterAnimAction = () => 
        {

            firstSelectedObject.OnDeselected();
            secondSelectedObject.OnDeselected();

            if (dominoHolder.HasPlaceForDomino())
            {
                if (selectedSecondObjects.Contains(dominoHolder.GetPlaceForDominoSelector()))
                {
                    unselectedSecondObjects.Add(dominoHolder.GetPlaceForDominoSelector());
                    selectedSecondObjects.Remove(dominoHolder.GetPlaceForDominoSelector());
                    dominoHolder.GetPlaceForDomino().RemoveDomino();
                }

            }
            ///block unblock
            placeForDomino.AddDomino(dominoHolder);
            unselectedSecondObjects.Remove(secondSelectedObject);
            selectedSecondObjects.Add(secondSelectedObject);
            firstObjectHasSelected = false;

            if (unselectedSecondObjects.Count > 0)
            {
                secondSelectedObject = unselectedSecondObjects[0];
            }
            SwitchSelection();
        };

        dominoHolder.MakeAutomaticDrag(placeForDomino, afterAnimAction);


    }

    public override void SelectFirstObject()
    {
        if(firstSelectedObject != null && !firstSelectedObject.IsSelected())
        {
            firstSelectedObject.OnSelected();
        }
            
    }

    public override void SelectSecondObject()
    {
        if (secondSelectedObject != null 
            && !secondSelectedObject.IsSelected()
            && firstObjectHasSelected)
        {
            secondSelectedObject.OnSelected();
        }
            
    }

    public void TryToMakeSelection()
    {
        if (firstObjectHasSelected)
        {
            MakeSelectionAction();
        }
        else
        {
            MakeFirstSelection();
        }
    }

    public void SetActiveElements(List<DominoHolder> activeElements)
    {
        unselectedSecondObjects.Clear();
        foreach(DominoHolder dominoHolder in activeElements)
        {
            unselectedSecondObjects.Add(dominoHolder.GetSelector());
            if (unselectedSecondObjects.Count == 1)
            {
                secondSelectedObject = unselectedSecondObjects[0];
            }
        }
    }
}
