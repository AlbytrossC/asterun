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
    private void OnAddShieldClicked() => AddMaxShieldCharge();
    private void OnRemoveShieldClicked() => RemoveMaxShieldCharge();
    private void OnChargeShieldClicked() => ChargeShields();
    private void OnTakeDamageClicked() => TakeDamageTemp();

    //public Slider shieldSlider;

    //public float chargesHeld;
    public int maxShieldCharges;
    public int currentShieldCharge;
    public bool shieldIsActive;
    public GameObject shieldChargePrefab;
    public Transform shieldChargeParent;
    public List<GameObject> shieldPrefabs = new List<GameObject>();
    //public float chargeDrainSpeed;
    //public float chargeFillSpeed;

    private float localTimer = 0;
    private PlayerStatManager _psm;

    private void OnEnable()
    {
        _psm = FindFirstObjectByType<PlayerStatManager>();
        localTimer = 0;
        maxShieldCharges = shieldPrefabs.Count;
        currentShieldCharge = 0;
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

    public void TakeDamageTemp()
    {
        if (!shieldIsActive)
            Debug.Log("Kill Player! "+currentShieldCharge+"/"+shieldPrefabs.Count+" shield!"); //FindFirstObjectByType<PlayerScript>().onDeath.Invoke();
        else
            ReduceShields();

        if (currentShieldCharge < shieldPrefabs.Count)
            shieldIsActive=false;
    }
    private void SetShields()
    {
        for (int i = 0; i < shieldPrefabs.Count-1; i++)
        {
            if (i <= currentShieldCharge)
                shieldPrefabs[i].GetComponent<shieldPrefab>().SetFull();
            else shieldPrefabs[i].GetComponent<shieldPrefab>().SetEmpty();
        }
            

    }

    private void ChargeShields()
    {
        currentShieldCharge++;
        SetShields();
    }
    private void ReduceShields()
    {
        currentShieldCharge--;
        SetShields();
    }

    public void AddMaxShieldCharge()
    {

        shieldPrefabs.Add(Instantiate(shieldChargePrefab, shieldChargeParent));
        maxShieldCharges++;
    }
    public void RemoveMaxShieldCharge()
    {
        Destroy(shieldPrefabs[shieldPrefabs.Count-1]);
        shieldPrefabs.RemoveAt(shieldPrefabs.Count-1);
        maxShieldCharges--;
    }
}
