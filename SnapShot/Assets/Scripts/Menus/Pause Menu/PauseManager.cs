using System;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static event Action<bool> onPauseEvent;
    private bool gameIsPaused = false;

    public void Resume()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        onPauseEvent?.Invoke(gameIsPaused);
    }
    void Pause()
    {
        Time.timeScale = 0f;
        gameIsPaused = true;
        onPauseEvent?.Invoke(gameIsPaused);
    }
    private void Update()
    {
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

}
