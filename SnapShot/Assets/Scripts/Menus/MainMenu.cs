using UnityEngine;
using UnityEngine.UI;

public class MainMenu : Menu
{
    [SerializeField] private Button continueButton;

    private void Awake()
    {
        SingletonEventSystem.enableMainMenu += EnableMainMenu;
    }

    private void OnDestroy()
    {
        SingletonEventSystem.enableMainMenu -= EnableMainMenu;
    }

    private void Start()
    {
        if (!DataPersistenceManager.Instance.HasGameData())
        {
            if (continueButton != null) continueButton.interactable = false;
        }
    }
    private void EnableMainMenu(bool value)
    {
        gameObject.SetActive(value);
    }
}
