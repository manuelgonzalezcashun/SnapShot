using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    private DialogueManager _dialogueManager;
    private PausingScript pause;

    private void Start()
    {
        _dialogueManager = FindObjectOfType<DialogueManager>();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("ControlsScene");
        PausingScript.gameIsPaused = false;
        Time.timeScale = 1f;
    }
    public void ContinueButton()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      PausingScript.gameIsPaused = false;
      Time.timeScale = 1f;
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
            SceneManager.LoadScene("FlowerHangout");
        }
        else
        {
            Debug.Log("No game saved!");
        }
    }
    public void QuitGame()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

