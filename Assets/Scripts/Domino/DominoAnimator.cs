using Lean.Transition;
using System;
using UnityEngine;

public class DominoAnimator : MonoBehaviour
{
    [SerializeField] private float selectionHeight;
    [SerializeField] private float selectionHeightTime;
    [SerializeField] private float backTime;

    private Vector3 startPosition;
    private Vector3 currentBackPosition;
    private Vector3 finishPosition;

    private DominoHolder dominoHolder;
    private SimpleDominoSelector dominoSelector;

    public bool canMakeRotationAnimation;

    private PlatformManager platformManager;
    private PlatformType currentPlatform;

    public void Activate()
    {
        dominoHolder = GetComponent<DominoHolder>();
        dominoSelector = GetComponent<SimpleDominoSelector>();

        platformManager = PlatformManager.Instance;
        currentPlatform = platformManager.GetCurrentPlatform();

        if(currentPlatform == PlatformType.VR)
        {
            startPosition = transform.localPosition;
            currentBackPosition = startPosition;
            finishPosition = transform.localPosition + new Vector3(0,0,-selectionHeight);
        }
        else
        {
            startPosition = transform.position;
            currentBackPosition = startPosition;
            finishPosition = transform.position + new Vector3(0, selectionHeight, 0);
        }
    }
    public void MakeTowardAnim()
    {
        if (currentPlatform == PlatformType.VR)
        {
            transform.localPositionTransition(finishPosition, selectionHeightTime);
        }
        else
        {
            transform.positionTransition(finishPosition, selectionHeightTime);
        }
    }
    public void MakeBackAnim()
    {
        Action afterAnimAction = () =>
        {
            dominoHolder.OnDominoHasSet();
            dominoSelector.Unblock();
        };
        if (currentPlatform == PlatformType.VR)
        {
            transform.localPositionTransition(currentBackPosition, backTime)
                 .EventTransition(afterAnimAction, backTime);
        }
        else
        {
            transform.positionTransition(currentBackPosition, backTime)
                 .EventTransition(afterAnimAction, backTime);
        }
    }

    //public void MakeStepBack()
    //{
    //    if (currentPlatform == PlatformType.VR)
    //    {
    //        transform.localPosition = transform.localPosition - new Vector3(0, 0, -selectionHeight);
    //    }
    //    else
    //    {
    //        transform.position = transform.position - new Vector3(0, selectionHeight, 0);
    //    }
    //}

    public void SetPlaceForDominoPosition(Vector3 placeForDominoPosition)
    {
        currentBackPosition = placeForDominoPosition;
        

        if (currentPlatform == PlatformType.VR)
        {
            finishPosition = placeForDominoPosition + new Vector3(0, 0, -selectionHeight);
        }
        else
        {
            finishPosition = placeForDominoPosition + new Vector3(0, selectionHeight, 0);
        }
    }

    public void SetStartPosition()
    {
        if (currentPlatform == PlatformType.VR)
        {
            //transform.position = new Vector3(startPosition.x, transform.position.y, startPosition.z);
            transform.localPosition = startPosition;
        }
        else
        {
            transform.position = new Vector3(startPosition.x, transform.position.y, startPosition.z);
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
        }

    }

    public void RemovePlaceForDominoPosition()
    {
        currentBackPosition = startPosition;
        
        if (currentPlatform == PlatformType.VR)
        {
            finishPosition = startPosition + new Vector3(0, 0, -selectionHeight);
        }
        else
        {
            finishPosition = startPosition + new Vector3(0, selectionHeight, 0);
        }
    }

    public void MakeRotation(Vector3 rotation)
    {
        //if (canMakeRotationAnimation)
        //{
            canMakeRotationAnimation = false;
            transform.eulerAnglesTransform(rotation, 0.25f)
                      .EventTransition(() => canMakeRotationAnimation = true, 0.25f) ;
        //}
        
    }

    public void MakeNormalRotation()
    {
        //if (canMakeRotationAnimation)
        //{
            canMakeRotationAnimation = false;
            transform.eulerAnglesTransform(new Vector3(90, 0, -90), 0.25f)
                    .EventTransition(() => canMakeRotationAnimation = true, 0.25f);
        //}
    }
}
