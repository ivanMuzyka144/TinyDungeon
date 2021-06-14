using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayerRotator : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private PlatformManager platformManager;
    private PlatformType currentPlatform;

    private Player player;

    private bool stopped;

    void Start()
    {
        platformManager = PlatformManager.Instance;
        player = Player.Instance;

        currentPlatform = platformManager.GetCurrentPlatform();
    }
    
    void LateUpdate()
    {
        if(currentPlatform == PlatformType.VR && !stopped)
        {
            Vector3 playerPostion = playerTransform.position;

            var lookPos = playerPostion - transform.position;

            lookPos.y = 0;

            if (lookPos != Vector3.zero)
            {
                var rotation = Quaternion.LookRotation(lookPos);
                float rotationSpeed = 15 - Vector3.Distance(playerPostion, transform.position);
                transform.localRotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
            }
            
        }
    }

    public void StopRotator()
    {
        stopped = true;
    }

    public void ContiniuRotator()
    {
        stopped = true;
    }
}
