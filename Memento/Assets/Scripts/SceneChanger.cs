using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger: MonoBehaviour
{
    public void StartLoad()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(1);
        }
    }
    public void QuitGame()
    {
        if (PausingScript.gameIsPaused == true) 
        {
            SceneManager.LoadScene(0);
        }
    }
    public void LoadScene()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0 && SceneManager.GetActiveScene().buildIndex < 7)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
