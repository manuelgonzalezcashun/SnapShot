using Ink.Runtime;
using System;

public class InkExternalFunctions
{
    #region Unity/Ink Events
    public static event Action<string> changeScene;
    public static event Action<string> ChangeBackground;
    public static event Action<string> PlaySound;
    public static event Action<string> PlayMusic;

    public static event Action<string> TakePicture;
    #endregion
    public void Bind(Story story)
    {
        story.BindExternalFunction("changeBackground", (string backgroundName) => ChangeBackground?.Invoke(backgroundName));
        story.BindExternalFunction("playSound", (string soundName) => PlaySound?.Invoke(soundName));
        story.BindExternalFunction("takePics", (string picName) => TakePicture?.Invoke(picName));
        story.BindExternalFunction("changeScene", (string sceneName) => changeScene?.Invoke(sceneName));
        story.BindExternalFunction("playMusic", (string songName) => PlayMusic?.Invoke(songName));
    }
    public void Unbind(Story story)
    {
        story.UnbindExternalFunction("changeBackground");
        story.UnbindExternalFunction("playSound");
        story.UnbindExternalFunction("takePics");
        story.UnbindExternalFunction("changeScene");
        story.UnbindExternalFunction("playMusic");
    }
}
