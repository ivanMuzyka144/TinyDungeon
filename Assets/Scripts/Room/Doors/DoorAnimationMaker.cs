using UnityEngine;
using Lean.Transition;
using System;

public class DoorAnimationMaker : MonoBehaviour
{

    private Door door;

    private float animTime = 0.75f;
    private float openCloseAnimTime = 0.75f;

    private float animY = 5f;
    private float animWidth = 6f;
    private float animHeight = 3f;

    private Vector3 startPosition;
    private Vector3 startRotation;

    private PlatformManager platformManager;
    private PlatformType currentPlatform;

    private float animVrY = 6f;
    private float animVrWidth = 4f;
    private float animVrHeight = 1f;
    public void Activate()
    {
        door = GetComponent<Door>();

        startPosition = transform.position;
        startRotation = transform.eulerAngles;

        platformManager = PlatformManager.Instance;
        currentPlatform = platformManager.GetCurrentPlatform();
    }

    public void MakeAnimTopUp(Vector3 cameraRotation, Action afterAnimAction)
    {
        if (currentPlatform == PlatformType.VR)
        {
            Vector3 newPosition = transform.position + new Vector3(0, animVrY, 0);
            Vector3 firstRotation = new Vector3(0, 0, 30);
            transform.positionTransition(newPosition, animTime);
            transform.eulerAnglesTransform(firstRotation, animTime)
                .EventTransition(afterAnimAction, animTime);
        }
        else
        {
            Vector3 newPosition = transform.position + new Vector3(-animHeight - 0.5f, animY, 0.3f);
            Vector3 firstRotation = new Vector3(0, 0, -cameraRotation.x);
            Vector3 newScale = new Vector3(0.6f, 0.6f, 0.6f);
            transform.positionTransition(newPosition, animTime);
            transform.eulerAnglesTransform(firstRotation, animTime)
                .EventTransition(afterAnimAction, animTime);
            transform.localScaleTransition(newScale, animTime);
        }
    }
    public void MakeAnimBottomUp(Vector3 cameraRotation, Action afterAnimAction)
    {
        if (currentPlatform == PlatformType.VR)
        {
            Vector3 newPosition = transform.position + new Vector3(0, animVrY, 0);
            Vector3 firstRotation = new Vector3(0, 0, -30);
            transform.positionTransition(newPosition, animTime);
            transform.eulerAnglesTransform(firstRotation, animTime)
                .EventTransition(afterAnimAction, animTime);
        }
        else
        {
            Vector3 newPosition = transform.position + new Vector3(animHeight, animY, 0.45f);
            Vector3 firstRotation = new Vector3(0, 0, -cameraRotation.x);
            Vector3 newScale = new Vector3(0.6f, 0.6f, 0.6f);
            transform.positionTransition(newPosition, animTime);
            transform.eulerAnglesTransform(firstRotation, animTime)
                .EventTransition(afterAnimAction, animTime);
            transform.localScaleTransition(newScale, animTime);
        }
    }
    public void MakeAnimLeftUp(Vector3 cameraRotation, Action afterAnimAction)
    {
        if (currentPlatform == PlatformType.VR)
        {
            Vector3 newPosition = transform.position + new Vector3(0, animVrY, 0);
            Vector3 firstRotation = new Vector3(-30, 0, 0);
            transform.positionTransition(newPosition, animTime);
            transform.eulerAnglesTransform(firstRotation, animTime)
                .EventTransition(afterAnimAction, animTime);
        }
        else
        {
            Vector3 newPosition = transform.position + new Vector3(-0.3f, animY, -animWidth -0.5f);
            Vector3 firstRotation = new Vector3(0, 180, cameraRotation.x);
            Vector3 newScale = new Vector3(0.5f, 0.6f, 0.5f);
            transform.positionTransition(newPosition, animTime);
            transform.eulerAnglesTransform(firstRotation, animTime)
                .EventTransition(afterAnimAction, animTime);
            transform.localScaleTransition(newScale, animTime);
        }
    }
    public void MakeAnimRightUp(Vector3 cameraRotation, Action afterAnimAction)
    {
        if (currentPlatform == PlatformType.VR)
        {
            Vector3 newPosition = transform.position + new Vector3(0, animVrY, 0);
            Vector3 firstRotation = new Vector3(30, 0, 0);
            transform.positionTransition(newPosition, animTime);
            transform.eulerAnglesTransform(firstRotation, animTime)
                .EventTransition(afterAnimAction, animTime);
        }
        else
        {
            Vector3 newPosition = transform.position + new Vector3(0, animY, animWidth);
            Vector3 firstRotation = new Vector3(0, 0, -cameraRotation.x);
            Vector3 newScale = new Vector3(0.5f, 0.6f, 0.5f);
            transform.positionTransition(newPosition, animTime);
            transform.eulerAnglesTransform(firstRotation, animTime)
                .EventTransition(afterAnimAction, animTime);
            transform.localScaleTransition(newScale, animTime);
        }
    }

    public void MakeAnimTopBack(Vector3 cameraRotation, Action afterAnimAction)
    {
        if (currentPlatform == PlatformType.VR)
        {
            Vector3 newPosition = startPosition;
            Vector3 firstRotation = new Vector3(0, 0, 0);
            transform.positionTransition(newPosition, animTime);
            transform.eulerAnglesTransform(firstRotation, animTime)
                .EventTransition(afterAnimAction, animTime);
        }
        else
        {
            Vector3 firstRotation = transform.eulerAngles + new Vector3(0, 0, cameraRotation.x);
            Vector3 newScale = new Vector3(1f, 1f, 1f);
            transform.positionTransition(startPosition, animTime);
            transform.eulerAnglesTransform(firstRotation, animTime)
                .EventTransition(afterAnimAction, animTime);
            transform.localScaleTransition(newScale, animTime);
        }
    }
    public void MakeAnimBottomBack(Vector3 cameraRotation, Action afterAnimAction)
    {
        if (currentPlatform == PlatformType.VR)
        {
            Vector3 newPosition = startPosition;
            Vector3 firstRotation = new Vector3(0, 0, 0);
            transform.positionTransition(newPosition, animTime);
            transform.eulerAnglesTransform(firstRotation, animTime)
                .EventTransition(afterAnimAction, animTime);
        }
        else
        {
            Debug.Log("tr" + transform.eulerAngles +" f"+ startRotation);
            Vector3 firstRotation = transform.eulerAngles + new Vector3(0,180,90);
            Vector3 newScale = new Vector3(1f, 1f, 1f);
            transform.positionTransition(startPosition, animTime);
            transform.eulerAnglesTransform(firstRotation, animTime)
                .EventTransition(afterAnimAction, animTime);
            transform.localScaleTransition(newScale, animTime);
        }
    }
    public void MakeAnimLeftBack(Vector3 cameraRotation, Action afterAnimAction)
    {
        if (currentPlatform == PlatformType.VR)
        {
            Vector3 newPosition = startPosition;
            Vector3 firstRotation = transform.eulerAngles + new Vector3(30, 0, 0);
            transform.positionTransition(newPosition, animTime);
            transform.eulerAnglesTransform(firstRotation, animTime)
                .EventTransition(afterAnimAction, animTime);
        }
        else
        {
            Vector3 firstRotation = new Vector3(0, 90, 0);
            Vector3 newScale = new Vector3(1f, 1f, 1f);
            transform.positionTransition(startPosition, animTime);
            transform.eulerAnglesTransform(firstRotation, animTime)
                .EventTransition(afterAnimAction, animTime);
            transform.localScaleTransition(newScale, animTime);
        }

    }
    public void MakeAnimRightBack(Vector3 cameraRotation, Action afterAnimAction)
    {
        if (currentPlatform == PlatformType.VR)
        {
            Vector3 newPosition = startPosition;
            Vector3 firstRotation = new Vector3(0, 0, 0);
            transform.positionTransition(newPosition, animTime);
            transform.eulerAnglesTransform(firstRotation, animTime)
                .EventTransition(afterAnimAction, animTime);
        }
        else
        {
            Vector3 firstRotation = transform.eulerAngles + new Vector3(0, 90, 90);
            Vector3 newScale = new Vector3(1f, 1f, 1f);
            transform.positionTransition(startPosition, animTime);
            transform.eulerAnglesTransform(firstRotation, animTime)
                .EventTransition(afterAnimAction, animTime);
            transform.localScaleTransition(newScale, animTime);
        }
    }

    public void MakeAnimTopOpen(Transform doorHolder, Action afterAnimAction)
    {
        
            Vector3 rotationVector = doorHolder.transform.eulerAngles + new Vector3(0, 90, 0);
            doorHolder.eulerAnglesTransform(rotationVector, openCloseAnimTime)
                 .EventTransition(afterAnimAction, openCloseAnimTime);
        
    }
    public void MakeAnimBottomOpen(Transform doorHolder, Action afterAnimAction)
    {
        
            Vector3 rotationVector = doorHolder.transform.eulerAngles + new Vector3(0, 90, 0);
            doorHolder.eulerAnglesTransform(rotationVector, openCloseAnimTime)
                .EventTransition(afterAnimAction, openCloseAnimTime);

        
    }
    public void MakeAnimLeftOpen(Transform doorHolder, Action afterAnimAction)
    {
        
            Vector3 rotationVector = doorHolder.transform.eulerAngles + new Vector3(0, 90, 0);
            doorHolder.eulerAnglesTransform(rotationVector, openCloseAnimTime)
                .EventTransition(afterAnimAction, openCloseAnimTime);
        
    }
    public void MakeAnimRightOpen(Transform doorHolder, Action afterAnimAction)
    {
        
            Vector3 rotationVector = doorHolder.transform.eulerAngles + new Vector3(0, 90, 0);
            doorHolder.eulerAnglesTransform(rotationVector, openCloseAnimTime)
                .EventTransition(afterAnimAction, openCloseAnimTime);
        
    }

    public void MakeAnimTopClose(Transform doorHolder, Action afterAnimAction)
    {

        Vector3 rotationVector = new Vector3(0, 90, 0);
        doorHolder.eulerAnglesTransform(rotationVector, openCloseAnimTime)
                .EventTransition(afterAnimAction, openCloseAnimTime);
        
    }
    public void MakeAnimBottomClose(Transform doorHolder, Action afterAnimAction)
    {

        Vector3 rotationVector = new Vector3(0, 90, 0);
        doorHolder.eulerAnglesTransform(rotationVector, openCloseAnimTime)
                .EventTransition(afterAnimAction, openCloseAnimTime);
        
    }
    public void MakeAnimLeftClose(Transform doorHolder, Action afterAnimAction)
    {

        Vector3 rotationVector = new Vector3(0, 90, 0);
        doorHolder.eulerAnglesTransform(rotationVector, openCloseAnimTime)
                .EventTransition(afterAnimAction, openCloseAnimTime);
        
    }
    public void MakeAnimRightClose(Transform doorHolder, Action afterAnimAction)
    {
        
            Vector3 rotationVector = new Vector3(0, 90, 0);
        doorHolder.localEulerAnglesTransform(rotationVector, openCloseAnimTime)
                .EventTransition(afterAnimAction, openCloseAnimTime);        
    }
}