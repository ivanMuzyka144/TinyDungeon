using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillsDominoGenerator : DominoGenerator
{
    public override TopologyConfiguration GenerateDominos(TopologyData topologyData, DifficultyType difficultyType)
    {
        TopologyConfiguration topologyConfiguration = new TopologyConfiguration();

        List<Domino> realAnswers = new List<Domino>();
        Domino[] randomDominos = new Domino[topologyData.questionsCount];

        Domino firstDomino = new Domino();
        Domino secondDomino = new Domino();
        Domino thirdDomino = new Domino();
        Domino forthDomino = new Domino();

        secondDomino.SetDominoValue(Random.Range(0, 7), DominoPlace.Top);
        secondDomino.SetDominoValue(Random.Range(0, 7), DominoPlace.Bottom);
        thirdDomino.SetDominoValue(Random.Range(0, 7), DominoPlace.Top);
        thirdDomino.SetDominoValue(Random.Range(0, 7), DominoPlace.Bottom);
        firstDomino.SetDominoValue(secondDomino.GetNumberValue(DominoPlace.Top), DominoPlace.Top);
        firstDomino.SetDominoValue(Random.Range(0, 7), DominoPlace.Bottom);
        forthDomino.SetDominoValue(thirdDomino.GetNumberValue(DominoPlace.Top), DominoPlace.Top);
        forthDomino.SetDominoValue(Random.Range(0, 7), DominoPlace.Bottom);

        realAnswers.Add(firstDomino);
        realAnswers.Add(secondDomino);
        realAnswers.Add(thirdDomino);
        realAnswers.Add(forthDomino);

        for (int i = 0; i < randomDominos.Length; i++)
        {
            Domino domino = new Domino();
            int topValue = Random.Range(0, 7);
            int bottomValue = Random.Range(0, 7);
            domino.SetDominoValue(topValue, DominoPlace.Top);
            domino.SetDominoValue(bottomValue, DominoPlace.Bottom);
            randomDominos[i]=domino;
        }

        int startRandomValue = Random.Range(0, 4);
        int secondRandomValue = 4;//Random.Range(4, 6);
        int thirdRandomValue = 6;//secondRandomValue + 2;
        int finRandomValue = Random.Range(8, 12);

        randomDominos[startRandomValue] = realAnswers[0];
        randomDominos[secondRandomValue] = realAnswers[1];
        randomDominos[thirdRandomValue] = realAnswers[2];
        randomDominos[finRandomValue] = realAnswers[3];


        foreach (Domino domino in randomDominos)
        {
            topologyConfiguration.AddQuestionDomino(domino);
        }
        return topologyConfiguration;
    }
}
