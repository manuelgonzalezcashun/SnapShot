using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<ItemsData> items = new List<ItemsData>();

    [SerializeField] private GameObject[] inventorySlots;

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
}



/*  THIS CODE NEEDS TO BE PUT IN A DIFFERENT SCRIPT TO WORK
     private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!isInventoryShowing) 
            {
                isInventoryShowing = true;
                gameObject.SetActive(true);
            }
            else
            {
                isInventoryShowing = false;
                gameObject.SetActive(false);
            }
        }
    }
*/
