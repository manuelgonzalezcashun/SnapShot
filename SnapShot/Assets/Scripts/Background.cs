using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class Background 
{
    public string backgroundName;
    public Sprite backgroundSprite;

    [HideInInspector]
    public Image backgroundImage;
}
