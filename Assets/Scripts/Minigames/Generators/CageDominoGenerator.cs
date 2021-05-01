using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CageDominoGenerator : DominoGenerator
{
    [SerializeField] private CageConditionChecker cageConditionChecker;
    public override TopologyConfiguration GenerateDominos(TopologyData topologyData, DifficultyType difficultyType)
    {
        TopologyConfiguration returnTopologyConfiguration = null;

        switch (difficultyType)
        {
            case DifficultyType.Easy:
                returnTopologyConfiguration = GenerateEasyTopologyData(topologyData);
                break;
        }

        return returnTopologyConfiguration;
    }

    private TopologyConfiguration GenerateEasyTopologyData(TopologyData topologyData)
    {
        TopologyConfiguration returnTopologyConfiguration = new TopologyConfiguration();

        int firstNumber = 0;
        int lastNumber = 0;

        List<Domino> answerDominos = new List<Domino>();

        for(int i = 0; i< topologyData.questionsCount; i++)
        {
            if(i == 0)
            {
                Domino domino = new Domino();

                int topValue = Random.Range(0,7);
                int bottomValue = Random.Range(0, 7);

                firstNumber = bottomValue;
                lastNumber = topValue;

                domino.SetDominoValue(topValue, DominoPlace.Top);
                domino.SetDominoValue(bottomValue, DominoPlace.Bottom);

                returnTopologyConfiguration.AddQuestionDomino(domino);
                returnTopologyConfiguration.AddSmallPlacesDomino(domino);

            }
            else if(i+1 == topologyData.questionsCount)
            {
                Domino domino = new Domino();

                int topValue = firstNumber;
                int bottomValue = lastNumber;

                lastNumber = topValue;

                domino.SetDominoValue(topValue, DominoPlace.Top);
                domino.SetDominoValue(bottomValue, DominoPlace.Bottom);

                returnTopologyConfiguration.AddQuestionDomino(domino);
                returnTopologyConfiguration.AddSmallPlacesDomino(domino);
            }
            else
            {
                Domino domino = new Domino();

                int topValue = Random.Range(0, 7);
                int bottomValue = lastNumber;

                lastNumber = topValue;

                domino.SetDominoValue(topValue, DominoPlace.Top);
                domino.SetDominoValue(bottomValue, DominoPlace.Bottom);

                returnTopologyConfiguration.AddQuestionDomino(domino);
                returnTopologyConfiguration.AddSmallPlacesDomino(domino);

            }
        }

        List<int> avaibleNumbers = new List<int>();
        for(int i= 0; i<topologyData.questionsCount; i++)
        {
            avaibleNumbers.Add(i);
        }

        List<int> randomNumbers = new List<int>();
        
        for(int i = 0; i< topologyData.answersCount; i++)
        {
            int avaibleNumb = avaibleNumbers[Random.Range(0, avaibleNumbers.Count)];
            avaibleNumbers.Remove(avaibleNumb);
            randomNumbers.Add(avaibleNumb);
            cageConditionChecker.AddNumbersForHidding(avaibleNumb);
        }

        foreach(int randomNumber in randomNumbers)
        {
            Domino domino = returnTopologyConfiguration.questionsDominos[randomNumber];
            answerDominos.Add(domino);
        }
        List<Domino> shuffledAnswerDominos = answerDominos.OrderBy(x => Random.value).ToList();

        foreach (Domino domino in shuffledAnswerDominos)
        {
            returnTopologyConfiguration.AddAnswerDomino(domino);
        }
        
        return returnTopologyConfiguration;
    }
}
