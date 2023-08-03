using System;
using UnityEngine;

public class PlayerInputSystem : MonoBehaviour
{
    public static event Action onInventoryEvent;

    private void Update()
    {
        OnInventoryInput();
    }
    public void OnInventoryInput()
    {
        if (Input.GetKeyDown(KeyCode.I))
        { 
            onInventoryEvent?.Invoke();
        }
    }
}
