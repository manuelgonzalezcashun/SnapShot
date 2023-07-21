using System;
using UnityEngine;

public class PlayerInputSystem : MonoBehaviour
{
    public static event Action onInventoryEvent;
    public static event Action continueDialogueEvent;

    private void Update()
    {
        OnInventoryInput();
        OnDialogueInput();
    }
    public void OnInventoryInput()
    {
        if (Input.GetKeyDown(KeyCode.I))
        { 
            onInventoryEvent?.Invoke();
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
