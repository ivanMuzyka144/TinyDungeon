using System;
using UnityEngine;

public class RoomCategorySetter : MonoBehaviour
{
    //[SerializeField] private CategoryCollection categoryCollection;
    private RoomCategoryType currentType = RoomCategoryType.None;
    private MinigameInfo currentMiniGameInfo;

    private RoomPainter roomPainter;
    //private RoomCategory currentCategory;

    public void Activate()
    {
        roomPainter = GetComponent<RoomPainter>();
        //categoryCollection.Activate();
    }

    public void SetStartRoomCategory()
    {
        currentType = RoomCategoryType.StartRoom;
        roomPainter.ColorMainRooms();
        roomPainter.ActivateStartTorches();
        //currentCategory = categoryCollection.GetStartRoomCategory();
        //currentCategory.ActivateCategory();
    }

    public void SetFinishDoorRoomCategory()
    {
        currentType = RoomCategoryType.FinishDoorRoom;
        roomPainter.ColorMainRooms();
        roomPainter.ActivateStartTorches();
        //currentCategory = categoryCollection.GetFinishDoorRoomCategory();
        //currentCategory.ActivateCategory();
    }

    public void SetFinishRoomCategory()
    {
        currentType = RoomCategoryType.FinishRoom;
        roomPainter.ColorMainRooms();
        roomPainter.ActivateStartTorches();
        //currentCategory = categoryCollection.GetFinishRoomCategory();
        //currentCategory.ActivateCategory();
    }

    public void SetMinigameRoomCategory(MinigameInfo miInfo)
    {

        currentType = RoomCategoryType.MinigameRoom;
        currentMiniGameInfo = miInfo;
        roomPainter.ColorObjects(miInfo);
        //currentCategory = categoryCollection.GetMinigameRoomCategory(minigameInfo);
        //currentCategory.ActivateCategory();
    }
    public void ActivateRoomTorches(MinigameInfo miInfo)
    {
        roomPainter.ActivateTorches(miInfo);
    }

        public RoomCategoryType GetRoomCategory()
    {
        //RoomCategoryType returnType = RoomCategoryType.None;
        //if(currentCategory != null)
        //{
        //    returnType = currentCategory.GetType();
        //}
        return currentType;
    }

    public MinigameInfo GetMinigameInfo()
    {
        //MinigameInfo returnMinigameInfo = null;
        //if(currentCategory!= null)
        //{
        //    returnMinigameInfo = currentCategory.GetMinigameInfo();
        //}
        return currentMiniGameInfo;
    }
}
