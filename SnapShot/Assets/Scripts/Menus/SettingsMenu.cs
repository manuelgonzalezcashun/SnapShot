using UnityEngine;
public class SettingsMenu : Menu
{
    private void Awake()
    {
        SingletonEventSystem.enableSettingsMenu += EnableSettingsMenu;
    }
    private void OnDestroy()
    {
        SingletonEventSystem.enableSettingsMenu -= EnableSettingsMenu;
    }
    private void EnableSettingsMenu(bool value)
    {
        gameObject.SetActive(value);
    }
}
