using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [SerializeField] private string fileName;
    private GameData gameData;
    private List<IDataPersistence> dataPersistences;
    private FileDataHandler fileDataHandler;
    public static DataPersistenceManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        NewGame();
        this.dataPersistences = FindAllDataPersistences();
        this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    }
    public void NewGame()
    {
        this.gameData = new GameData();
    }
    public void Save()
    {
        foreach (IDataPersistence dataPersistence in dataPersistences)
        {
            dataPersistence.SaveData(ref gameData);
        }

        fileDataHandler.Save(gameData);
    }
    public void Load() 
    {
        this.gameData = fileDataHandler.Load();

        if (this.gameData == null)
        {
            NewGame();
        }
        foreach (IDataPersistence dataPersistence in dataPersistences) 
        {
            dataPersistence.LoadData(gameData);
        }
    }
    List<IDataPersistence> FindAllDataPersistences()
    {
        IEnumerable<IDataPersistence> dataPersistences = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistences);
    }
}
