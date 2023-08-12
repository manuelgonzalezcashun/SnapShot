using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    public static event Action<string> PhotoCapture;
    public static event Action pauseDialogueForCamera;

    private GameObject Camera;
    private void Awake()
    {
        InkExternalFunctions.TakePicture += TakePicture;
        Camera = gameObject;
    }
    private void OnDestroy()
    {
        InkExternalFunctions.TakePicture -= TakePicture;
    }
    private void Start()
    {
        Camera.SetActive(false);
    }
    private void TakePicture(string picName)
    {
        Camera.SetActive(true);
        pauseDialogueForCamera?.Invoke();
        Camera.GetComponent<Button>().onClick.AddListener(() => PhotoCapture?.Invoke(picName));
    }

}
