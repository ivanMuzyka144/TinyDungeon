using System;
using UnityEngine;
using Lean.Transition;

public class MillsRotator : MonoBehaviour
{
    [SerializeField] private float rotationTime;
    [SerializeField] private DominoSelector dominoSelector;
    [SerializeField] private Mill mill;
    [SerializeField] private MillsRotationRegulator millsRotationRegulator;

    private bool canRotate;
    private bool isRotating;
    private bool isBlocked;

    private int rotationHasMade;

    public void Enable() 
    {
        //rotationHasMade = 0;
        canRotate = true; 
    }
    public void Disable() => canRotate = false;

    private void Update()
    {
        if (canRotate)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)
                && dominoSelector.IsSelected()
                && !dominoSelector.IsBlocked()
                && isRotating == false
                && !millsRotationRegulator.IsRotating())
            {
                isRotating = true;
                millsRotationRegulator.Block();
                MakeNormalRotation();
            }
        }
    }

    private void MakeNormalRotation()
    {
        Action afterAnimAction = () =>
        {
            isRotating = false;
            millsRotationRegulator.Unblock();
            mill.OnMillHasRotated();
        };
        transform.localEulerAnglesTransform(transform.localEulerAngles + new Vector3(0, 0, -90), rotationTime)
                 .EventTransition(afterAnimAction, rotationTime);
        rotationHasMade++;
        if(rotationHasMade == 4)
        {
            rotationHasMade = 0;
        }
    }

    public int GetRotationCount()
    {
        return rotationHasMade;
    }
}
