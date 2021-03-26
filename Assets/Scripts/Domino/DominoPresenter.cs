using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoPresenter : MonoBehaviour
{
    [SerializeField] private GameObject top_1;
    [SerializeField] private GameObject top_2;
    [SerializeField] private GameObject top_3;
    [SerializeField] private GameObject top_4;
    [SerializeField] private GameObject top_5;
    [SerializeField] private GameObject top_6;
    [SerializeField] private GameObject bottom_1;
    [SerializeField] private GameObject bottom_2;
    [SerializeField] private GameObject bottom_3;
    [SerializeField] private GameObject bottom_4;
    [SerializeField] private GameObject bottom_5;
    [SerializeField] private GameObject bottom_6;
    
    public void SetTopValue(int number)
    {
        switch (number)
        {
            case 1:
                top_1.SetActive(true);
                break;
            case 2:
                top_2.SetActive(true);
                break;
            case 3:
                top_3.SetActive(true);
                break;
            case 4:
                top_4.SetActive(true);
                break;
            case 5:
                top_5.SetActive(true);
                break;
            case 6:
                top_6.SetActive(true);
                break;
        }
    }

    public void SetBottomValue(int number)
    {
        switch (number)
        {
            case 1:
                bottom_1.SetActive(true);
                break;
            case 2:
                bottom_2.SetActive(true);
                break;
            case 3:
                bottom_3.SetActive(true);
                break;
            case 4:
                bottom_4.SetActive(true);
                break;
            case 5:
                bottom_5.SetActive(true);
                break;
            case 6:
                bottom_6.SetActive(true);
                break;
        }
    }
}
