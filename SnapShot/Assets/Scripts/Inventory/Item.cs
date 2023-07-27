using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemsData itemData;
    private void Start()
    { 
        gameObject.GetComponent<SpriteRenderer>().sprite = itemData.itemSprite;
    }
}
