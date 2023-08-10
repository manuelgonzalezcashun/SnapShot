using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    public static event Action<string> PhotoCapture;

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
        Camera.GetComponent<Button>().onClick.AddListener(() => PhotoCapture?.Invoke(picName));
    }
}
