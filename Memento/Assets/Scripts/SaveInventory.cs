using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveInventory : MonoBehaviour
{


    static SaveInventory saveInventory;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        saveInventory = gameObject.AddComponent<SaveInventory>();
    }
}
