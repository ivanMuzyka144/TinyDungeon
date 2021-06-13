using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPainter : MonoBehaviour
{
    [SerializeField] private GameObject mainObjects;
    [Space(10)]
    [SerializeField] private MinigameInfo mathGame;
    [SerializeField] private GameObject mathObjects;
    [SerializeField] private TorchesActivator mathTorchesActivator;

    [Space(10)]
    [SerializeField] private MinigameInfo lettersGame;
    [SerializeField] private GameObject lettersObjects;
    [SerializeField] private TorchesActivator lettersTorchesActivator;

    [Space(10)]
    [SerializeField] private MinigameInfo pairsGame;
    [SerializeField] private GameObject pairsObjects;
    [SerializeField] private TorchesActivator pairsTorchesActivator;

    [Space(10)]
    [SerializeField] private MinigameInfo cageGame;
    [SerializeField] private GameObject cageObjects;
    [SerializeField] private TorchesActivator cageTorchesActivator;
    [Space(10)]
    [SerializeField] private MinigameInfo millsGame;
    [SerializeField] private GameObject millsObjects;
    [SerializeField] private TorchesActivator millsTorchesActivator;
    [Space(10)]
    [SerializeField] private MinigameInfo sequenceGame;
    [SerializeField] private GameObject sequenceObjects;
    [SerializeField] private TorchesActivator sequenceTorchesActivator;
    [Space(20)]
    [SerializeField] private TorchesActivator startFinalRoom;
    public void ColorMainRooms()
    {
        mainObjects.SetActive(true);
    }

    public void ColorObjects(MinigameInfo minigameInfo)
    {
        if (minigameInfo == mathGame)
        {
            mathObjects.SetActive(true);
        }
        else if (minigameInfo == lettersGame)
        {
            lettersObjects.SetActive(true);
        }
        else if (minigameInfo == cageGame)
        {
            cageObjects.SetActive(true);
        }
        else if (minigameInfo == sequenceGame)
        {
            sequenceObjects.SetActive(true);
        }
        else if (minigameInfo == pairsGame)
        {
            pairsObjects.SetActive(true);
        }
        else if (minigameInfo == millsGame)
        {
            millsObjects.SetActive(true);
        }
    }

    public void ActivateTorches(MinigameInfo minigameInfo)
    {
        if (minigameInfo == mathGame)
        {
            mathTorchesActivator.ActivateTorches();
        }
        else if (minigameInfo == lettersGame)
        {
            lettersTorchesActivator.ActivateTorches();
        }
        else if (minigameInfo == cageGame)
        {
            cageTorchesActivator.ActivateTorches();
        }
        else if (minigameInfo == sequenceGame)
        {
            sequenceTorchesActivator.ActivateTorches();
        }
        else if (minigameInfo == pairsGame)
        {
            pairsTorchesActivator.ActivateTorches();
        }
        else if (minigameInfo == millsGame)
        {
            millsTorchesActivator.ActivateTorches();
        }
    }

    public void ActivateStartTorches()
    {
        startFinalRoom.ActivateTorches();
    }
}
