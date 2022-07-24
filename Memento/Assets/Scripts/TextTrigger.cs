using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    [SerializeField] private GameObject textTrigger;

    private bool viewingText;


    public void TextShow()
    {
        viewingText = true;
        textTrigger.SetActive(true);

    }
}
