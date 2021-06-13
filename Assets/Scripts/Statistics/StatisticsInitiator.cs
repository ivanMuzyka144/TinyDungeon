using UnityEngine;
public class StatisticsInitiator : MonoBehaviour
{
    [SerializeField] private int startLife;
    [SerializeField] private int startCoins;
    [SerializeField] private int startMiracles;

    [SerializeField] private int allCoins;

    void Awake()
    {
        if (PlayerPrefs.GetInt("hasItitiated") == 1)
        {
            Debug.Log("Nothing was changed");
        }
        else
        {
            PlayerPrefs.SetInt("hasItitiated", 1);
            Debug.Log("StatisticsDebuger: Cleared");

            PlayerPrefs.SetInt("startLife", startLife);
            PlayerPrefs.SetInt("startCoins", startCoins);
            PlayerPrefs.SetInt("startMiracles", startMiracles);

            PlayerPrefs.SetInt("currLife", 0);
            PlayerPrefs.SetInt("currCoins", 0);
            PlayerPrefs.SetInt("currMiracles", 0);

            PlayerPrefs.SetInt("allCoins", allCoins);

            PlayerPrefs.SetInt("currentLevel", 1);
            PlayerPrefs.SetInt("bestLevel", 0);
            PlayerPrefs.SetInt("currentRooms", 0);
            PlayerPrefs.SetInt("bestRooms", 0);
            
            PlayerPrefs.SetInt("shouldPlayMusic", 1);
            PlayerPrefs.SetInt("shouldPlaySound", 1);
            PlayerPrefs.SetFloat("musicVolume", 0);
            PlayerPrefs.SetFloat("soundVolume", 0);

            Debug.Log("StatisticInitiator was overwrited");
        }
    }


}