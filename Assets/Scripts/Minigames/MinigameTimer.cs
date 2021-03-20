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

    private MinigameSimulator minigameSimulator;
    public void Activate()
    {
        minigameSimulator = MinigameSimulator.Instance;
        
    }

    public void StartTimer(float time)
    {
        timerHasSetted = true;
        startSettedTime = time;
        settedTime = time;
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
            }
            else
            {
                timerHasSetted = false;
                minigameSimulator.EndTimeMinigame();
            }
        }
    }



}
