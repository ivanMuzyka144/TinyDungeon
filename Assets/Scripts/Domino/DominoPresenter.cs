using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DominoPresenter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI top_text;
    [SerializeField] private TextMeshProUGUI bottom_text;
    [SerializeField] private TextMeshProUGUI whole_text;
    [Space(10)]
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
    [SerializeField] private GameObject whole_1;
    [SerializeField] private GameObject whole_2;
    [SerializeField] private GameObject whole_3;
    [SerializeField] private GameObject whole_4;
    [SerializeField] private GameObject whole_5;
    [SerializeField] private GameObject whole_6;

    public void SetTopValue(string letter)
    {
        top_text.text = letter;
    }

    public void SetBottomValue(string letter)
    {
        bottom_text.text = letter;
    }

    public void SetWholeValue(string letter)
    {
        whole_text.text = letter;
    }

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

    public void SetWholeValue(int number)
    {
        switch (number)
        {
            case 1:
                whole_1.SetActive(true);
                break;
            case 2:
                whole_2.SetActive(true);
                break;
            case 3:
                whole_3.SetActive(true);
                break;
            case 4:
                whole_4.SetActive(true);
                break;
            case 5:
                whole_5.SetActive(true);
                break;
            case 6:
                whole_6.SetActive(true);
                break;
        }
    }
}
