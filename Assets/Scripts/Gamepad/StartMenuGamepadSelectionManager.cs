using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuGamepadSelectionManager : MonoBehaviour
{
    [SerializeField] private List<Button> startButtons = new List<Button>();

    private Button currentSelectedButton;

    private PlatformManager platformManager;
    private GamepadController gamepadController;
    void Start()
    {
        platformManager = PlatformManager.Instance;
        if(platformManager.GetCurrentPlatform() == PlatformType.Console)
        {
            gamepadController = GetComponent<GamepadController>();
            currentSelectedButton = startButtons[0];
            startButtons[0].interactable = false;

            gamepadController.OnDpadDownPressed += SwitchSelection;
            gamepadController.OnDpadTopPressed += BackSwitchSelection;
            gamepadController.OnCrossPressed += MakeSelectionAction;
        }
    }

    public void SwitchSelection(object sender, EventArgs e)
    {
        int indexOfCurrentSelection = startButtons.IndexOf(currentSelectedButton);

        if (indexOfCurrentSelection + 1 == startButtons.Count)
        {
            currentSelectedButton.interactable = true;
            currentSelectedButton = startButtons[0];
            currentSelectedButton.interactable = false;
        }
        else
        {
            currentSelectedButton.interactable = true;
            currentSelectedButton = startButtons[indexOfCurrentSelection + 1];
            currentSelectedButton.interactable = false;
        }
    }
    public void BackSwitchSelection(object sender, EventArgs e)
    {
        int indexOfCurrentSelection = startButtons.IndexOf(currentSelectedButton);

        if (indexOfCurrentSelection - 1 < 0)
        {
            currentSelectedButton.interactable = true;
            currentSelectedButton = startButtons[startButtons.Count - 1];
            currentSelectedButton.interactable = false;
        }
        else
        {
            currentSelectedButton.interactable = true;
            currentSelectedButton = startButtons[indexOfCurrentSelection - 1];
            currentSelectedButton.interactable = false;
        }
    }

    public void MakeSelectionAction(object sender, EventArgs e)
    {
        currentSelectedButton.onClick.Invoke();
    }
}
