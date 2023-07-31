using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    [Header("Loading Screen")]
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Slider loadingBar;
    [SerializeField] private TextMeshProUGUI LoadingTextPercent;

    #region Singleton
    public static LoadingScene instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError($"Found more than one {instance}!");
        }
        instance = this;
    }
    #endregion
    public IEnumerator LoadAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBar.value = progress;
            LoadingTextPercent.text = progress * 100 + "%";
            yield return null;
        }
    }
}
