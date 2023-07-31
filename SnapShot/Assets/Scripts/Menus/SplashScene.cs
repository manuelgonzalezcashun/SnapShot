using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SplashScene : MonoBehaviour
{
    [Header("Splash Screen")]
    [SerializeField] private VideoPlayer splashScreen;
    [SerializeField] private GameManager gameManager;
    void Start()
    {
        Time.timeScale = 1f;
        splashScreen.loopPointReached += FinishSplashScreen;
    }
    public void FinishSplashScreen(VideoPlayer sp)
    {
        gameManager.LoadNextScene();
    }
}
