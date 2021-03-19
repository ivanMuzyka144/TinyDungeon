using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public ISelectable selectedObj { get; private set; }

    void Update()
    {
        if (selectedObj != null)
        {
            selectedObj.OnDeselected();
        }
        selectedObj = null;

        MakeRaycast();

        if (selectedObj != null)
        {
            selectedObj.OnSelected();
        }
    }

    public void MakeRaycast()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit))
        {
            if (hit.transform.CompareTag("Selectable"))
            {
                selectedObj = hit.transform.GetComponent<ISelectable>();
            }
        }

    }
}