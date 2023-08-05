using Ink.Runtime;
using System;

public class InkExternalFunctions
{
    #region Unity/Ink Events
    public static event Action<string> ChangeBackground;
    public static event Action<string> ChangeUnityScene;
    public static event Action<string> PlaySound;
    #endregion
    public void Bind(Story story)
    {
        story.BindExternalFunction("changeBackground", (string backgroundName) => ChangeBackground?.Invoke(backgroundName));
        story.BindExternalFunction("changeUnityScene", (string sceneName) => ChangeUnityScene?.Invoke(sceneName));
        story.BindExternalFunction("playSound", (string soundName) => PlaySound?.Invoke(soundName));
    }
    public void Unbind(Story story)
    {
        story.UnbindExternalFunction("changeBackground");
        story.UnbindExternalFunction("changeUnityScene");
        story.UnbindExternalFunction("playSound");
    }
}