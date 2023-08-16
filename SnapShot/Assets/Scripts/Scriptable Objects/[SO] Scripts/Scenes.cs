using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneTypes { Main, Settings, Game }

[CreateAssetMenu(fileName = "New Scene", menuName = "SnapShot/Scenes")]
public class Scenes : ScriptableObject
{
    public SceneTypes scene;
    public string GetSceneName()
    {
        switch (scene)
        {
            case SceneTypes.Main:
                return "Main Menu Scene";
            case SceneTypes.Settings:
                return "Settings Scene";
            case SceneTypes.Game:
                return "Tola Hangout";
            default:
                return "";
        }
    }
}


