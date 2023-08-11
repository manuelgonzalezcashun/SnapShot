using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavePictureData
{
    public string pictureName;
    public GameObject picturePrefab;
    public Sprite pictureSprite;

    public SavePictureData(PictureData picData) 
    {
        pictureName = picData.pictureName;
        picturePrefab = picData.picturePrefab;
        pictureSprite = picData.picSprite;
    }
}
