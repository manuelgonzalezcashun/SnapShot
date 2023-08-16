using System;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public enum AudioType { Master, Music, SoundFX }
    public AudioType type;

    public static event Action<float> changeMusicVolumeSettings;
    public static event Action<float> changeSoundFXVolumeSettings;

    [SerializeField] Slider volumeSlider;

    public string GetAudioType()
    {
        switch (type)
        {
            case AudioType.Master:
                return "masterVolume";

            case AudioType.Music:
                return "musicVolume";

            case AudioType.SoundFX:
                return "soundFXVolume";

            default:
                return "";
        }
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey(GetAudioType()))
        {
            PlayerPrefs.SetFloat(GetAudioType(), 1);
            LoadVolume();
        }
        else
        {
            LoadVolume();
        }
    }
    public void ChangeVolume()
    {
        switch (type)
        {
            case AudioType.Master:
                AudioListener.volume = volumeSlider.value;
                break;

            case AudioType.Music:
                changeMusicVolumeSettings?.Invoke(volumeSlider.value);
                break;

            case AudioType.SoundFX:
                changeSoundFXVolumeSettings?.Invoke(volumeSlider.value);
                break;

            default:
                break;
        }
        SaveVolume();
    }

    #region Save / Load Volume values
    public void LoadVolume()
    {
        volumeSlider.value = PlayerPrefs.GetFloat(GetAudioType());
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat(GetAudioType(), volumeSlider.value);
    }
    #endregion
}
