using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCategory : MonoBehaviour
{
    [SerializeField] public string name;
    [SerializeField] public RoomCategoryType roomCategoryType;
    [Space(10)]
    [SerializeField] public float time;
    [SerializeField] private List<GameObject> assetsForActivation = new List<GameObject>();

    public void ActivateCategory()
    {
        foreach(GameObject asset in assetsForActivation)
        {
            asset.SetActive(true);
        }
    }
}
public enum RoomCategoryType
{
    StartRoom,
    FinishDoorRoom,
    FinishRoom,
    MinigameRoom,
    BonusRoom
}