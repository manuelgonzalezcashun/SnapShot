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
        SingletonEventSystem.enablePauseMenu += IsPauseMenuDisabled;

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

    private void OnDestroy()
    {
        SingletonEventSystem.enablePauseMenu -= IsPauseMenuDisabled;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        onPauseEvent?.Invoke(gameIsPaused);
    }
    private void Pause()
    {
        Time.timeScale = 0f;
        gameIsPaused = true;
        onPauseEvent?.Invoke(gameIsPaused);
    }

    private void OnPauseInput(InputAction.CallbackContext ctx)
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

    private void IsPauseMenuDisabled(bool value)
    {
        playerInput.enabled = value;
    }
}
