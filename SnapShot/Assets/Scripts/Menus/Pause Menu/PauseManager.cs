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
    }
    void Pause()
    {
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            onPauseEvent?.Invoke(gameIsPaused);

            if (!gameIsPaused) Pause();
            else Resume();
        }
    }

}
