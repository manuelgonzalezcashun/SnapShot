using UnityEngine;

public class SoundEffectAudio : AudioManager
{
    private void Awake()
    {
        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.mute = s.mute;
        }

        VolumeControl.changeSoundFXVolumeSettings += ChangeVolume;
        InkExternalFunctions.PlaySound += PlayOneShot;
        RelationshipMeter.scoreUp += playScoreUP;
        RelationshipMeter.scoreDown += playScoreDOWN;
    }
    private void OnDestroy()
    {
        VolumeControl.changeSoundFXVolumeSettings -= ChangeVolume;
        InkExternalFunctions.PlaySound -= PlayOneShot;
        RelationshipMeter.scoreUp -= playScoreUP;
        RelationshipMeter.scoreDown -= playScoreDOWN;
    }

    public void playScoreUP()
    {
        PlayOneShot("scoreUP");
    }
    public void playScoreDOWN()
    {
        PlayOneShot("scoreDOWN");
    }
}
