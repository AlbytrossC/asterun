using System;
using UnityEngine;
using static Boost;

public class Card : MonoBehaviour
{
    public Boost baseData;
    public Category _Category;
    public Trigger _Trigger;
    public AffectedStat _AffectedStat;
    public int _level;
    public float currentMultiplier;
    public float _levelUp;
    public Action action;

    private void OnEnable()
    {
        Setup();
    }

    private void Setup()
    {
        _Category = baseData._Category;
        _Trigger = baseData._Trigger;
        _AffectedStat = baseData._AffectedStat;
        _level = baseData._level;
        currentMultiplier = baseData.currentMultiplier;
        _levelUp = baseData._levelUp;
        action = baseData.TestFunc3;
    }
}
