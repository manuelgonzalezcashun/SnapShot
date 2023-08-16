using UnityEngine;

public class PauseMenuScreen : Menu
{
    private void Awake()
    {
        PauseManager.onPauseEvent += ShowPauseMenu;
        SingletonEventSystem.enablePauseMenu += EnablePauseMenu;
    }
    private void OnDestroy()
    {
        PauseManager.onPauseEvent -= ShowPauseMenu;
        SingletonEventSystem.enablePauseMenu -= EnablePauseMenu;
    }
    private void Start()
    {
        gameObject.SetActive(false);
    }
    private void ShowPauseMenu(bool isGamePaused)
    {
        gameObject.SetActive(isGamePaused);
    }

    private void EnablePauseMenu(bool value)
    {
        gameObject.SetActive(value);
    }
}
