using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoGenerator : MonoBehaviour
{
    public static DominoGenerator Instance { get; private set; }

    private void Awake() => Instance = this;

    public TopologyConfiguration GenerateDominos(TopologyData topologyData, MinigameInfo minigameInfo)
    {
        TopologyConfiguration topologyConfiguration = null;

        switch (minigameInfo.GetName())
        {
            case MiniGameName.Math:
                topologyConfiguration = GetConfigForMathGame(topologyData);
                break;
        }

        return topologyConfiguration;
    }


    public TopologyConfiguration GetConfigForMathGame(TopologyData topologyData)
    {
        TopologyConfiguration topologyConfiguration = new TopologyConfiguration();

        int operationsCount = topologyData.questionsCount-1;

        List<bool> operations = new List<bool>();

        for(int i = 0; i< operationsCount; i++)
        {
            bool operation = Random.value >= 0.5;
            operations.Add(operation);
        }

        List<int> topQuestionValues = new List<int>();
        List<int> bottomQuestionValues = new List<int>();

        int topSum = 0;
        int bottomSum = 0;

        for(int i= 0; i< topologyData.questionsCount; i++)
        {
            if (i == 0)
            {
                int topValue = Random.Range(0, 7);
                int bottomValue = Random.Range(0, 7);
                topSum = topValue;
                bottomSum = bottomValue;
                topQuestionValues.Add(topValue);
                bottomQuestionValues.Add(bottomValue);
            }
            else
            {
                if (operations[i - 1] == true)
                {
                    int topValue = Random.Range(0, 7 - topSum);
                    int bottomValue = Random.Range(0, 7 - bottomSum);
                    topSum += topValue;
                    bottomSum += bottomValue;
                    topQuestionValues.Add(topValue);
                    bottomQuestionValues.Add(bottomValue);
                }
                else
                {
                    int topValue = Random.Range(0, topSum + 1 );
                    int bottomValue = Random.Range(0, bottomSum + 1);
                    topSum -= topValue;
                    bottomSum -= bottomValue;
                    topQuestionValues.Add(topValue);
                    bottomQuestionValues.Add(bottomValue);

                }
            }
        }

        for(int i =0; i< topQuestionValues.Count; i++)
        {
            Domino newQuestionDomino = new Domino();
            newQuestionDomino.SetDominoValue(topQuestionValues[i], DominoPlace.Top);
            newQuestionDomino.SetDominoValue(bottomQuestionValues[i], DominoPlace.Bottom);
            topologyConfiguration.AddQuestionDomino(newQuestionDomino);

            
            
        }
        Debug.Log("SUM:" + " (" + topSum + ";" + bottomSum + ")");

        Domino newSmallPlacesDomino = new Domino();
        newSmallPlacesDomino.SetDominoValue(topSum, DominoPlace.Top);
        newSmallPlacesDomino.SetDominoValue(bottomSum, DominoPlace.Bottom);
        topologyConfiguration.AddSmallPlacesDomino(newSmallPlacesDomino);

        return topologyConfiguration;
    }
}

