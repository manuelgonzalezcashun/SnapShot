using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausingScript : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject Phone;
    public GameObject Controls;

    void Update()
    {

        if (Input.GetButtonDown("Fire1") && !Phone.activeInHierarchy && !Controls.activeInHierarchy)
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
        SetCursorActive();
    }
    void SetCursorActive()
    {
        if (GameObject.Find("Cursor").activeInHierarchy)
        {
            Time.timeScale = 1f;
        }
    }
}