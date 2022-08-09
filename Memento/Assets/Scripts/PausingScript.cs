using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausingScript : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject Phone;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !Phone.activeInHierarchy)
        {
            if (gameIsPaused == true) 
            {
                Resume();
            }
            else 
            {
                Pause();
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
}
