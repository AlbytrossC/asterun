
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "SaveFile", menuName = "Scriptable Objects/SaveFile")]
public class SaveData : ScriptableObject
{
    [FormerlySerializedAs("maxHeightReached")] public int bestClimbHeight;
    public int totalHeightClimbed;
    public int lastClimbHeight;
}



