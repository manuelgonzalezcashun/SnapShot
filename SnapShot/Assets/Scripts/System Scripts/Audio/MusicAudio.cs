using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAudio: AudioManager
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

        VolumeControl.changeMusicVolumeSettings += ChangeVolume;
        PauseManager.onPauseEvent += PauseMenuMusic;
    }
    private void OnDestroy()
    {
        VolumeControl.changeMusicVolumeSettings -= ChangeVolume;
        PauseManager.onPauseEvent -= PauseMenuMusic;
    }

    public void PauseMenuMusic(bool isGamePaused)
    {
        if (isGamePaused)
        {
            Pause("Theme");
            Play("Pause Menu");
        }
        else
        {
            Stop("Pause Menu");
            Play("Theme");
        }
    }

    private void Start()
    {
        Play("Theme");
    }
}
