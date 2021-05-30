using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamepadSelectionManager : MonoBehaviour
{
    public static GamepadSelectionManager Instance { get; private set; }

    [SerializeField] private MinigameInfo cageMinigame;
    [SerializeField] private CageConditionChecker cageConditionChecker;

    private DoorShower doorShower;
    private MinigameManager minigameManager;
    private GamepadController gamepadController;
    private UIManager uiManager;

    private SelectionSet currentSet;

    private GameStateType currentState;
    private MinigameInfo currentGame;

    private bool isGameMenuActive;
    private bool canSelect;
    private bool gameMenuOpened;
    private bool askPanelOpened;

    private void Awake() => Instance = this;

    public void Activate()
    {
        doorShower = DoorShower.Instance;
        minigameManager = MinigameManager.Instance;
        uiManager = UIManager.Instance;
        gamepadController = GetComponent<GamepadController>();

        gamepadController.OnOptionsPressed += SwitchGameMenu;
        gamepadController.OnCrossPressed += ShowAskPanelMenu;
        gamepadController.OnTrianglePressed += HideAskPanelMenu;
        gamepadController.OnSquarePressed += ExitToMainScene;
        canSelect = true;

    }

    public void SetDoorSelecting(object sender, EventArgs e)
    {
        currentState = GameStateType.PlayerSelectDoor;
        currentSet = doorShower.GenerateSelectionSet();

        gamepadController.OnR1Pressed += MakeSwitching;
        gamepadController.OnL1Pressed += MakeBackSwitching;

        gamepadController.OnDpadTopPressed += SelectTopDoor;
        gamepadController.OnDpadRightPressed += SelectRightDoor;
        gamepadController.OnDpadDownPressed += SelectBottomDoor;
        gamepadController.OnDpadLeftPressed += SelectLeftDoor;
        gamepadController.OnCrossPressed += MakeSelectionAction;
    }

    public void RemoveDoorSelecting(object sender, EventArgs e)
    {
        currentSet = null;
        if (currentState == GameStateType.PlayerSelectDoor)
        {
            currentState = GameStateType.PlayerSelectDoor;
            gamepadController.OnR1Pressed -= MakeSwitching;
            gamepadController.OnL1Pressed -= MakeBackSwitching;

            gamepadController.OnDpadTopPressed -= SelectTopDoor;
            gamepadController.OnDpadRightPressed -= SelectRightDoor;
            gamepadController.OnDpadDownPressed -= SelectBottomDoor;
            gamepadController.OnDpadLeftPressed -= SelectLeftDoor;
            gamepadController.OnCrossPressed -= MakeSelectionAction;
        }

    }

    public void SetMinigameSelecting(object sender, EventArgs e)
    {
        SelectionSet thisSet = minigameManager.GenerateSelectionSet();
        currentGame = minigameManager.GetCurrentMinigame();

        if (thisSet != null)
        {
            currentSet = thisSet;
            currentState = GameStateType.PlayerMinigame;


            if (currentGame.UsePlaceForDomino())
            {
                gamepadController.OnR1Pressed += MakeSwitching;
                gamepadController.OnL1Pressed += MakeBackSwitching;
                gamepadController.OnDpadRightPressed += MakeSwitching;
                gamepadController.OnDpadLeftPressed += MakeBackSwitching;
                gamepadController.OnCrossPressed += MakeFirstSelection;
                gamepadController.OnCirclePressed += CancelFirstSelection;

                if (currentGame == cageMinigame)
                {
                    cageConditionChecker.SetSelectionSet(currentSet as DoubleSelectionSet);
                }
            }
            else
            {
                gamepadController.OnR1Pressed += MakeSwitching;
                gamepadController.OnL1Pressed += MakeBackSwitching;
                gamepadController.OnDpadRightPressed += MakeSwitching;
                gamepadController.OnDpadLeftPressed += MakeBackSwitching;
                gamepadController.OnCrossPressed += MakeSelectionAction;
            }
        }

    }

    public void RemoveMinigameSelecting(object sender, EventArgs e)
    {
        currentSet = null;

        if (currentState == GameStateType.PlayerMinigame)
        {
            if (currentGame.UsePlaceForDomino())
            {
                gamepadController.OnR1Pressed -= MakeSwitching;
                gamepadController.OnL1Pressed -= MakeBackSwitching;
                gamepadController.OnDpadRightPressed -= MakeSwitching;
                gamepadController.OnDpadLeftPressed -= MakeBackSwitching;
                gamepadController.OnCrossPressed -= MakeFirstSelection;
                gamepadController.OnCirclePressed -= CancelFirstSelection;
            }
            else
            {
                gamepadController.OnR1Pressed -= MakeSwitching;
                gamepadController.OnL1Pressed -= MakeBackSwitching;
                gamepadController.OnDpadRightPressed -= MakeSwitching;
                gamepadController.OnDpadLeftPressed -= MakeBackSwitching;
                gamepadController.OnCrossPressed -= MakeSelectionAction;
            }
        }

    }
    public void SwitchGameMenu(object sender, EventArgs e)
    {
        if (!askPanelOpened)
        {
            if (isGameMenuActive)
            {
                ActivateGameMenu();
            }
            else
            {
                HideGameMenu();
            }
            isGameMenuActive = !isGameMenuActive;
        }
    }
    private void ActivateGameMenu()
    {
        canSelect = false;
        gameMenuOpened = true;
        uiManager.ShowGameMenuPanel();
    }

    private void HideGameMenu()
    {
        canSelect = true;
        gameMenuOpened = false;
        uiManager.HideGameMenuPanel();
    }

    private void ShowAskPanelMenu(object sender, EventArgs e)
    {
        if (gameMenuOpened)
        {
            askPanelOpened = true;
            gameMenuOpened = false;
            uiManager.ShowAskPanel();
        }
    }
    private void HideAskPanelMenu(object sender, EventArgs e)
    {
        if (askPanelOpened)
        {
            askPanelOpened = false;
            gameMenuOpened = true;
            uiManager.HideAskPanel();
        }
    }
    private void ExitToMainScene(object sender, EventArgs e)
    {
        if (askPanelOpened)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("StartScene");
        }
    }

    private void Update()
    {
        if (currentSet != null)
        {
            currentSet.SelectFirstObject();
            currentSet.SelectSecondObject();
        }
    }

    public void MakeSwitching(object sender, EventArgs e)
    {
        if (canSelect) currentSet.SwitchSelection(); 
    }

    public void MakeBackSwitching(object sender, EventArgs e)
    {
        if (canSelect) currentSet.BackSwitchSelection();
    }

    public void SelectTopDoor(object sender, EventArgs e)
    {
        if (canSelect) (currentSet as SingleSelectionSet).SwitchWithType(RoomType.TopDoor);
    }
    public void SelectRightDoor(object sender, EventArgs e)
    {
        if (canSelect) (currentSet as SingleSelectionSet).SwitchWithType(RoomType.RightDoor);
    }
    public void SelectBottomDoor(object sender, EventArgs e)
    {
        if (canSelect) (currentSet as SingleSelectionSet).SwitchWithType(RoomType.BottomDoor);
    }
    public void SelectLeftDoor(object sender, EventArgs e)
    {
        if (canSelect) (currentSet as SingleSelectionSet).SwitchWithType(RoomType.LeftDoor);
    }
    public void MakeSelectionAction(object sender, EventArgs e)
    {
        if (canSelect) (currentSet as SingleSelectionSet).MakeSelectionAction();
    }


    public void MakeFirstSelection(object sender, EventArgs e)
    {
        if (canSelect) (currentSet as DoubleSelectionSet).TryToMakeSelection();
    }
    public void CancelFirstSelection(object sender, EventArgs e)
    {
        if (canSelect) (currentSet as DoubleSelectionSet).CancelFirstSelection();
    }
}
