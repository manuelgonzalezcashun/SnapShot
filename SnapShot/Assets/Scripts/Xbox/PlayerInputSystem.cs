using System;
using UnityEngine;

public class PlayerInputSystem : MonoBehaviour
{
    public static event Action openInventoryEvent;
    public static event Action continueDialogueEvent;

    private void Update()
    {
        OpenInventoryInput();
        OnDialogueInput();
    }
    public void OpenInventoryInput()
    {
        if (Input.GetKeyDown(KeyCode.I))
        { 
            openInventoryEvent?.Invoke();
        }
    }
    public void OnDialogueInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            continueDialogueEvent?.Invoke();
        }
    }
}
