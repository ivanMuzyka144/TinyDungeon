using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPainter : MonoBehaviour
{
    [SerializeField] private GameObject mainObjects;
    [Space(10)]
    [SerializeField] private MinigameInfo mathGame;
    [SerializeField] private GameObject mathObjects;

    [Space(10)]
    [SerializeField] private MinigameInfo lettersGame;
    [SerializeField] private GameObject lettersObjects;

    [Space(10)]
    [SerializeField] private MinigameInfo pairsGame;
    [SerializeField] private GameObject pairsObjects;

    [Space(10)]
    [SerializeField] private MinigameInfo cageGame;
    [SerializeField] private GameObject cageObjects;
    [Space(10)]
    [SerializeField] private MinigameInfo millsGame;
    [SerializeField] private GameObject millsObjects;
    [Space(10)]
    [SerializeField] private MinigameInfo sequenceGame;
    [SerializeField] private GameObject sequenceObjects;
    public void ColorMainRooms()
    {
        mainObjects.SetActive(true);
    }

    public void ColorObjects(MinigameInfo minigameInfo)
    {
        if(minigameInfo == mathGame)
        {
            mathObjects.SetActive(true);
        }
        else if (minigameInfo == lettersGame)
        {
            lettersObjects.SetActive(true);
        }
        else if(minigameInfo == cageGame)
        {
            cageObjects.SetActive(true);
        }
        else if(minigameInfo == sequenceGame)
        {
            sequenceObjects.SetActive(true);
        }
        else if(minigameInfo == pairsGame)
        {
            pairsObjects.SetActive(true);
        }
        else if(minigameInfo == millsGame)
        {
            millsObjects.SetActive(true);
        }
    }
}
