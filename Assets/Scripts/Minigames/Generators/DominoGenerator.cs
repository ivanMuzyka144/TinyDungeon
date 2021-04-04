using UnityEngine;

public abstract class DominoGenerator : MonoBehaviour
{
    public abstract TopologyConfiguration GenerateDominos(TopologyData topologyData, DifficultyType difficultyType);

    //public TopologyConfiguration GenerateDominos(TopologyData topologyData, MinigameInfo minigameInfo)
    //{
    //    TopologyConfiguration topologyConfiguration = null;

    //    switch (minigameInfo.GetName())
    //    {
    //        case MiniGameName.Math:
    //            topologyConfiguration = GetConfigForMathGame(topologyData);
    //            break;
    //    }

    //    return topologyConfiguration;
    //}


    //public TopologyConfiguration GetConfigForMathGame(TopologyData topologyData)
    //{
    //    TopologyConfiguration topologyConfiguration = new TopologyConfiguration();

    //    List<SignType> signTypes = new List<SignType>();

    //    for(int i = 0; i< topologyData.signsCount; i++)
    //    {
    //        SignType signType = Random.value >= 0.5f? SignType.Add : SignType.Sub;
    //        Debug.Log(signType);
    //        signTypes.Add(signType);
    //    }

    //    List<int> topQuestionValues = new List<int>();
    //    List<int> bottomQuestionValues = new List<int>();

    //    int topSum = 0;
    //    int bottomSum = 0;

    //    for(int i= 0; i< topologyData.questionsCount; i++)
    //    {
    //        if (i == 0)
    //        {
    //            int topValue = Random.Range(0, 7);
    //            int bottomValue = Random.Range(0, 7);
    //            topSum = topValue;
    //            bottomSum = bottomValue;
    //            topQuestionValues.Add(topValue);
    //            bottomQuestionValues.Add(bottomValue);
    //        }
    //        else
    //        {
    //            if (signTypes[i - 1] == SignType.Add)
    //            {
    //                int topValue = Random.Range(0, 7 - topSum);
    //                int bottomValue = Random.Range(0, 7 - bottomSum);
    //                topSum += topValue;
    //                bottomSum += bottomValue;
    //                topQuestionValues.Add(topValue);
    //                bottomQuestionValues.Add(bottomValue);
    //            }
    //            else if(signTypes[i - 1] == SignType.Sub)
    //            {
    //                int topValue = Random.Range(0, topSum + 1 );
    //                int bottomValue = Random.Range(0, bottomSum + 1);
    //                topSum -= topValue;
    //                bottomSum -= bottomValue;
    //                topQuestionValues.Add(topValue);
    //                bottomQuestionValues.Add(bottomValue);

    //            }
    //        }
    //    }

    //    for(int i =0; i< topQuestionValues.Count; i++)
    //    {
    //        Domino newQuestionDomino = new Domino();
    //        newQuestionDomino.SetDominoValue(topQuestionValues[i], DominoPlace.Top);
    //        newQuestionDomino.SetDominoValue(bottomQuestionValues[i], DominoPlace.Bottom);
    //        topologyConfiguration.AddQuestionDomino(newQuestionDomino);
    //    }

    //    Domino newSmallPlacesDomino = new Domino();
    //    newSmallPlacesDomino.SetDominoValue(topSum, DominoPlace.Top);
    //    newSmallPlacesDomino.SetDominoValue(bottomSum, DominoPlace.Bottom);
    //    topologyConfiguration.AddSmallPlacesDomino(newSmallPlacesDomino);

    //    for(int i = 0; i < topologyData.answersCount; i++)
    //    {
    //        Domino newDomino = new Domino();

    //        int finalTopValue = Random.Range(0, 7);
    //        int finalBottomValue = Random.Range(0, 7);
    //        finalTopValue = Random.value >= 0.5f ? topSum : finalTopValue;
    //        finalBottomValue = Random.value >= 0.5f ? bottomSum : finalBottomValue;
    //        if(finalTopValue == topSum && finalBottomValue == bottomSum)
    //        {
    //            if(Random.value >= 0.5f)
    //            {
    //                List<int> possibleTopValues = (new int[]{ 0, 1, 2, 3, 4, 5, 6 }).ToList();
    //                possibleTopValues.Remove(topSum);
    //                finalTopValue = possibleTopValues[Random.Range(0, possibleTopValues.Count)];
    //            }
    //            else
    //            {
    //                List<int> possibleBottomValues = (new int[] { 0, 1, 2, 3, 4, 5, 6 }).ToList();
    //                possibleBottomValues.Remove(bottomSum);
    //                finalBottomValue = possibleBottomValues[Random.Range(0, possibleBottomValues.Count)];
    //            }
    //        }
    //        newDomino.SetDominoValue(finalTopValue, DominoPlace.Top);
    //        newDomino.SetDominoValue(finalBottomValue, DominoPlace.Bottom);

    //        topologyConfiguration.AddAnswerDomino(newDomino);
    //    }

    //    int correctDomino = Random.Range(0, topologyConfiguration.answersDominos.Count);
    //    topologyConfiguration.answersDominos[correctDomino].SetDominoValue(topSum, DominoPlace.Top);
    //    topologyConfiguration.answersDominos[correctDomino].SetDominoValue(bottomSum, DominoPlace.Bottom);

    //    topologyConfiguration.AddRealAnswerDomino(topologyConfiguration.answersDominos[correctDomino]);

    //    topologyConfiguration.signTypes.AddRange(signTypes);

    //    return topologyConfiguration;
    //}
}

