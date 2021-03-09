using System.Collections.Generic;
using UnityEngine;

public class RoomLocator : MonoBehaviour
{
    private Dictionary<RoomType, Room> roomDictionary = new Dictionary<RoomType, Room>();

    public void SetRelatedRoom(Room room, RoomType roomType) => roomDictionary.Add(roomType, room);

    public bool HasRelatedRoom(Room room, RoomType roomType)
    {
        return roomDictionary[roomType] == room; 
    }

    public List<MinigameInfo> GetRelativeMinigameInfo()
    {
        List<MinigameInfo> relativeMinigameInfo = new List<MinigameInfo>();

        foreach(Room relativeRoom in roomDictionary.Values)
        {
            MinigameInfo minigameInfo = relativeRoom.GetMinigameInfo();
            if( minigameInfo!= null && !relativeMinigameInfo.Contains(minigameInfo))
            {
                relativeMinigameInfo.Add(minigameInfo);
            }
        }

        return relativeMinigameInfo;
    }


}
