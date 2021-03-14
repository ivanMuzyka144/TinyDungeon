using UnityEngine;
using Lean.Transition;

public class DoorAnimationMaker : MonoBehaviour
{

    private Door door;

    private float animTime = 0.75f;
    private float openCloseAnimTime = 0.75f;

    private float animY = 1.2f;
    private float animWidth = 1.5f;
    private float animHeight = 1.25f;

    private Vector3 startPosition;
    private Vector3 startRotation;
    public void Activate()
    {
        door = GetComponent<Door>();

        startPosition = transform.position;
        startRotation = transform.eulerAngles;
    }

    public void MakeAnimTopUp(Vector3 cameraRotation)
    {
        Vector3 newPosition = transform.position + new Vector3(-animHeight, animY, 0);
        Vector3 firstRotation = new Vector3(0, 0, -cameraRotation.x);
        transform.positionTransition(newPosition, animTime);
        transform.eulerAnglesTransform(firstRotation, animTime)
            .EventTransition(() => door.OnUpAnimationEnded(), animTime);
    }
    public void MakeAnimBottomUp(Vector3 cameraRotation)
    {
        Vector3 newPosition = transform.position + new Vector3(animHeight, animY, 0);
        Vector3 firstRotation = new Vector3(0, 0, -cameraRotation.x);
        transform.positionTransition(newPosition, animTime);
        transform.eulerAnglesTransform(firstRotation, animTime)
            .EventTransition(() => door.OnUpAnimationEnded(), animTime);
    }
    public void MakeAnimLeftUp(Vector3 cameraRotation)
    {
        Vector3 newPosition = transform.position + new Vector3(0, animY, -animWidth);
        Vector3 firstRotation = new Vector3(cameraRotation.x, 90, 0);
        transform.positionTransition(newPosition, animTime);
        transform.eulerAnglesTransform(firstRotation, animTime)
            .EventTransition(() => door.OnUpAnimationEnded(), animTime);
    }
    public void MakeAnimRightUp(Vector3 cameraRotation)
    {
        Vector3 newPosition = transform.position + new Vector3(0, animY, animWidth);
        Vector3 firstRotation = new Vector3(-cameraRotation.x, -90, 0);
        transform.positionTransition(newPosition, animTime);
        transform.eulerAnglesTransform(firstRotation, animTime)
            .EventTransition(() => door.OnUpAnimationEnded(), animTime);
    }

    public void MakeAnimTopBack(Vector3 cameraRotation)
    {
        Vector3 firstRotation = transform.eulerAngles + new Vector3(0, 0, cameraRotation.x);
        transform.positionTransition(startPosition, animTime);
        transform.eulerAnglesTransform(firstRotation, animTime)
            .EventTransition(() => door.OnBackAnimationEnded(), animTime);
    }
    public void MakeAnimBottomBack(Vector3 cameraRotation)
    {
        Vector3 firstRotation = new Vector3(0, 0, 360);
        transform.positionTransition(startPosition, animTime);
        transform.eulerAnglesTransform(firstRotation, animTime)
            .EventTransition(() => door.OnBackAnimationEnded(), animTime);
    }
    public void MakeAnimLeftBack(Vector3 cameraRotation)
    {
        Vector3 firstRotation = new Vector3(0, 0, 0);
        transform.positionTransition(startPosition, animTime);
        transform.eulerAnglesTransform(firstRotation, animTime)
            .EventTransition(() => door.OnBackAnimationEnded(), animTime);
    }
    public void MakeAnimRightBack(Vector3 cameraRotation)
    {
        Vector3 firstRotation = new Vector3(360, 360, 0);
        transform.positionTransition(startPosition, animTime);
        transform.eulerAnglesTransform(firstRotation, animTime)
            .EventTransition(() => door.OnBackAnimationEnded(), animTime);
    }

    public void MakeAnimTopOpen(Transform doorHolder)
    {
        Vector3 rotationVector = new Vector3(0, 90, 0);
        doorHolder.eulerAnglesTransform(rotationVector, openCloseAnimTime)
             .EventTransition(() => door.OnOpenAnimationEnded(), openCloseAnimTime);
    }
    public void MakeAnimBottomOpen(Transform doorHolder)
    {
        Vector3 rotationVector = new Vector3(0, 90, 0);
        doorHolder.eulerAnglesTransform(rotationVector, openCloseAnimTime)
            .EventTransition(() => door.OnOpenAnimationEnded(), openCloseAnimTime);
    }
    public void MakeAnimLeftOpen(Transform doorHolder)
    {
        Vector3 rotationVector = new Vector3(0, 90, 0);
        doorHolder.eulerAnglesTransform(rotationVector, openCloseAnimTime)
            .EventTransition(() => door.OnOpenAnimationEnded(), openCloseAnimTime);
    }
    public void MakeAnimRightOpen(Transform doorHolder)
    {
        Vector3 rotationVector = new Vector3(0, 90, 0);
        doorHolder.eulerAnglesTransform(rotationVector, openCloseAnimTime)
            .EventTransition(() => door.OnOpenAnimationEnded(), openCloseAnimTime);
    }

    public void MakeAnimTopClose(Transform doorHolder)
    {
        Vector3 rotationVector = new Vector3(0, 0, 0);
        doorHolder.eulerAnglesTransform(rotationVector, openCloseAnimTime)
            .EventTransition(() => door.OnCloseAnimationEnded(), openCloseAnimTime);
    }
    public void MakeAnimBottomClose(Transform doorHolder)
    {
        Vector3 rotationVector = new Vector3(0, 0, 0);
        doorHolder.eulerAnglesTransform(rotationVector, openCloseAnimTime)
            .EventTransition(() => door.OnCloseAnimationEnded(), openCloseAnimTime);
    }
    public void MakeAnimLeftClose(Transform doorHolder)
    {
        Vector3 rotationVector = new Vector3(0, 0, 0);
        doorHolder.eulerAnglesTransform(rotationVector, openCloseAnimTime)
            .EventTransition(() => door.OnCloseAnimationEnded(), openCloseAnimTime);
    }
    public void MakeAnimRightClose(Transform doorHolder)
    {
        Vector3 rotationVector = new Vector3(0, 0, 0);
        doorHolder.eulerAnglesTransform(rotationVector, openCloseAnimTime)
            .EventTransition(() => door.OnCloseAnimationEnded(), openCloseAnimTime);
    }
}