using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRSelectionManager : MonoBehaviour
{
    public static VRSelectionManager Instance { get; private set; }

    public ISelectable selectedObj { get; private set; }

    [SerializeField] private Transform vrHandPoint;

    private bool isPaused;

    private void Awake() => Instance = this;
    void Update()
    {
        if (!isPaused)
        {


            ISelectable newSelected = MakeRaycast();
            if (newSelected != selectedObj)
            {
                if (selectedObj != null)
                {
                    selectedObj.OnDeselected();
                }
                if (newSelected != null)
                {
                    newSelected.OnSelected();
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
    }

    private ISelectable MakeRaycast()
    {
        ISelectable newSelectableObj = null;
        var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(ray, out var hit))
        {
            if (hit.transform.GetComponent<ISelectable>() != null)
            {
                newSelectableObj = hit.transform.GetComponent<ISelectable>();
            }
        }
        return newSelectableObj;
    }

    public void Pause() => isPaused = true;

    public void Unpause() => isPaused = false;


    public Vector3 GetHandPoint()
    {
        return vrHandPoint.position;
    }



}
