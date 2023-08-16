using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public Inventory inventory;
    public GameData()
    {
       inventory = new Inventory();
    }
}
