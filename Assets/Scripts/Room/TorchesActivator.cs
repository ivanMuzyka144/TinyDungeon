using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchesActivator : MonoBehaviour
{
    [SerializeField] private Animator[] torchesAnimator;
    public void ActivateTorches()
    {
        foreach(Animator animator in torchesAnimator)
        {
            animator.SetBool("IsActive",true);
            animator.SetFloat("offset", 1 + Random.value);
        }
    }
}
