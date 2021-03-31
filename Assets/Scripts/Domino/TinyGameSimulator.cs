using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyGameSimulator : MonoBehaviour
{
    [SerializeField] private MinigameInfo minigameInfo;
    [Space(10)]
    [SerializeField] private TopologyCollection topologyCollection;

    private DifficultySimulator difficultySimulator;
    private DominoGenerator dominoGenerator;
    private ConditionChecker conditionChecker;

    void Start()
    {
        Activate();
    }

    public void Activate()
    {
        difficultySimulator = DifficultySimulator.Instance;
        dominoGenerator = DominoGenerator.Instance;
        conditionChecker = GetComponent<ConditionChecker>();

        DifficultyType difficultyType = difficultySimulator.GetDifficultyType();

        topologyCollection.Activate();

        Topology currentTopology = topologyCollection.GetTopology(difficultyType);

        currentTopology.Activate();
        TopologyData topologyData = currentTopology.GetTopologyData();
        TopologyConfiguration topologyConfig = dominoGenerator.GenerateDominos(topologyData, minigameInfo);

        currentTopology.ConfugurateTopology(topologyConfig);

        foreach(DominoHolder answerDomino in currentTopology.GetAllAnswerDominos())
        {
            answerDomino.OnDominoSet += CheckCondition;
        }

        conditionChecker.Configurate(currentTopology);
    }

    public void CheckCondition(object sender, EventArgs e)
    {
        ConditionResult result = conditionChecker.CheckCondition();

        if(result == ConditionResult.Win)
        {
            OnGameWin();
        }
        else if(result == ConditionResult.Lose)
        {
            OnGameLose();
        }
    }

    public void OnGameWin()
    {
        Debug.Log("YOU WIN!");
    }

    public void OnGameLose()
    {
        Debug.Log("YOU LOSE!");
    }
}

