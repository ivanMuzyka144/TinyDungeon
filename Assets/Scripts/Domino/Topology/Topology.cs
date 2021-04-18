using System;
using System.Collections.Generic;
using UnityEngine;

public class Topology : MonoBehaviour
{
    [SerializeField] private DifficultyType difficultyType;
    [Space(10)]
    [SerializeField] private GameObject topologyChildren;
    [Space(10)]
    [SerializeField] private List<DominoHolder> questionsDominoHolders = new List<DominoHolder>();
    [SerializeField] private List<DominoHolder> smallPlacesDominoHolders = new List<DominoHolder>();
    [SerializeField] private List<DominoHolder> answersDominoHolders = new List<DominoHolder>();
    [SerializeField] private List<Sign> signs = new List<Sign>();
    public void Activate()
    {
        topologyChildren.SetActive(true);
    }
    public DifficultyType GetDifficultyType()
    {
        return difficultyType;
    }

    public TopologyData GetTopologyData()
    {
        return new TopologyData(questionsDominoHolders.Count, 
                                smallPlacesDominoHolders.Count, 
                                answersDominoHolders.Count,
                                signs.Count);
    }

    public void ConfugurateTopology(TopologyConfiguration topologyConfiguration)
    {
        for (int i = 0; i < questionsDominoHolders.Count; i++)
        {
            questionsDominoHolders[i].SetDomino(topologyConfiguration.questionsDominos[i]);
        }

        for (int i = 0; i < smallPlacesDominoHolders.Count; i++)
        {
            smallPlacesDominoHolders[i].SetDomino(topologyConfiguration.smallPlacesDominos[i]);
        }

        for (int i = 0; i < answersDominoHolders.Count; i++)
        {
            answersDominoHolders[i].SetDomino(topologyConfiguration.answersDominos[i]);
        }

        for (int i = 0; i < signs.Count; i++)
        {
            signs[i].SetSign(topologyConfiguration.signTypes[i]);
        }

    }
    
    public void SetStartPositions()
    {
        for (int i = 0; i < questionsDominoHolders.Count; i++)
        {
            questionsDominoHolders[i].HideAllValueModels();
        }

        for (int i = 0; i < smallPlacesDominoHolders.Count; i++)
        {
            smallPlacesDominoHolders[i].HideAllValueModels();
        }
        for (int i = 0; i < answersDominoHolders.Count; i++)
        {
            answersDominoHolders[i].SetStartPosition();
            answersDominoHolders[i].HideAllValueModels();
        }
        for (int i = 0; i < signs.Count; i++)
        {
            signs[i].SetSign(SignType.None);
        }
    }
    public List<DominoHolder> GetAllQuestionDominos()
    {
        return questionsDominoHolders;
    }
    public List<DominoHolder> GetSmallPlacesDominos()
    {
        return smallPlacesDominoHolders;
    }
    public List<DominoHolder> GetAllAnswerDominos()
    {
        return answersDominoHolders;
    }
}

public class TopologyData
{
    public int questionsCount { get; private set; }
    public int smallPlacesCount { get; private set; }
    public int answersCount { get; private set; }
    public int signsCount { get; private set; }

    public TopologyData(int questionsCount, int smallPlacesCount, int answersCount, int signsCount)
    {
        this.questionsCount = questionsCount;
        this.smallPlacesCount = smallPlacesCount;
        this.answersCount = answersCount;
        this.signsCount = signsCount;
    }
}

public class TopologyConfiguration
{
    public List<Domino> questionsDominos = new List<Domino>();
    public List<Domino> smallPlacesDominos = new List<Domino>();
    public List<Domino> answersDominos = new List<Domino>();
    public List<Domino> realAnswersDominos = new List<Domino>();

    public List<SignType> signTypes = new List<SignType>();

    public void AddQuestionDomino(Domino domino) => questionsDominos.Add(domino);
    public void AddSmallPlacesDomino(Domino domino) => smallPlacesDominos.Add(domino);
    public void AddAnswerDomino(Domino domino) => answersDominos.Add(domino);
    public void AddRealAnswerDomino(Domino domino) => realAnswersDominos.Add(domino);

}
