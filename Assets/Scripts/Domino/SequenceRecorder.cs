using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceRecorder : MonoBehaviour
{
    public static SequenceRecorder Instance { get; private set; }

    private void Awake() => Instance = this;

    public void Record()
    {
        Debug.Log("SEQUENCE");
    }
}
