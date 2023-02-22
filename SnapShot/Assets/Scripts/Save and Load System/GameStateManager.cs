using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private DialogueManager _dialogueManager;

    private void Start()
    {
        _dialogueManager = FindObjectOfType<DialogueManager>();
    }
    public void SaveGame()
    {
        SaveData save = CreateSaveGameObject();

        var bf = new BinaryFormatter();

        var savePath = Application.persistentDataPath + "/savedata.save";

        FileStream file = File.Create(savePath); // creates a file at the specified location
        bf.Serialize(file, save); // writes the content of SaveData object into the file
        file.Close();

        Debug.Log("Game saved");

    }
    private SaveData CreateSaveGameObject()
    {
        return new SaveData
        {
            InkStoryState = _dialogueManager.GetStoryState(),
        };
    }
    public void LoadGame()
    {
        var savePath = Application.persistentDataPath + "/savedata.save";

        if (File.Exists(savePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(savePath, FileMode.Open);
            file.Position = 0;
            SaveData save = (SaveData)bf.Deserialize(file);
            file.Close();
            DialogueManager.LoadState(save.InkStoryState);
        }
        else
        {
            Debug.Log("No game saved!");
        }
    }
}

