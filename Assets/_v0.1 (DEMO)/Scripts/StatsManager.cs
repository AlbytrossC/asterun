using UnityEngine;
using TMPro;

public class StatsManager : MonoBehaviour
{
    public float timescale;
    public UIManager _UI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _UI = FindFirstObjectByType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timescale = Time.timeScale;

        if (_UI.heightVAL > 100)
        {
            //do something cool
        }

    }
}
