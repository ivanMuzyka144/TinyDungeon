using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopologyCollection : MonoBehaviour
{
    [SerializeField] private List<Topology> topologies = new List<Topology>();

    private Dictionary<DifficultyType, Topology> topologyDictionary = new Dictionary<DifficultyType, Topology>();
    public void Activate()
    {
        foreach (Topology topology in topologies)
        {
            topologyDictionary.Add(topology.GetDifficultyType(), topology);
        }
    }
    public Topology GetTopology( DifficultyType difficultyType)
    {
        return topologyDictionary[difficultyType];
    }
}
