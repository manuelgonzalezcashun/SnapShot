using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScreen : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    private void Awake()
    {
        PauseManager.onPauseEvent += ShowPauseMenu;
    }
    private void OnDestroy()
    {
        PauseManager.onPauseEvent -= ShowPauseMenu;
    }
    private void ShowPauseMenu(bool isGamePaused)
    {
        pauseScreen.SetActive(isGamePaused);
    }
}
