using System;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public static event Action<float> changeMusicVolumeSettings;
    public static event Action<float> changeSoundFXVolumeSettings;

    [SerializeField] Slider volumeSlider;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("masterVolume"))
        {
            PlayerPrefs.SetFloat("masterVolume", 1);
            LoadMasterVolume();
        }
        else if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            LoadMusicVolume();
        }
        else if (!PlayerPrefs.HasKey("soundFXVolume"))
        {
            PlayerPrefs.SetFloat("soundFXVolume", 1);
            LoadSoundEffectVolume();
        }
        else
        {
            LoadMasterVolume();
            LoadMusicVolume();
            LoadSoundEffectVolume();
        }
    }
    public void ChangeMasterVolume()
    {
        AudioListener.volume = volumeSlider.value;
        SaveMasterVolume();
    }
    public void ChangeMusicVolume()
    {
        changeMusicVolumeSettings?.Invoke(volumeSlider.value);
        SaveMusicVolume();
    }
    public void ChangeSoundEffectVolume()
    {
        changeSoundFXVolumeSettings?.Invoke(volumeSlider.value);
        SaveSoundEffectVolume();
    }

    private void LoadMasterVolume()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("masterVolume");
    }
    private void SaveMasterVolume()
    {
        PlayerPrefs.SetFloat("masterVolume", volumeSlider.value);
    }

    private void LoadMusicVolume()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    private void SaveMusicVolume()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

    private void LoadSoundEffectVolume()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("soundFXVolume");
    }
    private void SaveSoundEffectVolume()
    {
        PlayerPrefs.SetFloat("soundFXVolume", volumeSlider.value);
    }

}
