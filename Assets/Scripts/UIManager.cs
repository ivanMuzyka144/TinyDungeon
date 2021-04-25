﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject miraclePanel;
    [SerializeField] private GameObject timerPanel;

    private void Awake() => Instance = this;
  
    public void ShowMiraclePanel() => miraclePanel.SetActive(true);
    public void HideMiraclePanel() => miraclePanel.SetActive(false);
    public void ShowTimerPanel() => timerPanel.SetActive(true);
    public void HideTimerPanel() => timerPanel.SetActive(false);

    public void ShowGameOverScreen(object sender, EventArgs e)
    {
        gameOverPanel.SetActive(true);
    }
}
