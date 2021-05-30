using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{
    [SerializeField] private SelectionManager selectionManager;
    public void OnMenuClicked()
    {
        //LeanTransition leanTrasition = GameObject.Find("LeanTransition").GetComponent<LeanTransition>();
        //leanTrasition.DefaultTiming = LeanTiming.Update;
        Time.timeScale = 0;
        selectionManager.Pause();
    }

    public void OnExitClicked()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScene");
    }

    public void OnAllMenuClosed()
    {
        Time.timeScale = 1;
        selectionManager.Unpause();
    }
}
