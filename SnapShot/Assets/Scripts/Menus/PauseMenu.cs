using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [Header("Pausing")]
    public GameObject pauseMenuUI;
    public GameObject XboxCursor;
    public GameObject Controls;
    public static bool gameIsPaused = false;
    
    void Update()
    {
        if (Controls.activeInHierarchy)
        {
            return;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (!gameIsPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    void SetCursorActive()
    {
        if (XboxCursor.activeInHierarchy)
        {
            Time.timeScale = 1f;
        }
    }
}
