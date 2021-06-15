using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomAnimationActivator : MonoBehaviour
{
   private void Awake()
    {
        GetComponent<Animator>().SetBool("IsActive", true);
    }
}
