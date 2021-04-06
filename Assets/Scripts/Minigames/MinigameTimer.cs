using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameTimer : MonoBehaviour
{
    [SerializeField] private Slider slider;

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
        slider.value = 1;
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
                slider.value = CountSliderValue();
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
