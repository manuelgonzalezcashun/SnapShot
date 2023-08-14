using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataPersistenceManager : MonoBehaviour
{
    [SerializeField] private string fileName;
    [SerializeField] private bool InitializeDataIfNull = false;

    private GameData gameData;
    private List<IDataPersistence> dataPersistences;
    private FileDataHandler fileDataHandler;
    public static DataPersistenceManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }

        fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        dataPersistences = FindAllDataPersistences();
        Load();
    }
    public void NewGame()
    {
        gameData = new GameData();
        Save();
    }
    public void Save()
    {
        if (gameData == null)
        {
            Debug.LogWarning("No data was found. A New Game needs to be started before data can be saved.");
            return;
        }
        foreach (IDataPersistence dataPersistence in dataPersistences)
        {
            dataPersistence.SaveData(gameData);
        }

        fileDataHandler.Save(gameData);
    }
    public void Load() 
    {
        gameData = fileDataHandler.Load();

        // Only for Testing Purposes!!!
        if (this.gameData == null && InitializeDataIfNull)
        {
            NewGame();
        }

        if (gameData == null)
        {
            Debug.LogWarning("No data was found. A New Game needs to be started before data can be loaded.");
            return;
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

    private void OnApplicationQuit()
    {
        Save();
    }

    public bool HasGameData()
    {
        return gameData != null;
    }
}
