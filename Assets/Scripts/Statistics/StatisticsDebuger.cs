using UnityEngine;

public class StatisticsDebuger : MonoBehaviour
{
    [SerializeField] private bool shouldRewrite;
    [Space(10)]
    [SerializeField] private int startLife;
    [SerializeField] private int startCoins;
    [SerializeField] private int startMiracles;
    [SerializeField] private int allCoins;
    void Awake()
    {
        if (shouldRewrite)
        {
            PlayerPrefs.DeleteAll();

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

            PlayerPrefs.SetInt("shouldPlaySound", 1);
            PlayerPrefs.SetInt("shouldPlayMusic", 1);
            PlayerPrefs.SetInt("shouldMakeVibration", 1);

            Debug.Log("StatisticsDebuger: Data has been written");
        }
        else
        {
            Debug.Log("StatisticsDebuger: Nothing was changed");
        }
    }
}
