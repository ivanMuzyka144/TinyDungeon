using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;

public class VRController : MonoBehaviour
{

    [SerializeField] private SteamVR_LaserPointer laser;

    public ISelectable selectedObj { get; private set; }

    private void Start()
    {
        //SteamVR_Actions.default_GrabPinch.AddOnStateDownListener(LeftTriggerPressed, SteamVR_Input_Sources.LeftHand);
        SteamVR_Actions.default_GrabPinch.AddOnStateDownListener(RightTriggerPressed, SteamVR_Input_Sources.RightHand);
        SteamVR_Actions.default_GrabPinch.AddOnStateUpListener(RightTriggerReleased, SteamVR_Input_Sources.RightHand);

        laser.PointerIn += PointerIn;
        laser.PointerOut += PointerOut;
    }

    public void PointerIn(object sender, PointerEventArgs e)
    {
        if (e.target.transform.GetComponent<ISelectable>() != null)
        {
            selectedObj = e.target.transform.GetComponent<ISelectable>();
            selectedObj.OnSelected();
        }

    }
    public void PointerOut(object sender, PointerEventArgs e)
    {
        if (e.target.transform.GetComponent<ISelectable>() != null)
        {
            selectedObj = null;
            e.target.transform.GetComponent<ISelectable>().OnDeselected();
        }

    }
    private void RightTriggerPressed(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if(selectedObj != null)
        {
            selectedObj.MakeSelectionAction();
        }
        laser.color = Color.red;
        laser.clickColor = Color.red;
    }

    private void RightTriggerReleased(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        laser.color = Color.yellow;
        laser.clickColor = Color.yellow;
    }
}