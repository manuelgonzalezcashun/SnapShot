using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger: MonoBehaviour
{
    public void LoadGame()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(3);
        }
    }
    public void QuitGame()
    {
        if (PausingScript.gameIsPaused == true) 
        {
            SceneManager.LoadScene(0);
        }
    }
}
