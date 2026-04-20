using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupTile : MonoBehaviour
{
    public GameObject boostCard;
    public TMP_Text buttonText;
    public NewCardManager _CM;

    private void OnEnable()
    {
        UpdateButtonText();
        _CM = FindFirstObjectByType<NewCardManager>();
    }

    //public void ActivateCard() => GetComponentInParent<PopupTile>().boostCard.SetActive(true);
    public void ActivateCard()
    {
        boostCard.SetActive(true);
        _CM.activeCards.Add(boostCard);
    }

    public void UpdateButtonText()
    {
        if (boostCard.activeSelf)
            buttonText.text = "UPGRADE";
        else buttonText.text = "BUY";
    }
    public string ReturnButtonText()
    {
        if (boostCard.activeSelf)
            return "UPGRADE";
        else return "BUY";
    }
}
