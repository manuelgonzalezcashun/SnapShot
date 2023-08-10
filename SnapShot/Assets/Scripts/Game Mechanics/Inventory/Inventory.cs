using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public static event Action<bool> onShowInventory;

    private List<PictureData> pictures = new List<PictureData>();

    [SerializeField] private GameObject[] inventorySlots;

    private bool isInventoryShowing = false;

    private void Start()
    {
        gameObject.SetActive(isInventoryShowing);
    }


    // Adds Items into inventory
    public void AddInventory(PictureData pic)
    {
        foreach (PictureData picData in pictures)
        {
            if (pic == picData)
            {
                Debug.Log("Item already exists in inventory");
                return;
            }
        }

        pictures.Add(pic);
        ShowItems();
    }
    // Shows the Inventory UI
    private void ShowItems()
    {
        int i = 0;
        {
            foreach (PictureData pic in pictures)
            {
                if (pic != null)
                {
                    inventorySlots[i].GetComponentInChildren<Image>().sprite = pic.picSprite;
                }
                i++;
            }
        }
    }
    public void OpenInventory()
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
        onShowInventory?.Invoke(isInventoryShowing);
    }
}
