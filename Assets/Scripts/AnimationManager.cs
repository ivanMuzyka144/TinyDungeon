using System;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager Instance { get; private set; }
    private void Awake() => Instance = this;

    private DoorShower doorShower;
    private Player player;

    public void Activate()
    {
        doorShower = DoorShower.Instance;
        player = Player.Instance;
    }

    public void MakeMovementSequence(object sender, EventArgs e)
    {
        GSEventArgs gsEventArgs = e as GSEventArgs;

        Action afterAnimAction = () => MovePlayer();
        
        OpenTwoDoors(gsEventArgs.direction, afterAnimAction);
    }

    public void OpenTwoDoors(RoomType directionType, Action afterAnimAction)
    {
        doorShower.ShowTwoDoorsOpenAnim(directionType, afterAnimAction);
    }

    public void MovePlayer()
    {

    }

    public void CloseDoors()
    {

    }
}
