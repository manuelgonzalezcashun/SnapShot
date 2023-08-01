using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectMenuButtons : MonoBehaviour
{
    [SerializeField] private Button firstButton;

    protected virtual void OnEnable()
    {
        StartCoroutine(SetSelectedButton(firstButton.gameObject));
    }

    public IEnumerator SetSelectedButton(GameObject firstSelectedObject)
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(firstSelectedObject);
    }

}
