using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("Audio")]
    public List<AudioSource> AudioSources = new List<AudioSource>();
    public List<float> AudioValues = new List<float>();
    [Header("UI Components")]
    public GameObject masterObject;
    public GameObject musicObject;
    public GameObject sfxObject;
    [Header("Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;
    [Header("Saves")]
    public SettingsProfile profile;


    private Toggle masterVolumeToggle;
    private Slider masterVolumeSlider;
    private float masterVolumeValue;
    private float mVolVal;
    private Toggle musicVolumeToggle;
    private Slider musicVolumeSlider;
    private float musicVolumeValue;
    private Toggle sfxVolumeToggle;
    private Slider sfxVolumeSlider;
    private float sfxVolumeValue;

    private void OnEnable()
    {
        masterVolumeToggle = masterObject.GetComponentInChildren<Toggle>();
        masterVolumeSlider = masterObject.GetComponentInChildren<Slider>();
        musicVolumeToggle = musicObject.GetComponentInChildren<Toggle>();
        musicVolumeSlider = musicObject.GetComponentInChildren<Slider>();
        sfxVolumeToggle = sfxObject.GetComponentInChildren<Toggle>();
        sfxVolumeSlider = sfxObject.GetComponentInChildren<Slider>();


        

        AudioSources[0] = musicSource;
        AudioSources[1] = sfxSource;

        AudioValues[0] = masterVolumeValue;
        AudioValues[1] = musicVolumeValue;
        AudioValues[2] = sfxVolumeValue;


        PlayerPrefs.GetFloat("Master Volume", 1);
        PlayerPrefs.GetString("Master Mute", false.ToString());
        PlayerPrefs.GetFloat("Music Volume", 1);
        PlayerPrefs.GetString("Music Mute", false.ToString());
        PlayerPrefs.GetFloat("SFX Volume", 1);
        PlayerPrefs.GetString("SFX Mute", false.ToString());

        RefreshValues();
    }

    public void UpdateAudioSourceVolume()
    {
        for (int i = 0; i < AudioSources.Count; i++)
            AudioSources[i].volume = Mathf.Pow(AudioValues[i+1], 3);
        
    }

    public void RefreshValues()
    {

        RefreshMasterValues(masterVolumeToggle.isOn);


        RefreshMusicValues(musicVolumeToggle.isOn);
        RefreshSFXValues(sfxVolumeToggle.isOn);
        PlayerPrefs.SetFloat("Master Volume", AudioValues[0]                    );
        PlayerPrefs.SetString("Master Mute" , masterVolumeToggle.isOn.ToString());
        PlayerPrefs.SetFloat("Music Volume" , AudioValues[1]                    );
        PlayerPrefs.SetString("Music Mute"  , musicVolumeToggle.isOn .ToString());
        PlayerPrefs.SetFloat("SFX Volume"   , AudioValues[2]                    );
        PlayerPrefs.SetString("SFX Mute"    , sfxVolumeToggle.isOn   .ToString());
        UpdateAudioSourceVolume();
    }

    private void RefreshMusicValues(bool muted = false)
    {
        if (muted)
            AudioValues[1] = 0;
        else
        {
            musicVolumeValue = musicVolumeSlider.value * AudioValues[0];
            AudioValues[1] = musicVolumeValue;
        }
    }
    private void RefreshSFXValues(bool muted = false)
    {
        if (muted)
            AudioValues[2] = 0;
        else
        {
            sfxVolumeValue = sfxVolumeSlider.value * AudioValues[0];
            AudioValues[2] = sfxVolumeValue;
        }
    }
    private void RefreshMasterValues(bool muted = false)
    {
        if (muted)
            AudioValues[0] = 0;
        else
        {
            masterVolumeValue = masterVolumeSlider.value;
            AudioValues[0] = masterVolumeValue;
        }
    }
    public void SaveSettings()
    {
        profile.masterVolume = masterVolumeValue;
        profile.masterEnabled = masterVolumeToggle.isOn;

        profile.musicVolume = musicVolumeValue;
        profile.musicEnabled = musicVolumeToggle.isOn;

        profile.sfxVolume = sfxVolumeValue;
        profile.sfxEnabled = sfxVolumeToggle.isOn;
    }
}
