using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Character", menuName = "SnapShot/Characters")]
public class CharacterData : ScriptableObject
{
    new public string name;
    public Sprite[] expressions;
}
