using TMPro;
using UnityEngine;

public class PopupTile : MonoBehaviour
{
    public GameObject boostCard;
    public TMP_Text buttonText;

    private void OnEnable()
    {
        if (boostCard.activeSelf)
            buttonText.text = "UPGRADE";
        else buttonText.text = "BUY";
    }
}
