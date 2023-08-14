using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public List<SavePictureData> savedPictures;
    public GameData()
    {
        savedPictures = new List<SavePictureData>();
    }
}
