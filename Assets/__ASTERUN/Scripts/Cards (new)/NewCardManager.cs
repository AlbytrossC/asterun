using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class NewCardManager : MonoBehaviour
{
    public List<GameObject> allCards = new List<GameObject>();
    public List<GameObject> activeCards = new List<GameObject>();

    public void TriggerCardEffects()
    {
        foreach (GameObject card in allCards)
        {
            if (activeCards.Contains(card))
                card.GetComponent<Card001>().CardEffect();
        }
            
    }

    private void Awake()
    {

        foreach (var card in FindObjectsByType<Card001>(FindObjectsSortMode.None))
            card.gameObject.SetActive(false);
        UpdateCardLists();
    }

    public void UpdateCardLists()
    {
        allCards.Clear();
        activeCards.Clear();
        foreach (var card in FindObjectsByType<Card001>(FindObjectsInactive.Include,FindObjectsSortMode.None))
        {
            allCards.Add(card.gameObject);
        }
        foreach (var card in allCards)
        {

        }
            
    }
}
