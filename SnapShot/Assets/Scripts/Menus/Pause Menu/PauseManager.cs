using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction pauseAction;

    public static event Action<bool> onPauseEvent;
    private bool gameIsPaused = false;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        pauseAction = playerInput.actions["Pause"];
    }
    private void OnEnable()
    {
        pauseAction.performed += OnPauseInput;
    }
    private void OnDisable()
    {
        pauseAction.performed -= OnPauseInput;
    }

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

    void OnPauseInput(InputAction.CallbackContext ctx)
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
