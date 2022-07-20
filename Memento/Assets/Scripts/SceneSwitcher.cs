using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStoryScene", menuName = "Dtat/New Story Scene")]
[System.Serializable]

public class SceneSwitcher : ScriptableObject
{
    public Sprite background;
    public SceneSwitcher nextScene;

     
}
