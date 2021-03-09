using System.Collections;
using System.Collections.Generic;
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

    public RoomCategory GetRoomCategory()
    {
        return currentCategory;
    }
    
}
