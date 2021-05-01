using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillsRotationRegulator : MonoBehaviour
{
    private bool isRotating;
    
    public void Block() => isRotating = true;
    public void Unblock() => isRotating = false; 

    public bool IsRotating()
    {
        return isRotating;
    }
}
