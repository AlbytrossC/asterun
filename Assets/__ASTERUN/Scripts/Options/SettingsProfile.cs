using UnityEngine;

[CreateAssetMenu(fileName = "SettingsSaveData", menuName = "Scriptable Objects/Settings Profile")]
public class SettingsProfile : ScriptableObject
{
    public bool masterEnabled;
    public float masterVolume;

    public bool musicEnabled;
    public float musicVolume;

    public bool sfxEnabled;
    public float sfxVolume;

    public bool CameraV2;
    public bool JumpV2;
    public bool ClimbV2;
}
