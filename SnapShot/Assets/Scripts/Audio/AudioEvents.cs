using UnityEngine;

public class AudioEvents : MonoBehaviour
{
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GetComponent<AudioManager>();

        InkExternalFunctions.PlaySound += audioManager.PlayOneShot;
        PauseManager.onPauseEvent += PauseMenuMusic;
    }
    private void OnDestroy()
    {
        InkExternalFunctions.PlaySound -= audioManager.PlayOneShot;
        PauseManager.onPauseEvent -= PauseMenuMusic;
    }
    void Start()
    {
        audioManager.Play("Theme");
    }
    private void PauseMenuMusic(bool isGamePaused)
    {
        if (!isGamePaused)
        {
            audioManager.Pause("Theme");
            audioManager.Play("Pause Menu");
        }
        else
        {
            audioManager.Stop("Pause Menu");
            audioManager.Play("Theme");
        }
    }
}
