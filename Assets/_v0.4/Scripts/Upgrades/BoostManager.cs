using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoostManager : MonoBehaviour
{
    private XStatManager _Stats;
    private PlayerScript _Player;

    public UnityEvent onTriggered;

    public List<GameObject> boostCards = new List<GameObject>();
    public List<Boost> boosts = new List<Boost>();
    [Header("TESTING <------------")]
    public Card card;

    private void OnEnable()
    {
        _Stats = GetComponent<XStatManager>();
        _Player = GetComponent<PlayerScript>();
    }
    public void TriggerBoosts()
    {
        card.action.Invoke();
        
        
        /*foreach (Boost boost in boosts)
        {
            boost.TriggerEffect();
        }*/



        //boosts[ID].TriggerEffect();
    }

    public void OnTriggered(int ID)
    {
        switch (ID)
        {
            case 0:
                _Stats.AddCoins(1);
                Debug.Log("Coins Added!");
                break;
            case 1:
                //_Player.AddClimbMult(0.1f);
                Debug.Log("Speed Added!");
                break;
        }
    }
}
