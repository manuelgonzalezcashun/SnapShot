using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public Sounds[] sounds;
    void Awake()
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
        InkExternalFunctions.PlaySound += PlayOneShot;
    }
    private void OnDestroy()
    {
        InkExternalFunctions.PlaySound -= PlayOneShot;
    }
    void Start()
    {
        Play("Theme");
    }
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
    public void StopAudio(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
        if (s == null)
        {
            Debug.LogWarning("Sound " + s + " was not found!");
            return;
        }
    }
}
