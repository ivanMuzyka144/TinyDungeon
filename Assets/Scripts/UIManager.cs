using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private GameObject gameOverPanel;

    private void Awake() => Instance = this;
  
    public void ShowGameOverScreen(object sender, EventArgs e)
    {
        gameOverPanel.SetActive(true);
    }
}
