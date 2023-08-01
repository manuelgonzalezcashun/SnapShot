using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkTagHandler
{
    public static event Action<string> onCharExpressionChangeEvent;
    public static event Action<string> onCharNameChangeEvent;

    private const string SPEAKER_TAG = "speaker";
    private const string ICON_TAG = "icon";
    public void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be appropritely parsed: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case SPEAKER_TAG:
                    if (tagValue != null)
                    {
                        onCharNameChangeEvent?.Invoke(tagValue);
                        InkDialogueManager.instance.NameTagText.text = tagValue;
                    }
                    break;
                case ICON_TAG:
                    if (tagValue != null)
                    { 
                        InkDialogueManager.instance.characterPrefab.SetActive(true);
                        onCharExpressionChangeEvent?.Invoke(tagValue);
                    }
                    break;
                default:
                    Debug.LogWarning("Tag came in but it is currently being handled: " + tag);
                    break;
            }
        }
    }
}
