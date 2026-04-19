using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RunUIManager : MonoBehaviour
{
    public TMP_Text flagsTXT;
    public TMP_Text heightTXT;
    public TMP_Text speedTXT;
    [Header("arrows")]
    public GameObject arrow;
    public float arrowDisplayTime;
    public bool timing;

    [Header("HUD")] 
    public Slider shieldSlider;

    public float chargesHeld;
    public float chargeDrainSpeed;
    public float chargeFillSpeed;

    private float localTimer = 0;
    private PlayerStatManager _psm;

    private void OnEnable()
    {
        _psm = FindFirstObjectByType<PlayerStatManager>();
        localTimer = 0;
        chargesHeld = shieldSlider.maxValue;
    }
    public void Update()
    {
        flagsTXT.text = _psm.currentRunFlagsPassed.ToString("###,###,###,##0");
        heightTXT.text = _psm.currentRunMaxHeight.ToString("###,###,###,##0"+"m");
        speedTXT.text = _psm.currentSpeed.ToString("###,###,###,##0.0");

        if (timing)
            localTimer += Time.deltaTime;
        if (localTimer > arrowDisplayTime)
            HideArrow();
        
        UpdateShield();
    }

    public void UpdateShield()
    {
        shieldSlider.value = Mathf.SmoothStep(shieldSlider.value, chargesHeld, chargeDrainSpeed * Time.deltaTime);
        chargesHeld = Mathf.SmoothStep(chargesHeld, shieldSlider.maxValue, chargeFillSpeed * Time.deltaTime);
    }
    public void ShowArrow()
    {
        arrow.SetActive(true);
        timing = true;
    }
    public void HideArrow()
    {
        arrow.SetActive(false);
        timing = false;
        localTimer = 0;
    }

    public void TakeDamageTemp()
    {
        chargesHeld--;
        if (chargesHeld < 0)
        {
            FindFirstObjectByType<PlayerScript>().onDeath.Invoke();
        }
        else
        {
            
        }
    }
}
