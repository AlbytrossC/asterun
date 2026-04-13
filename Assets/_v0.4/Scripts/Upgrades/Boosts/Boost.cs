using UnityEngine;

[CreateAssetMenu(fileName = "Boost", menuName = "Scriptable Objects/Boost")]
public class Boost : ScriptableObject
{
    public enum Category { RunBoost, Permanent }
    public enum Trigger { None, Minor, Major }
    public enum AffectedStat { Coins, Shield, Ability, ClimbSpeed, JumpSpeed, WallGrip }



    public int ID;
    public Category _Category;
    public Trigger _Trigger;
    public AffectedStat _AffectedStat;
    public int _level = 1;
    public float currentMultiplier = 1;
    public float _levelUp = 0.2f;


    public void TriggerEffect() => FindFirstObjectByType<BoostManager>().OnTriggered(ID);

    public void LevelUp()
    {
        _level += 1;
        currentMultiplier += _levelUp;
    }

    #region Boost Functions (manually updated - find a better way)

    //private void TestFunc1() => Debug.Log("1");
    //private void TestFunc2() => Debug.Log("2");
    public void TestFunc3() => FindFirstObjectByType<PlayerScript>().SetClimbMult(FindFirstObjectByType<PlayerScript>().wallClimbMulti * 1.05f);
    //public void TestFunc4() => FindFirstObjectByType<PlayerScript>().AddClimbMult(.2f);

    #endregion

}
