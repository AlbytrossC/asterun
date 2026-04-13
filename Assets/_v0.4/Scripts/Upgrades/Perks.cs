using System;
using UnityEngine;

public class Perks : MonoBehaviour
{
    public int level;
    public bool repeatTrigger; // will the effect trigger once (false) or many times (true)
    public Action action;
}
