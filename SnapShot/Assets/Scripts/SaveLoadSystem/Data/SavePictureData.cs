using UnityEngine;

[System.Serializable]
public class SavePictureData
{
    public string pictureName;
    public Sprite pictureSprite;

    public SavePictureData(PictureData picData) 
    {
        pictureName = picData.pictureName;
        pictureSprite = picData.picSprite;
    }
}
