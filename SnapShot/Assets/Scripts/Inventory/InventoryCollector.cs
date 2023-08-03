using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryCollector : MonoBehaviour
{
    public UnityEvent<ItemsData> onItemCollected;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            onItemCollected?.Invoke(collision.gameObject.GetComponent<Item>().itemData);
            Destroy(collision.gameObject);
        }
    }
}
