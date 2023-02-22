using System;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public Background[] backgrounds;
    private int newOrderInLayer = -5;
    private Background background;

    void Awake()
    {
        foreach (Background bg in backgrounds)
        {
            bg.bgSpriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        }
    }

    public void SetBackground(string name)
    {
        Background bg = Array.Find(backgrounds, background => background.name == name);
        if (name == bg.name)
        {
            bg.bgSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            bg.bgSpriteRenderer.sprite = bg.bgSprite;
            bg.bgSpriteRenderer.sortingOrder = newOrderInLayer;
        }
    }
}
