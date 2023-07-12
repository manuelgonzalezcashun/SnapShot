using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public Sounds[] sounds;
    void Awake()
    {
        # region Singleton stuff
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        #endregion
        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    void Start()
    {
        Play("Theme");
        SnapshotEvents.instance.relScoreChange.AddListener(() => Play("relScoreChange"));
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
