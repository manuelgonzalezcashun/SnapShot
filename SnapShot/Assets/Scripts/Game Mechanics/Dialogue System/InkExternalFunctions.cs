using Ink.Runtime;
using System;

public class InkExternalFunctions
{
    #region Unity/Ink Events
    public static event Action<string> ChangeBackground;
    public static event Action<string> ChangeUnityScene;
    public static event Action<string> PlaySound;

    public static event Action<string> TakePicture;
    #endregion
    public void Bind(Story story)
    {
        story.BindExternalFunction("changeBackground", (string backgroundName) => ChangeBackground?.Invoke(backgroundName));
        story.BindExternalFunction("changeUnityScene", (string sceneName) => ChangeUnityScene?.Invoke(sceneName));
        story.BindExternalFunction("playSound", (string soundName) => PlaySound?.Invoke(soundName));
        story.BindExternalFunction("takePics", (string picName) => TakePicture?.Invoke(picName));
    }
    public void Unbind(Story story)
    {
        story.UnbindExternalFunction("changeBackground");
        story.UnbindExternalFunction("changeUnityScene");
        story.UnbindExternalFunction("playSound");
        story.UnbindExternalFunction("takePics");
    }
}
