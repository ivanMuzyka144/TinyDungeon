using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Transition;

public class MiniGameExecutor : MonoBehaviour
{
    [SerializeField] private List<MiniGame> miniGames = new List<MiniGame>();

    private Dictionary<MinigameInfo, MiniGame> miniGamesDictionary = new Dictionary<MinigameInfo, MiniGame>();
    public void Activate()
    {
        foreach(MiniGame miniGame in miniGames)
        {
            miniGamesDictionary.Add(miniGame.GetMinigameInfo(), miniGame);
        }
    }
    public void Execute(MinigameInfo minigameInfo, Vector3 position, DifficultyType difficultyType)
    {
        MiniGame currentMiniGame = miniGamesDictionary[minigameInfo];
        currentMiniGame.transform.position = position;

        currentMiniGame.transform.positionTransition(position + new Vector3(0, 7, 0), 1);

        currentMiniGame.Activate();
        currentMiniGame.StartMinigame();
    }
}
