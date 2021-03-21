using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public ISelectable selectedObj { get; private set; }

    void Update()
    {
        //if (selectedObj != null)
        //{
        //    selectedObj.OnDeselected();
        //}
        //selectedObj = null;

        //MakeRaycast();

        //if (selectedObj != null)
        //{
        //    selectedObj.OnSelected();
        //}

        ISelectable newSelected = MakeNewRaycast();
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
                selectedObj.TryToActivateEffect();
            }
        }
    }

    public ISelectable MakeNewRaycast()
    {
        ISelectable newSelectableObj = null;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit))
        {
            if (hit.transform.CompareTag("Selectable"))
            {
                newSelectableObj = hit.transform.GetComponent<ISelectable>();
            }
        }
        return newSelectableObj;
    }

    public void MakeRaycast()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit))
        {
            if (hit.transform.CompareTag("Selectable"))
            {
                //ISelectable newSelectedObj = hit.transform.GetComponent<ISelectable>();
                //if (newSelectedObj != selectedObj)
                //{
                //    if (selectedObj != null)
                //    {
                //        selectedObj.OnDeselected()l
                //    }
                //}
                selectedObj = hit.transform.GetComponent<ISelectable>();
            }
        }

    }
}