using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkExternalFunctions
{
    public void Bind(Story story)
    {
        story.BindExternalFunction("changeBackground", (string backgroundName) => GameObject.FindObjectOfType<BackgroundManager>().SetBackground(backgroundName));
        story.BindExternalFunction("playSound", (string soundName) => GameObject.FindObjectOfType<SoundManager>().Play(soundName));
    }
    public void Unbind(Story story)
    {
        story.UnbindExternalFunction("changeBackground");
        story.UnbindExternalFunction("playSound");
    }
}
