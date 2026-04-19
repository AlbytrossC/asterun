using UnityEngine;

[CreateAssetMenu(fileName = "SettingsSaveData", menuName = "Scriptable Objects/Settings Profile")]
public class SettingsProfile : ScriptableObject
{
    public bool musicEnabled;
    public float musicVolume;

    public bool sfxEnabled;
    public float sfxVolume;
}
