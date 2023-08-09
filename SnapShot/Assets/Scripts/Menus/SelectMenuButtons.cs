using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectMenuButtons : MonoBehaviour
{
    [SerializeField] private Button firstButton;

    private void OnEnable()
    {
        StartCoroutine(SetFirstSelected(firstButton.gameObject));
    }
    private IEnumerator SetFirstSelected(GameObject firstSelected)
    {
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(firstSelected);

    }
}
