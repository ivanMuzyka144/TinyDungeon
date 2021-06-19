using System;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    [SerializeField] private MinigameInfo minigameInfo;
    [Space(10)]
    [SerializeField] private TopologyCollection topologyCollection;

    private MinigameManager minigameManager;
    private DifficultySimulator difficultySimulator;
    private DominoGenerator dominoGenerator;
    private EventSubscriber eventSubscriber;
    private MoverSetter moverSetter;
    private ConditionChecker conditionChecker;

    private Topology currentTopology;

    private void Start()
    {
        //Activate();
        //ShowMiniGame();
        //EnableMiniGame();
    }
    public void Activate()
    {
        difficultySimulator = DifficultySimulator.Instance;
        minigameManager = MinigameManager.Instance;

        dominoGenerator = GetComponent<DominoGenerator>();
        eventSubscriber = GetComponent<EventSubscriber>();
        moverSetter = GetComponent<MoverSetter>();
        conditionChecker = GetComponent<ConditionChecker>();
        topologyCollection.Activate();

    }

    public void ShowMiniGame()
    {
        DifficultyType difficultyType = difficultySimulator.GetDifficultyType();

        currentTopology = topologyCollection.GetTopology(difficultyType);
        currentTopology.Activate();
        TopologyData topologyData = currentTopology.GetTopologyData();
        TopologyConfiguration topologyConfig = dominoGenerator.GenerateDominos(topologyData, difficultyType);


        currentTopology.ConfugurateTopology(topologyConfig);
        Debug.Log("KEEEEEk");
    }

    public void ShowOrHideElement()
    {
        conditionChecker.Configurate(currentTopology);
    }
    public void EnableMiniGame(bool shouldConfigurate)
    {
        moverSetter.SetMover(currentTopology);
        eventSubscriber.SubscribeToEvent(currentTopology, this);
        if (shouldConfigurate)
        {
            conditionChecker.Configurate(currentTopology);
        }
    }
    public void DisableMiniGame()
    {
        moverSetter.DestroyMover(currentTopology);
        eventSubscriber.UnsubscribeToEvent(currentTopology, this);
    }

    public void ClearPlacesForDomino()
    {
        moverSetter.ClearPlacesForDomino(currentTopology);
        currentTopology.SetZeroRotation();
    }

    public void SetZeroRotation()
    {
        currentTopology.SetZeroRotation();
    }
    
    public void RenewMiniGame()
    {
        currentTopology.SetStartPositions();
    }

    public void CheckCondition(object sender, EventArgs e)
    {
        ConditionResult result = conditionChecker.CheckCondition();

        if (result == ConditionResult.Win)
        {
            OnGameWin();
        }
        else if (result == ConditionResult.Lose)
        {
            OnGameLose();
        }
    }

    public void OnGameWin()
    {
        minigameManager.WinMiniGame();
    }

    public void OnGameLose()
    {
        minigameManager.LoseMiniGame();
    }

    public MinigameInfo GetMinigameInfo()
    {
        return minigameInfo;
    }

    public SelectionSet GenerateSelectionSet()
    {
        DifficultyType difficultyType = difficultySimulator.GetDifficultyType();

        currentTopology = topologyCollection.GetTopology(difficultyType);

        return currentTopology.GenerateSelectionSet(minigameInfo);
    }
}

