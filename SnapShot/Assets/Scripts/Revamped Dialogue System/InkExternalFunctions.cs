using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class InkExternalFunctions
{
    public void Bind(Story story)
    {
        story.BindExternalFunction("changeBackground", (string backgroundName) => GameObject.FindObjectOfType<BackgroundManager>().SetBackground(backgroundName));
    }
    public void Unbind(Story story)
    {
        story.UnbindExternalFunction("changeBackground");
        Debug.Log("Function Unbinded");
    }
}
