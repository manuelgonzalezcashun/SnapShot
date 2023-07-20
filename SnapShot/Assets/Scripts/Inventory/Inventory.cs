using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<ItemsData> items = new List<ItemsData>();
    [SerializeField] private GameObject[] inventorySlots;
    private void Start()
    {
        foreach (ItemsData item in items)
        {
            Debug.Log(item.name);
        }
    }
    public void AddInventory(ItemsData item)
    {
        items.Add(item);
        ShowItems();
    }
    private void ShowItems()
    {
        int i = 0;
        foreach (ItemsData item in items)
        {
            inventorySlots[i].GetComponentInChildren<Image>().sprite = item.itemSprite;
            i++;
        }
    }
    public void UseItem()
    {
        int i = 0;
        foreach (ItemsData item in items)
        {
            if (inventorySlots[i].GetComponentInChildren<Image>().sprite != null)
            {
                Instantiate(item.itemPrefab);
                inventorySlots[i].GetComponentInChildren<Image>().sprite = null;
            }
            i++;
        }
    }
}
