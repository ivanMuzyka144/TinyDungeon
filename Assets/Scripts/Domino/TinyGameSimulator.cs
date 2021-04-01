using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyGameSimulator : MonoBehaviour
{
    [SerializeField] private MinigameInfo minigameInfo;
    [Space(10)]
    [SerializeField] private TopologyCollection topologyCollection;
    [Space(10)]
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    private DifficultySimulator difficultySimulator;
    private DominoGenerator dominoGenerator;
    private EventSubscriber eventSubscriber;
    private ConditionChecker conditionChecker;

    void Start()
    {
        Activate();
    }

    public void Activate()
    {
        difficultySimulator = DifficultySimulator.Instance;

        dominoGenerator = GetComponent<DominoGenerator>();
        eventSubscriber = GetComponent<EventSubscriber>();
        conditionChecker = GetComponent<ConditionChecker>();

        topologyCollection.Activate();

        DifficultyType difficultyType = difficultySimulator.GetDifficultyType();

        Topology currentTopology = topologyCollection.GetTopology(difficultyType);
        currentTopology.Activate();
        TopologyData topologyData = currentTopology.GetTopologyData();
        TopologyConfiguration topologyConfig = dominoGenerator.GenerateDominos(topologyData);
        currentTopology.ConfugurateTopology(topologyConfig);

        eventSubscriber.SubscribeToEvent(currentTopology, this);

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
        //winPanel.SetActive(true);
        Debug.Log("Win!");
    }

    public void OnGameLose()
    {
        losePanel.SetActive(true);
        Debug.Log("Lose!");
    }
}

