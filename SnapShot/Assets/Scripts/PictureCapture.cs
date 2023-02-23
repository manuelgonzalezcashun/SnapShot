using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureCapture : MonoBehaviour
{
    [SerializeField] private GameObject[] pictures;
    public GameObject StoryCamera;

    public static PictureCapture instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Picture Capture instances");
        }
        instance = this;
    }

    public void TakePic()
    {
        foreach (GameObject pic in pictures)
        {
            if (pic.name == DialogueManager.instance.PictureName)
            {
                pic.SetActive(true);
            }
            if (pic.activeInHierarchy)
            {
                DialogueManager.instance.DialoguePaused = true;
            }
        }
    }

    public void LoadTrigger()
    {
        if (DialogueManager.instance.CameraCheck == true)
        {
            return;
        }
        if (Input.GetButtonDown("Fire2"))
        {   
            StoryCamera.SetActive(true);
        }
    }
}