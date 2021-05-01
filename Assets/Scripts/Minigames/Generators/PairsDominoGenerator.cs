using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PairsDominoGenerator : DominoGenerator
{
    public override TopologyConfiguration GenerateDominos(TopologyData topologyData, DifficultyType difficultyType)
    {
        TopologyConfiguration topologyConfiguration = new TopologyConfiguration();

        int howManyPairs = topologyData.answersCount/2;

        List<Domino> dominoForPairs = new List<Domino>();
        for(int i = 0; i< howManyPairs; i++)
        {
            Domino newDomino = new Domino();
            newDomino.SetDominoValue(Random.Range(0, 7), DominoPlace.Top);
            newDomino.SetDominoValue(Random.Range(0, 7), DominoPlace.Bottom);
            dominoForPairs.Add(newDomino);
            dominoForPairs.Add(newDomino);
        }

        List<Domino> shuffledDominos = dominoForPairs.OrderBy(x => Random.value).ToList();

        foreach(Domino domino in shuffledDominos)
        {
            topologyConfiguration.AddAnswerDomino(domino);
        }

        return topologyConfiguration;
    }
}
