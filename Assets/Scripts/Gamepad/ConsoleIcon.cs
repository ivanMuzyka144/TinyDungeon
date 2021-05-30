using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleIcon : MonoBehaviour
{
    [SerializeField] private GameObject iconObject;

    private PlatformManager platformManager;

    private void Awake()
    {
        platformManager = PlatformManager.Instance;
        if(platformManager.GetCurrentPlatform() == PlatformType.Console)
        {
            iconObject.SetActive(true);
        }
        else
        {
            iconObject.SetActive(false);
        }
    }


}
