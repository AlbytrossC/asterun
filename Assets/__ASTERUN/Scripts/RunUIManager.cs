using System.Collections.Generic;
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
    [InspectorButton("OnAddShieldClicked")] public bool AddMax;
    [InspectorButton("OnRemoveShieldClicked")] public bool RemoveMax;
    [InspectorButton("OnChargeShieldClicked")] public bool AddCharge;
    [InspectorButton("OnTakeDamageClicked")] public bool TakeDamage;
    [InspectorButton("OnUpdateShieldUI")] public bool UpdateSHL;
    private void OnAddShieldClicked() => AddShieldCharge();
    private void OnRemoveShieldClicked() => RemoveShieldCharge();
    private void OnChargeShieldClicked() => ChargeShields();
    private void OnTakeDamageClicked() => TakeDamageTemp();
    private void OnUpdateShieldUI() => UpdateShieldUI();

    //public Slider shieldSlider;

    //public float chargesHeld;
    public int maxShieldCharges;
    public int currentShieldCharge;
    public bool shieldIsActive;
    public GameObject shieldChargePrefab;
    public Transform shieldChargeParent;
    public List<GameObject> shieldPrefabs = new List<GameObject>();

    public int activeCharges;
    public int enabledActiveCharges;
    public List<GameObject> iconList = new List<GameObject>(3);
    //public float chargeDrainSpeed;
    //public float chargeFillSpeed;

    private float localTimer = 0;
    private PlayerStatManager _psm;

    private void OnEnable()
    {
        _psm = FindFirstObjectByType<PlayerStatManager>();
        localTimer = 0;
        enabledActiveCharges = 0;
        shieldIsActive = true;
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
        
        //UpdateShield();
    }

    /*public void UpdateShield() // OLD smooth shield slider
    {
        shieldSlider.value = Mathf.SmoothStep(shieldSlider.value, chargesHeld, chargeDrainSpeed * Time.deltaTime);
        chargesHeld = Mathf.SmoothStep(chargesHeld, shieldSlider.maxValue, chargeFillSpeed * Time.deltaTime);
    }*/
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

    
    
    

    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    /// 
    public void AddShieldCharge()
    {
        if (activeCharges <= iconList.Count)
            activeCharges++;
            UpdateShieldUI();
    }
    public void RemoveShieldCharge()
    {
        iconList[iconList.Count - 1].SetActive(false);
            activeCharges--;
            UpdateShieldUI();
    }
    public void ChargeShields()
    {
        if (enabledActiveCharges >= iconList.Count)
        {
            enabledActiveCharges = iconList.Count;
        }
        else
        {
            enabledActiveCharges++;
        }



        UpdateShieldUI();
    }
    public void TakeDamageTemp()
    {
        if (!shieldIsActive)
            FindFirstObjectByType<PlayerScript>().onDeath.Invoke();
        else
            ReduceShields();
    }
    private void ReduceShields()
    {
        if (enabledActiveCharges <= 0)
        {
            enabledActiveCharges = 0;
        }
        else
        {
            enabledActiveCharges--;
        }
        UpdateShieldUI();
    }
    public void UpdateShieldUI()
    {
        for (int i = 0; i < iconList.Count; i++)
        {
            if (i + 1 <= activeCharges)
            {
                iconList[i].SetActive(true);
            }
            else
            {
                iconList[i].SetActive(false);
            }
                
            if (i + 1 <= enabledActiveCharges)
            {
                iconList[i].GetComponent<shieldPrefab>().SetFull();
            }
                
            else
            {
                iconList[i].GetComponent<shieldPrefab>().SetEmpty();
            }
                
        }

        if (enabledActiveCharges > 0)
            shieldIsActive = true;
        else shieldIsActive = false;

        /*for (int i = 0; i < activeCharges; i++)
        {
            
        }*/
    }

    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////////////
    /// </summary>
   
}
