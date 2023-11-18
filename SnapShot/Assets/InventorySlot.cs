using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public void ShowPhoto(GameObject photo)
    {
        photo.SetActive(!photo.activeSelf);
    }

}
