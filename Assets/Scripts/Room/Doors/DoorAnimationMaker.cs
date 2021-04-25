using UnityEngine;
using Lean.Transition;
using System;

public class DoorAnimationMaker : MonoBehaviour
{

    private Door door;

    private float animTime = 0.75f;
    private float openCloseAnimTime = 0.75f;

    private float animY = 4f;
    private float animWidth = 4f;
    private float animHeight = 3f;

    private Vector3 startPosition;
    private Vector3 startRotation;
    public void Activate()
    {
        door = GetComponent<Door>();

        startPosition = transform.position;
        startRotation = transform.eulerAngles;
    }

    public void MakeAnimTopUp(Vector3 cameraRotation, Action afterAnimAction)
    {
        Vector3 newPosition = transform.position + new Vector3(-animHeight -0.5f, animY, 0);
        Vector3 firstRotation = new Vector3(0, 0, -cameraRotation.x);
        transform.positionTransition(newPosition, animTime);
        transform.eulerAnglesTransform(firstRotation, animTime)
            .EventTransition(afterAnimAction, animTime);
    }
    public void MakeAnimBottomUp(Vector3 cameraRotation, Action afterAnimAction)
    {
        Vector3 newPosition = transform.position + new Vector3(animHeight, animY, 0);
        Vector3 firstRotation = new Vector3( 180,0, -cameraRotation.x);
        transform.positionTransition(newPosition, animTime);
        transform.eulerAnglesTransform(firstRotation, animTime)
            .EventTransition(afterAnimAction, animTime);
    }
    public void MakeAnimLeftUp(Vector3 cameraRotation, Action afterAnimAction)
    {
        Vector3 newPosition = transform.position + new Vector3(0, animY, -animWidth);
        Vector3 firstRotation = new Vector3(cameraRotation.x, 90, 0);
        transform.positionTransition(newPosition, animTime);
        transform.eulerAnglesTransform(firstRotation, animTime)
            .EventTransition(afterAnimAction, animTime);
    }
    public void MakeAnimRightUp(Vector3 cameraRotation, Action afterAnimAction)
    {
        Vector3 newPosition = transform.position + new Vector3(0, animY, animWidth);
        Vector3 firstRotation = new Vector3(-cameraRotation.x, -90, 0);
        transform.positionTransition(newPosition, animTime);
        transform.eulerAnglesTransform(firstRotation, animTime)
            .EventTransition(afterAnimAction, animTime);
    }

    public void MakeAnimTopBack(Vector3 cameraRotation, Action afterAnimAction)
    {
        Vector3 firstRotation = transform.eulerAngles + new Vector3(0, 0, cameraRotation.x);
        transform.positionTransition(startPosition, animTime);
        transform.eulerAnglesTransform(firstRotation, animTime)
            .EventTransition(afterAnimAction, animTime);
    }
    public void MakeAnimBottomBack(Vector3 cameraRotation, Action afterAnimAction)
    {
        Vector3 firstRotation = new Vector3(0, 0, 0);
        transform.positionTransition(startPosition, animTime);
        transform.eulerAnglesTransform(firstRotation, animTime)
            .EventTransition(afterAnimAction, animTime);
    }
    public void MakeAnimLeftBack(Vector3 cameraRotation, Action afterAnimAction)
    {
        Vector3 firstRotation = new Vector3(0, 0, 0);
        transform.positionTransition(startPosition, animTime);
        transform.eulerAnglesTransform(firstRotation, animTime)
            .EventTransition(afterAnimAction, animTime);
    }
    public void MakeAnimRightBack(Vector3 cameraRotation, Action afterAnimAction)
    {
        Vector3 firstRotation = new Vector3(360, 360, 0);
        transform.positionTransition(startPosition, animTime);
        transform.eulerAnglesTransform(firstRotation, animTime)
            .EventTransition(afterAnimAction, animTime);
    }

    public void MakeAnimTopOpen(Transform doorHolder, Action afterAnimAction)
    {
        Vector3 rotationVector = new Vector3(0, 90, 0);
        doorHolder.eulerAnglesTransform(rotationVector, openCloseAnimTime)
             .EventTransition(afterAnimAction, openCloseAnimTime);
    }
    public void MakeAnimBottomOpen(Transform doorHolder, Action afterAnimAction)
    {
        Vector3 rotationVector = new Vector3(0, 90, 0);
        doorHolder.eulerAnglesTransform(rotationVector, openCloseAnimTime)
            .EventTransition(afterAnimAction, openCloseAnimTime);
    }
    public void MakeAnimLeftOpen(Transform doorHolder, Action afterAnimAction)
    {
        Vector3 rotationVector = new Vector3(0, 90, 0);
        doorHolder.eulerAnglesTransform(rotationVector, openCloseAnimTime)
            .EventTransition(afterAnimAction, openCloseAnimTime);
    }
    public void MakeAnimRightOpen(Transform doorHolder, Action afterAnimAction)
    {
        Vector3 rotationVector = new Vector3(0, 90, 0);
        doorHolder.eulerAnglesTransform(rotationVector, openCloseAnimTime)
            .EventTransition(afterAnimAction, openCloseAnimTime);
    }

    public void MakeAnimTopClose(Transform doorHolder, Action afterAnimAction)
    {
        Vector3 rotationVector = new Vector3(0, 0, 0);
        doorHolder.eulerAnglesTransform(rotationVector, openCloseAnimTime)
            .EventTransition(afterAnimAction, openCloseAnimTime);
    }
    public void MakeAnimBottomClose(Transform doorHolder, Action afterAnimAction)
    {
        Vector3 rotationVector = new Vector3(0, 0, 0);
        doorHolder.eulerAnglesTransform(rotationVector, openCloseAnimTime)
            .EventTransition(afterAnimAction, openCloseAnimTime);
    }
    public void MakeAnimLeftClose(Transform doorHolder, Action afterAnimAction)
    {
        Vector3 rotationVector = new Vector3(0, 0, 0);
        doorHolder.eulerAnglesTransform(rotationVector, openCloseAnimTime)
            .EventTransition(afterAnimAction, openCloseAnimTime);
    }
    public void MakeAnimRightClose(Transform doorHolder, Action afterAnimAction)
    {
        Vector3 rotationVector = new Vector3(0, 0, 0);
        doorHolder.eulerAnglesTransform(rotationVector, openCloseAnimTime)
            .EventTransition(afterAnimAction, openCloseAnimTime);
    }
}