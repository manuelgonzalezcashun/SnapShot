using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject Camera;
    private bool isCameraActive = false;

    private void Awake()
    {
        Camera = gameObject;
    }

    void Start()
    {
        Camera.SetActive(isCameraActive);
    }
    public void TakePicture()
    {
        if (!isCameraActive)
        {
            isCameraActive = true;
        }
        else
        {
            isCameraActive = false;
        }

        Camera.SetActive(isCameraActive);
    }
}
