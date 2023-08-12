using UnityEngine;

public class AudioEvents: MonoBehaviour
{
    private AudioManager m_AudioManager;
    private void Awake()
    {
        m_AudioManager = GetComponent<AudioManager>();

        InkExternalFunctions.PlaySound += m_AudioManager.PlayOneShot;
        PauseManager.onPauseEvent += PauseMenuMusic;

        RelationshipMeter.scoreUp += playScoreUP;
        RelationshipMeter.scoreDown += playScoreDOWN;
    }
    private void OnDestroy()
    {
        InkExternalFunctions.PlaySound -= m_AudioManager.PlayOneShot;
        PauseManager.onPauseEvent -= PauseMenuMusic;

        RelationshipMeter.scoreUp -= playScoreUP;
        RelationshipMeter.scoreDown -= playScoreDOWN;
    }
    private void Start()
    {
        m_AudioManager.Play("Theme");
    }
    public void PauseMenuMusic(bool isGamePaused)
    {
        if (isGamePaused)
        {
            m_AudioManager.Pause("Theme");
            m_AudioManager.Play("Pause Menu");
        }
        else
        {
            m_AudioManager.Stop("Pause Menu");
            m_AudioManager.Play("Theme");
        }
    }
    public void playScoreUP()
    {
        m_AudioManager.PlayOneShot("scoreUP");
    }
    public void playScoreDOWN()
    {
        m_AudioManager.PlayOneShot("scoreDOWN");
    }
}
