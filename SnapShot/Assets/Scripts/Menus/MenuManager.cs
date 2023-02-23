using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one MenuManager instance in the scene");
        }
        instance = this;
    }
    //Game Management 
    public void StartGame(string sceneName)
    {
       SceneSwitcher.instance.StartCoroutine(SceneSwitcher.instance.LoadAsync(sceneName));
    }

    public void QuitGame(string sceneName)
    {
        SceneSwitcher.instance.StartCoroutine(SceneSwitcher.instance.LoadAsync(sceneName));
        PauseMenu.gameIsPaused = false;
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
