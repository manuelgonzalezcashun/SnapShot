using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Event Listeners
    private void OnEnable()
    {
        InkExternalFunctions.ChangeUnityScene += LoadScene;
        SplashScene.VideoFinished += LoadNextScene;
    }
    private void OnDisable()
    {
        InkExternalFunctions.ChangeUnityScene -= LoadScene;
        SplashScene.VideoFinished -= LoadNextScene;
    }
    #endregion

    //Game Management 
    public void NewGame(string sceneName)
    {
        DataPersistenceManager.Instance.NewGame();
        LoadingScene.instance.StartCoroutine(LoadingScene.instance.LoadAsync(sceneName));
    }
    public void LoadScene(string sceneName)
    {
        LoadingScene.instance.StartCoroutine(LoadingScene.instance.LoadAsync(sceneName));
    }

    public void QuitGame()
    {
        DataPersistenceManager.Instance.Save();
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
}
