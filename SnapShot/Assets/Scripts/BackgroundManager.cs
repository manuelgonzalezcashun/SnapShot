using System;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public Background[] backgrounds;

    void Awake()
    {
        foreach (Background bg in backgrounds)
        {
            bg.backgroundImage = gameObject.AddComponent<Image>();
        }
    }
    public void SetBackground(string name)
    {
        Background bg = Array.Find(backgrounds, background => background.backgroundName == name);
        if (name == bg.backgroundName)
        {
            bg.backgroundImage = gameObject.GetComponent<Image>();
            bg.backgroundImage.sprite = bg.backgroundSprite;
        }
    }
}
