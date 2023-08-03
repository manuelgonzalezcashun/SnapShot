using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Game Management 
    public void StartGame(string sceneName)
    {
        LoadingScene.instance.StartCoroutine(LoadingScene.instance.LoadAsync(sceneName));
    }

    public void QuitGame()
    {
        LoadingScene.instance.StartCoroutine(LoadingScene.instance.LoadAsync("Main Menu"));
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMenuScenes(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }
    public void UnloadMenuScenes(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }
}
