using UnityEngine;


[CreateAssetMenu(fileName = "New Picture", menuName = "SnapShot/Pictures")]
public class PictureData : ScriptableObject
{
    public string pictureName;
    public GameObject picturePrefab;
    public Sprite picSprite;
}
