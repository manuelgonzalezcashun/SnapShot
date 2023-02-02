using System.Collections;
using UnityEngine.Video;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManagement : MonoBehaviour
{
    [Header("Splash Screen")]
    [SerializeField] private VideoPlayer splashScreen;

    [Header("Loading Screen")]
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Slider loadingBar;
    [SerializeField] private TextMeshProUGUI LoadingTextPercent;

    [Header("Pausing")]
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject XboxCursor;
    public GameObject Controls;

    //Splash Screen
    void Start()
    {
        Time.timeScale = 1f;
        splashScreen.loopPointReached += FinishSplashScreen;
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") &&
        !Controls.activeInHierarchy)
        {
            if (!gameIsPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }
    public void FinishSplashScreen(VideoPlayer sp)
    {
        SceneManager.LoadScene(1);
    }

    //Loading Operation
    IEnumerator LoadAsync(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBar.value = progress;
            LoadingTextPercent.text = progress * 100 + "%";
            yield return null;
        }
    }

    //Game Management 
    public void StartGame(int index)
    {
        StartCoroutine(LoadAsync(index));
    }
    public void QuitGame()
    {
        gameIsPaused = false;
        StartCoroutine(LoadAsync(1));
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        SetCursorActive();
    }
    void SetCursorActive()
    {
        if (XboxCursor.activeInHierarchy)
        {
            Time.timeScale = 1f;
        }
    }
}
