using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button firstButton;
    protected void OnEnable()
    {
        SetFirstSelected();
    }

    private void SetFirstSelected()
    {
        firstButton.Select();
    }
}
