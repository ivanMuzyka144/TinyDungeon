using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;

public class Box : MonoBehaviour
{
    [SerializeField] private List<Item> items = new List<Item>();
    [SerializeField] private List<GameObject> itemsModels = new List<GameObject>();
    [Space(10)]
    [SerializeField] private GameObject boxBody;
    [SerializeField] private Transform boxHolder;
    [Space(10)]
    [SerializeField] private float boxOpenTime;
    [SerializeField] private float boxOpenAngle;
    [SerializeField] private float modelFlyTime;
    [SerializeField] private float modelFlyPosition;
    [SerializeField] private float modelFlyAngle;

    private Dictionary<Item, GameObject> itemsDictionary = new Dictionary<Item, GameObject>();

    public void Activate()
    {
        for(int i = 0; i < items.Count; i++)
        {
            itemsDictionary.Add(items[i], itemsModels[i]);
        }
        boxBody.SetActive(true);
    }

    public void MakeEffectForItem(Item item, Action afterAnimAction)
    {
        GameObject itemModel = itemsDictionary[item];
        itemModel.SetActive(true);
        Action secondAction = () => { };

        OpenBox(secondAction);
        RotateItem(itemModel, afterAnimAction);
    }

    public void OpenBox(Action secondAction)
    {
        boxHolder.localEulerAnglesTransform(new Vector3(-boxOpenAngle,0,0), boxOpenTime)
            .EventTransition(secondAction, boxOpenTime);
    }

    public void RotateItem(GameObject itemModel, Action afterAnimAction)
    {
        Vector3 newPosition = itemModel.transform.position + new Vector3(0, modelFlyPosition, 0);
        itemModel.transform.positionTransition(newPosition, modelFlyTime);
        itemModel.transform.localEulerAnglesTransform(new Vector3(0,modelFlyAngle,0), modelFlyTime)
            .EventTransition(afterAnimAction, modelFlyTime);
    }

}
