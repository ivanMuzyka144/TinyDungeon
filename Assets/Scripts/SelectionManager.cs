using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public ISelectable selectedObj { get; private set; }

    void Update()
    {
        ISelectable newSelected = MakeRaycast();
        if(newSelected != selectedObj)
        {
            if(selectedObj!= null)
            {
                selectedObj.OnDeselected();
            }
            if(newSelected!= null)
            {
                newSelected.OnSelected();// if its not active it can be firstly selected
            }
            selectedObj = newSelected;
        }
        else
        {
            if (selectedObj != null)
            {
                selectedObj.OnStillSelected();
            }
        }
    }

    private ISelectable MakeRaycast()
    {
        ISelectable newSelectableObj = null;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit))
        {
            if (hit.transform.GetComponent<ISelectable>()!=null)
            {
                newSelectableObj = hit.transform.GetComponent<ISelectable>();
            }
        }
        return newSelectableObj;
    }
}