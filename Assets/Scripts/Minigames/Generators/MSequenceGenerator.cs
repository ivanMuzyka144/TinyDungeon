using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSequenceGenerator : DominoGenerator
{
    public override TopologyConfiguration GenerateDominos(TopologyData topologyData, DifficultyType difficultyType)
    {
        TopologyConfiguration topologyConfiguration = new TopologyConfiguration();

        for(int i = 0; i< topologyData.questionsCount; i++)
        {
            Domino domino = new Domino();

            int topNumbValue = Random.Range(0, 7);
            int bottomNumbValue = Random.Range(0, 7);

            domino.SetDominoValue(topNumbValue,DominoPlace.Top);
            domino.SetDominoValue(bottomNumbValue, DominoPlace.Bottom);

            topologyConfiguration.AddQuestionDomino(domino);
            topologyConfiguration.AddAnswerDomino(domino);
        }

        return topologyConfiguration;
    }
}
