using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button continueButton;

    private void Start()
    {
        if (!DataPersistenceManager.Instance.HasGameData())
        {
            if (continueButton != null) continueButton.interactable = false;
        }
    }

}
