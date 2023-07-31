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
            audioManager.StopAudio("Theme");
            audioManager.Play("Pause Menu");
        }
        else
        {
            audioManager.StopAudio("Pause Menu");
            audioManager.Play("Theme");
        }
    }
}
