using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameTimer : MonoBehaviour
{
    [SerializeField] private Image progressBar;

    private float startSettedTime;
    private float settedTime;
    private bool timerHasSetted;

    private MinigameManager minigameSimulator;
    public void Activate()
    {
        minigameSimulator = MinigameManager.Instance;
        
    }

    public void StartTimer(float time)
    {
        timerHasSetted = true;
        startSettedTime = time;
        settedTime = time;
        progressBar.fillAmount = 1;
    }

    public void InterruptTimer()
    {
        timerHasSetted = false;
    }

    

    private void Update()
    {
        if (timerHasSetted)
        {
            if (settedTime > 0)
            {
                settedTime -= Time.deltaTime;
                progressBar.fillAmount = CountSliderValue();
            }
            else
            {
                timerHasSetted = false;
                minigameSimulator.EndTimeMinigame();
            }
        }
    }

    private float CountSliderValue()
    {
        return settedTime/ startSettedTime;
    }


}
