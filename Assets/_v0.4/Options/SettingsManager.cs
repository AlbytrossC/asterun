using System.Collections.Generic;
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

        RefreshValues();

        AudioSources.Add(musicSource);
        AudioSources.Add(sfxSource);

        AudioValues.Add(masterVolumeValue);
        AudioValues.Add(musicVolumeValue);
        AudioValues.Add(sfxVolumeValue);
        
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
}
