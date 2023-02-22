using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [Header("Loading Screen")]
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Slider loadingBar;
    [SerializeField] private TextMeshProUGUI LoadingTextPercent;
    public static SceneSwitcher instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one MenuManager instance in the scene");
        }
        instance = this;
    }

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
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
