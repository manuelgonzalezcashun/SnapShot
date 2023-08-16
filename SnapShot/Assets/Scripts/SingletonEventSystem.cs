using System;
using UnityEngine;

public class SingletonEventSystem : MonoBehaviour
{
    public static event Action<bool> enableMainMenu;
    public static event Action<bool> enableSettingsMenu;
    public static event Action <bool> enablePauseMenu;

    private bool isMainMenuEnabled = true;
    private bool isSettingsMenuEnabled = true;
    private bool isPauseMenuEnabled = true;


    public static SingletonEventSystem instance;
    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EnableMainMenu()
    {
        isMainMenuEnabled = !isMainMenuEnabled;
        enableMainMenu?.Invoke(isMainMenuEnabled);
    }
    public void EnableSettingsMenu() 
    {
        isSettingsMenuEnabled = !isSettingsMenuEnabled;
        enableSettingsMenu?.Invoke(isSettingsMenuEnabled);
    }
    public void EnablePauseMenu() 
    {
        isPauseMenuEnabled = !isPauseMenuEnabled;
        enablePauseMenu?.Invoke(isPauseMenuEnabled);
    }
}
