using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemsData itemData;


    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = itemData.itemSprite;
    }
    public void DestroyItem()
    {
        Destroy(gameObject);
    }
}
