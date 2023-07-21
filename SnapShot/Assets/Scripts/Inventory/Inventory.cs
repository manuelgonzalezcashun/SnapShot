using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<ItemsData> items = new List<ItemsData>();

    [SerializeField] private GameObject[] inventorySlots;

    private bool isInventoryShowing = false;

    private void Start()
    {
        PlayerInputSystem.openInventoryEvent += OpenInventory;
        gameObject.SetActive(isInventoryShowing);
    }
    private void OnDestroy()
    {
        PlayerInputSystem.openInventoryEvent -= OpenInventory;
    }


    // Adds Items into inventory
    public void AddInventory(ItemsData item)
    {
        foreach (ItemsData itemData in items)
        {
            if (item == itemData)
            {
                Debug.Log("Item already exists in inventory");
                return;
            }
        }

        items.Add(item);
        ShowItems();
    }
    // Shows the Inventory UI
    private void ShowItems()
    {
        int i = 0;
        {
            foreach (ItemsData item in items)
            {
                if (item != null)
                {
                    inventorySlots[i].GetComponentInChildren<Image>().sprite = item.itemSprite;
                }
                i++;
            }
        }
    }
    private void OpenInventory()
    {
        if (!isInventoryShowing)
        {
            isInventoryShowing = true;
        }
        else
        {
            isInventoryShowing = false;
        }

        gameObject.SetActive(isInventoryShowing);
    }
}
