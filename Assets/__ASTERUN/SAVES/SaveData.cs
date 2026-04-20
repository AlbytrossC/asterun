
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "SaveFile", menuName = "Scriptable Objects/SaveFile")]
public class SaveData : ScriptableObject
{
    [Header("User Stats")]
    [FormerlySerializedAs("maxHeightReached")] public int bestClimbHeight;
    public int totalHeightClimbed;
    public int lastClimbHeight;
    [Header("Audio Preferences")]
    public float masterVolume;
    public bool masterMute;
    public float musicVolume;
    public bool musicMute;
    public float sfxVolume;
    public bool sfxMute;
    [Header("Options Preferences")]
    public bool CameraV2;
    public bool JumpV2;
    public bool ClimbV2;
}



