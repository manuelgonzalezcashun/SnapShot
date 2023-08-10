using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picture : MonoBehaviour
{
    public PictureData picData;
    private void Awake()
    {
        CameraScript.PhotoCapture += FindPhoto;
        gameObject.GetComponent<SpriteRenderer>().sprite = picData.picSprite;
        gameObject.SetActive(false);
    }
    private void OnDestroy()
    {
        CameraScript.PhotoCapture -= FindPhoto;
    }

    private void FindPhoto(string photoName)
    {
        if (picData.pictureName == photoName)
        {
            gameObject.SetActive(true);
        }
    }

}
