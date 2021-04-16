using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGPresenterManager : MonoBehaviour
{
    public static MGPresenterManager Instance { get; private set; }

    //private Dictionary<Room, MGPresenter> roomPresentersDictionary = new Dictionary<Room, MGPresenter>();
    private List<MGPresenter> mgPresenters = new List<MGPresenter>();

    private void Awake() => Instance = this;

    public void Activate()
    {

    }

    public void AddRoom(Room room, DifficultyType difficultyType)
    {
        mgPresenters.Add(room.GetMGPresenter());
        room.GetMGPresenter().SetDifficulty(difficultyType);
    }

    public void UpdatePresenters(DifficultyType difficultyType)
    {
        foreach(MGPresenter mgPresenter in mgPresenters)
        {
            mgPresenter.SetDifficulty(difficultyType);
        }
    }


}
