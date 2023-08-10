using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryCollector : MonoBehaviour
{
    public UnityEvent<PictureData> onPictureCollected;
    private void Awake()
    {
        DragDrop.DraggingPicture += ShowCollector;
        DragDrop.DroppedPicture += HideCollector;
        gameObject.SetActive(false);
    }
    private void OnDestroy()
    {
        DragDrop.DraggingPicture -= ShowCollector;
        DragDrop.DroppedPicture -= HideCollector;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Picture")
        {
            onPictureCollected?.Invoke(collision.gameObject.GetComponent<Picture>().picData);
            Destroy(collision.gameObject);
            gameObject.SetActive(false);
        }
    }
    private void ShowCollector()
    {
        gameObject.SetActive(true);
    }
    private void HideCollector()
    {
        gameObject.SetActive(false);
    }
}
