using System;
using UnityEngine;

public class RoomCategorySetter : MonoBehaviour
{
    [SerializeField] private CategoryCollection categoryCollection;
    
    private RoomCategory currentCategory;

    public void Activate()
    {
        categoryCollection.Activate();
    }

    public void SetStartRoomCategory()
    {
        currentCategory = categoryCollection.GetStartRoomCategory();
        currentCategory.ActivateCategory();
    }

    public void SetFinishDoorRoomCategory()
    {
        currentCategory = categoryCollection.GetFinishDoorRoomCategory();
        currentCategory.ActivateCategory();
    }

    public void SetFinishRoomCategory()
    {
        currentCategory = categoryCollection.GetFinishRoomCategory();
        currentCategory.ActivateCategory();
    }

    public void SetMinigameRoomCategory(MinigameInfo minigameInfo)
    {
        currentCategory = categoryCollection.GetMinigameRoomCategory(minigameInfo);
        currentCategory.ActivateCategory();
    }

    public RoomCategoryType GetRoomCategory()
    {
        RoomCategoryType returnType = RoomCategoryType.None;
        if(currentCategory != null)
        {
            returnType = currentCategory.GetType();
        }
        return returnType;
    }

    public MinigameInfo GetMinigameInfo()
    {
        MinigameInfo returnMinigameInfo = null;
        if(currentCategory!= null)
        {
            returnMinigameInfo = currentCategory.GetMinigameInfo();
        }
        return returnMinigameInfo;
    }
}
