using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void OnStartClicked()
    {
        PlayerPrefs.SetInt("currentLevel",1);
        PlayerPrefs.SetInt("currentRooms", 0);
        SceneManager.LoadScene("SampleScene");
    }
    public void OnOptionsClicked()
    {

    }

    public void OnExitClicked()
    {
        Application.Quit();
    }
}
