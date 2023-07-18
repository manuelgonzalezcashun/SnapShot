using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<GameObject> items = new List<GameObject>();
    [SerializeField] private GameObject[] inventorySlots;
    private void Start()
    {
        foreach (GameObject item in items)
        {
            Debug.Log(item.name);
        }
    }
    public void AddInventory(GameObject obj)
    {
        items.Add(obj);
        ShowItems();
        Destroy(obj);
    }
    private void ShowItems()
    {
        int i = 0;
        foreach (GameObject item in items)
        {
            inventorySlots[i].GetComponentInChildren<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
            i++;
        }
    }
    public void UseItem()
    {
        foreach (GameObject item in items)
        {
            Instantiate(item);
        }
    }
}
