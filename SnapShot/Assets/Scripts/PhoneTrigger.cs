using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneTrigger : MonoBehaviour
{
    void Awake()
    {
        DialogueManager.instance.DialoguePanel.SetActive(false);
    }

}
