using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public enum UI { HUD, END, UPGRADE };

    [Header("HUD panel")]
    public TMP_Text coinTXT;
    public TMP_Text speedTXT;
    public TMP_Text heightTXT;

    [Header("GAME OVER Panel")]
    public TMP_Text coinEndTXT;
    public TMP_Text speedEndTXT;
    public TMP_Text heightEndTXT;

    public TMP_Text coinEndBestTXT;
    public TMP_Text speedEndBestTXT;
    public TMP_Text heightEndBestTXT;

    [Header("UPGRADE Panel")]
    public int coinUpgradeBarVAL;
    public Slider coinUpgradeSlider;

    [Header("Panel GameObjects")]
    public GameObject HUD;
    public GameObject END;
    public GameObject UPG;

    public int coinVAL;
    public float speedVAL;
    public float heightVAL;
    
    private int coinBestVAL;
    private float speedBestVAL;
    private float heightBestVAL;

    private void Start()
    {
        SetActiveUI(UI.HUD);
        ResetHUD();
    }

    private void FixedUpdate()
    {
        UpdateHeight(Time.deltaTime * speedVAL * 0.6f);
        UpdateSpeed(Time.deltaTime * 0.6f);
    }

    private void ResetHUD()
    {
        UpdateCoins  (0);
        UpdateSpeed  (0);
        UpdateHeight (0);
    }

    public void SetEndUI()
    {
        coinEndTXT.text = coinTXT.text;
        speedEndTXT.text = speedTXT.text;
        heightEndTXT.text = heightTXT.text;

        if (PlayerPrefs.GetInt("coinBest") < coinVAL)
        {
            PlayerPrefs.SetInt("coinBest", coinVAL);
            coinEndBestTXT.color = Color.green;
        }else coinEndBestTXT.color = Color.wheat;
            
        if (PlayerPrefs.GetFloat("heightBest") < heightVAL)
        {
            PlayerPrefs.SetFloat("heightBest", heightVAL);
            heightEndBestTXT.color = Color.green;
        }
        else heightEndBestTXT.color = Color.wheat;
            
        if (PlayerPrefs.GetFloat("speedBest") < speedVAL)
        {
            PlayerPrefs.SetFloat("speedBest", speedVAL);
            speedEndBestTXT.color = Color.green;
        }
        else speedEndBestTXT.color = Color.wheat;
            

        coinEndBestTXT.text = PlayerPrefs.GetInt("coinBest").ToString("#,###,##0");
        speedEndBestTXT.text = PlayerPrefs.GetFloat("heightBest").ToString("#,###,##0.#") + " m/s";
        heightEndBestTXT.text = PlayerPrefs.GetFloat("heightBest").ToString("#,###,##0") + "m";
    }

    public void UpdateCoins(int val)
    {
        coinVAL += val;
        coinTXT.text = coinVAL.ToString("#,###,##0");
    }
    public void UpdateSpeed(float val)
    {
        speedVAL += val;
        speedTXT.text = speedVAL.ToString("#,###,##0.#")+" m/s";
    }
    public void UpdateHeight(float val)
    {
        heightVAL += val;
        heightTXT.text = heightVAL.ToString("#,###,##0")+"m";
    }

    public void SetActiveUI(UI ui)
    {
        HUD.SetActive(false);
        END.SetActive(false);
        UPG.SetActive(false);

        switch(ui)
        {
            case UI.HUD:
                HUD.SetActive(true); break;
            case UI.END:
                END.SetActive(true); break;
            case UI.UPGRADE:
                UPG.SetActive(true); break;
        }
    }

    public void SetUpgradeUI() => SetActiveUI(UI.UPGRADE);

    public void BuyCoinUpgrade()
    {
        coinUpgradeBarVAL += 100 / 5;
        coinUpgradeSlider.value = coinUpgradeBarVAL;
    }
}
