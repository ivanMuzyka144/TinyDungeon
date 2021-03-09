using System.Collections.Generic;
using UnityEngine;

public class RoomCategory : MonoBehaviour
{
    [SerializeField] public RoomCategoryType roomCategoryType;
    [Space(10)]
    [SerializeField] private MinigameInfo minigameInfo;
    [Space(10)]
    [SerializeField] private List<GameObject> assetsForActivation = new List<GameObject>();

    public void ActivateCategory()
    {
        foreach(GameObject asset in assetsForActivation)
        {
            asset.SetActive(true);
        }
    }
    public RoomCategoryType GetType()
    {
        return roomCategoryType;
    }

    public MinigameInfo GetMinigameInfo()
    {
        return minigameInfo;
    }
}
public enum RoomCategoryType
{
    StartRoom,
    FinishDoorRoom,
    FinishRoom,
    MinigameRoom,
    BonusRoom,
    None
}