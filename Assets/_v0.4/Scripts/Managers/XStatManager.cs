using TMPro;
using UnityEngine;

public class XStatManager : MonoBehaviour
{
    [SerializeField]
    [Header("Testing")]
    private int curCoin;

    [Header("TEMP UI")]
    public TMP_Text coinTXT;
    
    public void AddCoins(int coins)
    {
        curCoin += coins;
        coinTXT.text = curCoin.ToString();
        print("stat ran");
    }
}
