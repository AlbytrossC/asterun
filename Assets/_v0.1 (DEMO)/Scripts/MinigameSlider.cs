using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MinigameSlider : MonoBehaviour
{
    public float sliderVAL = 0;
    public float changeRate = 1;
    public enum ActiveZone { none, Red, Orange, Yellow, Green, all }
    public ActiveZone _AZ;
    public enum LR { none, Left, Right, Middle }
    public LR _LR;

    [Header("Zones")]
    public List<GameObject> Zones;

    public Image ZoneLRed;
    public Image ZoneLOrange;
    public Image ZoneLYellow;
    public Image ZoneGreen;
    public Image ZoneRYellow;
    public Image ZoneROrange;
    public Image ZoneRRed;

    private Slider slider;
    private float change;
    private int control = 1;

    void Start()
    {
        slider = GetComponent<Slider>();
        //foreach (var zone in Zones)
        //    zone.tag = "AZ";
    }

    void FixedUpdate()
    {
        change = changeRate * Time.deltaTime * control;

        sliderVAL += change;
        slider.value = sliderVAL;

        UpdateSliderValue();
    }

    void UpdateSliderValue()
    {
        if (sliderVAL >= slider.maxValue)
            SetControl(-1);
        else if (sliderVAL <= slider.minValue)
            SetControl(1);
    }

    private void SetControl(int v) => control = v;

    public void StopSlider()
    {
        SetActiveZone();
        DimInactiveZones();
    }

    private void SetActiveZone()
    {
        if (control == 0)
            StartCoroutine(ResetSlider());
        SetControl(0);

        if ((sliderVAL >= 21.3f) && (sliderVAL <= 78.7f)) //INSIDE RED ZONE
        {
            if ((sliderVAL >= 34.8f) && (sliderVAL <= 65.2f)) //INSIDE ORANGE ZONE
            {
                if ((sliderVAL >= 43.3f) && (sliderVAL <= 56.7f)) //INSIDE YELLOW ZONE
                {
                    if ((sliderVAL >= 48.4f) && (sliderVAL <= 51.7f)) //INSIDE GREEN ZONE
                    {
                        _AZ = ActiveZone.Green;
                        _LR = LR.Middle;
                        ZoneGreen.tag = "AZ";
                    }
                    else _AZ = ActiveZone.Yellow;
                }
                else _AZ = ActiveZone.Orange;
            }
            else _AZ = ActiveZone.Red;

            if (sliderVAL > 51.71f)
                _LR = LR.Right;
            else if (sliderVAL < 48.4f)
                _LR = LR.Left;

        }
        else _AZ = ActiveZone.none;





        foreach (var zone in Zones)
            zone.tag = "DZ";

        switch (_AZ)
        {
            case ActiveZone.Red:
                ZoneRRed.tag = "AZ";
                ZoneLRed.tag = "AZ";
                break;
            case ActiveZone.Orange:
                ZoneROrange.tag = "AZ";
                ZoneLOrange.tag = "AZ";
                break;
            case ActiveZone.Yellow:
                ZoneRYellow.tag = "AZ";
                ZoneLYellow.tag = "AZ";
                break;
            case ActiveZone.Green:
                ZoneGreen.tag = "AZ";
                break;
        }

        switch (_LR)
        {
            case LR.Right:
                ZoneGreen.tag = "DZ";
                ZoneLRed.tag = "DZ";
                ZoneLOrange.tag = "DZ";
                ZoneLYellow.tag = "DZ";
                break;
            case LR.Left:
                ZoneGreen.tag = "DZ";
                ZoneRRed.tag = "DZ";
                ZoneROrange.tag = "DZ";
                ZoneRYellow.tag = "DZ";
                break;
            case LR.Middle:
                ZoneRRed.tag = "DZ";
                ZoneROrange.tag = "DZ";
                ZoneRYellow.tag = "DZ";
                ZoneLRed.tag = "DZ";
                ZoneLOrange.tag = "DZ";
                ZoneLYellow.tag = "DZ";
                break;
            case LR.none:
                ZoneRRed.tag = "DZ";
                ZoneROrange.tag = "DZ";
                ZoneRYellow.tag = "DZ";
                ZoneGreen.tag = "DZ";
                ZoneLRed.tag = "DZ";
                ZoneLOrange.tag = "DZ";
                ZoneLYellow.tag = "DZ";
                break;
        }
        
    }

    private void DimInactiveZones()
    {
        foreach (var zone in Zones)
        {
            var img = zone.gameObject.GetComponent<Image>();
            var col = img.color;

            if      (img.tag == "AZ")
                col.a = 1;
            else if (img.tag == "DZ")
                col.a = 0.3f;

            img.color = col;
        }
    }


    private IEnumerator ResetSlider()
    {
        yield return new WaitForSeconds(0.1f);
        sliderVAL = 0;
        _AZ = ActiveZone.none;
        _LR = LR.none;
        foreach (var zone in Zones)
        {
            zone.tag = "DZ";

            var col = zone.gameObject.GetComponent<Image>().color;
            col.a = 1;
            zone.gameObject.GetComponent<Image>().color = col;
        }
            
        SetControl(1);
    }
}
