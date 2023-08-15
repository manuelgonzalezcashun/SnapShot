using System;
using System.Globalization;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;
    #region Audio Manager
    public void Play(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
        if (s == null)
        {
            Debug.LogWarning("Sound " + s + " was not found!");
            return;
        }
    }
    public void PlayOneShot(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        s.source.PlayOneShot(s.source.clip);
        if (s == null)
        {
            Debug.LogWarning("Sound " + s + " was not found!");
            return;
        }
    }
    public void Stop(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
        if (s == null)
        {
            Debug.LogWarning("Sound " + s + " was not found!");
            return;
        }
    }
    public void Pause(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        s.source.Pause();
        if (s == null)
        {
            Debug.LogWarning("Sound " + s + " was not found!");
            return;
        }
    }

    public void ChangeVolume(float volume)
    {
        foreach (Sounds sound in sounds)
        {
            sound.source.volume = volume;
        }
    }
    #endregion
}
