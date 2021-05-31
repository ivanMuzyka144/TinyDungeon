using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MaterialChanger : MonoBehaviour
{
    public Material defaultMaterial;
    public bool fixTiling = false; // Check this to correct the texture orientation.
    public GameObject canvasObject;
    public GameObject rightConroller;


    void OnEnable()
    {
        //Subscribe to the event that is called by SteamVR_RenderModel, when the controller and it's associated material has been loaded completely.
        SteamVR_Events.RenderModelLoaded.Listen(OnControllerLoaded);
    }
    void OnDisable()
    {
        SteamVR_Events.RenderModelLoaded.Remove(OnControllerLoaded);
    }

    
    public void UpdateControllerMaterial(Material newMaterial, Transform modelTransform, bool fixTiling = true)
    {
        if (fixTiling)
        {
            newMaterial.mainTextureScale = new Vector2(1, -1);
        }

        Transform rightModel = rightConroller.transform.Find("Model");
        canvasObject.transform.parent = rightModel.Find("body");
        canvasObject.transform.localPosition = Vector3.zero;
        canvasObject.transform.localEulerAngles = Vector3.zero;

        modelTransform.Find("body").GetComponent<MeshRenderer>().material = newMaterial;
        modelTransform.Find("button").GetComponent<MeshRenderer>().material = newMaterial;
        modelTransform.Find("led").GetComponent<MeshRenderer>().material = newMaterial;
        modelTransform.Find("lgrip").GetComponent<MeshRenderer>().material = newMaterial;
        modelTransform.Find("rgrip").GetComponent<MeshRenderer>().material = newMaterial;
        modelTransform.Find("scroll_wheel").GetComponent<MeshRenderer>().material = newMaterial;
        modelTransform.Find("sys_button").GetComponent<MeshRenderer>().material = newMaterial;
        modelTransform.Find("trackpad").GetComponent<MeshRenderer>().material = newMaterial;
        modelTransform.Find("trackpad_scroll_cut").GetComponent<MeshRenderer>().material = newMaterial;
        modelTransform.Find("trackpad_touch").GetComponent<MeshRenderer>().material = newMaterial;
        modelTransform.Find("trigger").GetComponent<MeshRenderer>().material = newMaterial;
    }

    void OnControllerLoaded(SteamVR_RenderModel controllerRenderModel, bool success)
    {
        UpdateControllerMaterial(defaultMaterial, controllerRenderModel.gameObject.transform, fixTiling);
    }

}
