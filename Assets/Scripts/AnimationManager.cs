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

    public void Activate()
    {
        doorShower = DoorShower.Instance;
        player = Player.Instance;
        gameStateManager = GameStateManager.Instance;
    }

    public void MakeMovementSequence(object sender, EventArgs e)
    {
        GSEventArgs gsEventArgs = e as GSEventArgs;
        OpenTwoDoors(gsEventArgs.direction);
    }

    public void OpenTwoDoors(RoomType directionType)
    {
        Action afterAnimAction = () => MovePlayer(directionType);
        
        doorShower.ShowTwoDoorsOpenAnim(directionType, afterAnimAction);
    }

    public void MovePlayer(RoomType directionType)
    {
        Action afterAnimAction = () =>
        {
            CloseDoors(directionType);
            if (player.GetCurrentRoom().GetCategory() == RoomCategoryType.FinishRoom)
            {
                gameStateManager.ChangeState(GameStateType.Finish);
            }
        };
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
        Debug.Log("YOU WIN!!!");
        StartCoroutine(StartNewLevel(2));
    }

    IEnumerator StartNewLevel(float secs)
    {
        yield return new WaitForSeconds(secs);
        SceneManager.LoadScene("SampleScene");
    }
}
