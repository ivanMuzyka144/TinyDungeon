using UnityEngine;
using Lean.Transition;

public class DoorAnimationMaker : MonoBehaviour
{

    private Door door;

    private float animTime = 1;

    private float animY = 1;
    private float animWidth = 1.5f;
    private float animHeight = 1.25f;

    public void Activate()
    {
        door = GetComponent<Door>();
    }

    public void MakeAnimTopUp(Vector3 cameraRotation)
    {
        Vector3 newPosition = transform.position + new Vector3(-animHeight, animY, 0);
        Vector3 firstRotation = new Vector3(0, 0, - cameraRotation.x);
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

    public void MakeAnimTopBack()
    {

    }
    public void MakeAnimBottomBack()
    {

    }
    public void MakeAnimLeftBack()
    {

    }
    public void MakeAnimRightBack()
    {

    }
}
