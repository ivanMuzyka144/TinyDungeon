using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    [SerializeField] private GameObject addModel;
    [SerializeField] private GameObject subModel;

    public void SetSign(SignType signType)
    {
        switch (signType)
        {
            case SignType.Add:
                addModel.SetActive(true);
                break;
            case SignType.Sub:
                subModel.SetActive(true);
                break;
        }
    }
}

public enum SignType
{
    Add,
    Sub
}
