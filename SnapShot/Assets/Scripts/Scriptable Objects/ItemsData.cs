using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "SnapShot/Items")]
public class ItemsData : ScriptableObject
{
    public GameObject itemPrefab;
    public Sprite itemSprite;
}
