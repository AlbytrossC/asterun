using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card001 : MonoBehaviour
{
    public enum cardID { speedMultiplier, shieldMaxCharges, instantSpeedBonus, instantShieldRefill, instantHeightBonus, scoreMultiplier }
    public cardID myID;
    public int level = 1;
    public PlayerScript playerScript;
    [Header("Card Parts")]
    public GameObject icon;
    public GameObject iconShadowOBJ;
    public TMP_Text description;
    private GameObject card;
    //private Image cardBG;
    [Header("Colours")]
    public Color clrTXT;
    public Color clrActive;


    public void OnEnable()
    {
        iconShadowOBJ.GetComponent<Image>().sprite = icon.GetComponent<Image>().sprite;
        card = GetComponent<GameObject>();
        icon.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        //clrTXT = new Color(0, 1, 0, 1);
    }

    public void FixedUpdate()
    {
        UpdateIconBrightness();
    }
    public void CardEffect(bool trigger = false)
    {
        if (!trigger)
            return;

        playerScript.VelocityLimitUp();
        playerScript.SetClimbMult(playerScript.wallClimbMulti * 1.05f);
        ActivateCardVFX();
    }

    public void ActivateCardVFX()
    {
        icon.GetComponent<Image>().color = clrActive;
        description.color = clrTXT;
    }

    private void UpdateIconBrightness()
    {
        var diff = Time.deltaTime;
            icon.GetComponent<Image>().color = icon.GetComponent<Image>().color - new Color(0, 0, 0, diff);
            description.color = description.color + new Color(diff, 0, diff, 0);
    }
}
