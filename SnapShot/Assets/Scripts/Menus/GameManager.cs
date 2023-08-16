using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(instance);  
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #region Event Listeners
    private void OnEnable()
    {
        //InkExternalFunctions.ChangeUnityScene += LoadScene;
        SplashScene.VideoFinished += LoadNextScene;
    }
    private void OnDisable()
    {
        //InkExternalFunctions.ChangeUnityScene -= LoadScene;
        SplashScene.VideoFinished -= LoadNextScene;
    }
    #endregion

    public void NewGame(Scenes scene)
    {
        DataPersistenceManager.Instance.NewGame();
        LoadingScene.instance.StartCoroutine(LoadingScene.instance.LoadAsync(scene));
    }
    public void LoadGame(Scenes scene)
    {
        LoadingScene.instance.StartCoroutine(LoadingScene.instance.LoadAsync(scene));
    }
    public void QuitToMainMenu(Scenes scene)
    {
        DataPersistenceManager.Instance.Save();
        LoadingScene.instance.StartCoroutine(LoadingScene.instance.LoadAsync(scene));
        Time.timeScale = 1f;
    }

    public void LoadMenu(Scenes scene)
    {
        SceneManager.LoadScene(scene.GetSceneName(), LoadSceneMode.Additive);
    }
    public void UnloadMenu(Scenes scene)
    {
        SceneManager.UnloadSceneAsync(scene.GetSceneName());
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitSnapshot()
    {
        Application.Quit();
    }
}
