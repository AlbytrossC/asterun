using UnityEngine;
using TMPro;

public class ShopButton : MonoBehaviour
{
    public TMP_Text costLabel;
    public float cost;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //costLabel = GetComponentInChildren<TMP_Text>();
    }

    void IncreaseCost()
    {
        cost *= 1.67f;
        costLabel.text = cost.ToString();
    }
}
