using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<GameObject> items = new List<GameObject>();
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
        Destroy(obj);
        foreach (GameObject item in items)
        {
            Debug.Log(item.name);
        }
    }
}
