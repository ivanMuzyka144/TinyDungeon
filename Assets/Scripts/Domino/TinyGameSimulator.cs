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

    void Start()
    {
        Activate();
    }

    public void Activate()
    {
        difficultySimulator = DifficultySimulator.Instance;
        dominoGenerator = DominoGenerator.Instance;

        DifficultyType difficultyType = difficultySimulator.GetDifficultyType();

        topologyCollection.Activate();

        Topology currentTopology = topologyCollection.GetTopology(difficultyType);

        currentTopology.Activate();
        TopologyData topologyData = currentTopology.GetTopologyData();
        TopologyConfiguration topologyConfig = dominoGenerator.GenerateDominos(topologyData, minigameInfo);
        currentTopology.ConfugurateTopology(topologyConfig);
    }
}

