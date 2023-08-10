using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class Background 
{
    public string name;
    public Sprite bgSprite;

    [HideInInspector] public SpriteRenderer bgSpriteRenderer;
}
