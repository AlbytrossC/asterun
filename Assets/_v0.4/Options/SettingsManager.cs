using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("Audio")]
    public List<AudioSource> AudioSources = new List<AudioSource>();
    public List<float> AudioValues = new List<float>();
    public GameObject master;
    public GameObject music;
    public GameObject sfx;
    [Header("Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;


    private Toggle masterVolumeToggle;
    private Slider masterVolumeSlider;
    private float masterVolumeValue;
    private Toggle musicVolumeToggle;
    private Slider musicVolumeSlider;
    private float musicVolumeValue;
    private Toggle sfxVolumeToggle;
    private Slider sfxVolumeSlider;
    private float sfxVolumeValue;

    private void OnEnable()
    {
        masterVolumeToggle = master.GetComponentInChildren<Toggle>();
        masterVolumeSlider = master.GetComponentInChildren<Slider>();
        musicVolumeToggle = music.GetComponentInChildren<Toggle>();
        musicVolumeSlider = music.GetComponentInChildren<Slider>();
        sfxVolumeToggle = sfx.GetComponentInChildren<Toggle>();
        sfxVolumeSlider = sfx.GetComponentInChildren<Slider>();

        AudioSources.Add(musicSource);
        AudioValues.Add(musicVolumeValue);
        AudioValues.Add(sfxVolumeValue);
    }

    public void UpdateVolume()
    {
        if (masterVolumeValue <= 0.3f)
        {
            musicSource.GetComponent<AudioSource>().volume = 0;
            return;
        }
        musicSource.GetComponent<AudioSource>().volume = Mathf.Pow(masterVolumeValue, 3);
    }

    public void UpdateAudioSourceVolume()
    {
        for (int i = 0; i < AudioSources.Count; i++)
        {
            AudioSources[i].volume = Mathf.Pow(AudioValues[i], 3);
        }
        
    }

    private void Update()
    {
        masterVolumeValue = masterVolumeSlider.value;
    }
}
