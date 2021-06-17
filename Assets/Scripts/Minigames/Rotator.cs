using System;
using UnityEngine;
using Lean.Transition;
public class Rotator : MonoBehaviour
{
    [SerializeField] private float rotationTime;
    [SerializeField] private DominoSelector dominoSelector;
    [SerializeField] private DominoHolder dominoHolder;
    [SerializeField] private PairsManager pairsManager;
    [Space(10)]
    [SerializeField] private GameAudioManager gameAudioManager;

    private bool canRotate;
    private bool isRotating;
    private bool isBlocked;
    public void Enable() 
    { 
        canRotate = true;
        dominoSelector.OnSelectionActionCalled += TryToMakeRotation;
    }
    public void Disable() 
    { 
        canRotate = false;
        dominoSelector.OnSelectionActionCalled -= TryToMakeRotation;
    }

    private void Update()
    {
        if (canRotate)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)
                && dominoSelector.IsSelected()
                && !dominoSelector.IsBlocked()
                && isRotating == false
                && !pairsManager.IsRecording()
                && !isBlocked)
            {
                isRotating = true;
                gameAudioManager.PlayDragSound();
                MakeNormalRotation();
            }
        }
    }
    
    public void TryToMakeRotation(object sender, EventArgs e)
    {
        if (canRotate)
        {
            if  (dominoSelector.IsSelected()
                && !dominoSelector.IsBlocked()
                && isRotating == false
                && !pairsManager.IsRecording()
                && !isBlocked)
            {
                isRotating = true;
                gameAudioManager.PlayDragSound();
                MakeNormalRotation();
            }
        }
    }

    private void MakeNormalRotation()
    {
        isBlocked = true;
        Action afterAnimAction = () =>
        {
            isRotating = false; 
            pairsManager.CheckCondition();
            dominoHolder.OnDominoHasRotated();
            pairsManager.StopRecording();
        };
        pairsManager.StartRecording();
        pairsManager.AddDominoHolder(dominoHolder);
        transform.localEulerAnglesTransform(transform.localEulerAngles + new Vector3(0,180,0), rotationTime)
                 .EventTransition(afterAnimAction, rotationTime);
    }

    public void MakeBackRotation()
    {
        isBlocked = false;
        Action afterAnimAction = () =>
        {
            isRotating = false;
            pairsManager.StopRecording();
        };
        pairsManager.StartRecording();
        transform.localEulerAnglesTransform(transform.localEulerAngles + new Vector3(0, 180, 0), rotationTime)
                 .EventTransition(afterAnimAction, rotationTime);
    }
}
