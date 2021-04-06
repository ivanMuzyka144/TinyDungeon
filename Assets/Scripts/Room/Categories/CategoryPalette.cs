using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CategoryPalette : MonoBehaviour
{
    [SerializeField] private List<MinigameInfo> allMinigameInfo = new List<MinigameInfo>();

    Dictionary<MinigameInfo, int> countOfMinigamesDictionary = new Dictionary<MinigameInfo, int>();

    private void Awake()
    {
        foreach(MinigameInfo minigameInfo in allMinigameInfo)
        {
            countOfMinigamesDictionary.Add(minigameInfo, 0);
        }
    }

    public MinigameInfo GenerateColorFor(List<MinigameInfo> relatedColors)
    {
        //List<MinigameInfo> possibleColors = 
        //    allMinigameInfo.Except(relatedColors).ToList<MinigameInfo>();

        //List<MinigameInfo> finalColors = new List<MinigameInfo>();

        //int minimalValue = countOfMinigamesDictionary.Values.Min();

        //foreach(MinigameInfo minigameInfo in possibleColors)
        //{
        //    if(countOfMinigamesDictionary[minigameInfo] == minimalValue)
        //    {
        //        finalColors.Add(minigameInfo);
        //    }
        //}

        //return finalColors[Random.Range(0, finalColors.Count)];

        return allMinigameInfo[Random.Range(0, allMinigameInfo.Count)];
    }
    
}
