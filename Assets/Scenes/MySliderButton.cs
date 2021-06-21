using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MySliderButton : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void HigherValue()
    {
        if(slider.value != 0)
        {
            slider.value = slider.value + 1;
        }
    }

    public void LowerValue()
    {
        if (slider.value != -40)
        {
            slider.value = slider.value - 1;
        }
    }
}

