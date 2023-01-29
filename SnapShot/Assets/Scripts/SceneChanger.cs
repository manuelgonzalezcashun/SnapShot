using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public VideoPlayer splashScreen;
    void Start()
    {
        splashScreen.loopPointReached += FinishSplashScreen;
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(3);
    }
    public void QuitGame()
    {
        if (PausingScript.gameIsPaused == true)
        {
            SceneManager.LoadScene(0);
        }
    }
    public void FinishSplashScreen(VideoPlayer sp)
    {
        SceneManager.LoadScene(1);
    }
}
