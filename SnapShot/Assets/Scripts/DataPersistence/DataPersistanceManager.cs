using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistanceManager : MonoBehaviour
{
    private SaveData saveData;
 public static DataPersistanceManager instance {get; private set;}

private void Awake()
{
    if (instance != null)
    {
        Debug.LogError("Found more than one DataPersistence Manager");
    }
    instance = this;
}
public void NewGame()
{
    this.saveData = new SaveData(); 
}
public void LoadGame()
{
    if (this.saveData == null)
    {
        Debug.Log("No data was found. Initializing data to defaults");
        NewGame();
    }
}
public void SaveGame()
{
    
}
}
