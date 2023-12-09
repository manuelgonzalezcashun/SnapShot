using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAudio : AudioManager
{
    private string newSong;
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
        InkExternalFunctions.PlayMusic += ChooseSong;
        VolumeControl.changeMusicVolumeSettings += ChangeVolume;
        PauseManager.onPauseEvent += PauseMenuMusic;
    }

    private void ChooseSong(string songName)
    {
        newSong = songName;
        Play(songName);
        Stop("Theme");
    }

    private void OnDestroy()
    {
        InkExternalFunctions.PlayMusic -= ChooseSong;
        VolumeControl.changeMusicVolumeSettings -= ChangeVolume;
        PauseManager.onPauseEvent -= PauseMenuMusic;
    }

    public void PauseMenuMusic(bool isGamePaused)
    {
        Debug.Log(newSong);
        if (isGamePaused)
        {
            if (newSong != null)
            {
                Pause(newSong);
            }
            else
            {
                Pause("Theme");
            }

            Play("Pause Menu");
        }
        else
        {
            Stop("Pause Menu");
            if (newSong != null)
            {
                Play(newSong);
            }
            else
            {
                Play("Theme");
            }

        }
    }

    private void Start()
    {
        Play("Theme");
    }
}
