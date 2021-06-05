using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager Instance { get; private set; }
    private void Awake() => Instance = this;
    


    private DoorShower doorShower;
    private Player player;
    private GameStateManager gameStateManager;
    private StatisticsManager statisticsManager;

    public void Activate()
    {
        doorShower = DoorShower.Instance;
        player = Player.Instance;
        gameStateManager = GameStateManager.Instance;
        statisticsManager = StatisticsManager.Instance;
    }

    public void MakeMovementSequence(object sender, EventArgs e)
    {
        GSEventArgs gsEventArgs = e as GSEventArgs;
        OpenTwoDoors(gsEventArgs.direction);
    }

    public void OpenTwoDoors(RoomType directionType)
    {
        Action afterAnimAction = () => MovePlayer(directionType);
        Debug.Log("ff1");
        doorShower.ShowTwoDoorsOpenAnim(directionType, afterAnimAction);
    }

    public void MovePlayer(RoomType directionType)
    {
        Action afterAnimAction = () =>
        {
            player.SetIdleAnimation();
            CloseDoors(directionType);
            if (player.GetCurrentRoom().GetCategory() == RoomCategoryType.FinishRoom)
            {
                player.SetVictoryAnimation();
                gameStateManager.ChangeState(GameStateType.Finish);
            }
        };
        player.SetMoveAnimation(directionType);
        player.MoveToAnotherRoom(directionType, afterAnimAction);
    }

    public void CloseDoors(RoomType directionType)
    {
        Action afterAnimAction = () =>
        {
            gameStateManager.ChangeState(GameStateType.PlayerMinigame);
        };
        
        doorShower.ShowTwoDoorsCloseAnim(directionType, afterAnimAction);
    }

    public void ShowFinishAnim(object sender, EventArgs e)
    {
        statisticsManager.OnLevelCompleted();
        StartCoroutine(StartNewLevel(4));
    }

    IEnumerator StartNewLevel(float secs)
    {
        yield return new WaitForSeconds(secs);
        SceneManager.LoadScene("SampleScene");
    }
}
