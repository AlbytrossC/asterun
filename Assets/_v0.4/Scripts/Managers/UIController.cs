using UnityEngine;
using System.Collections.Generic;

public class UIController : MonoBehaviour
{
    [Header("Panels")]
    public GameObject bg;
    public GameObject homePanel;
    public GameObject runPanel;
    public GameObject deathPanel;
    public GameObject settingsPanel;
    public GameObject upgradesPanel;
    public GameObject boostPanel;

    public List<GameObject> layerOrder = new List<GameObject>();

    private void OnEnable()
    {
        ShowPanelExclusive("home");
    }

    public void ShowPanelExclusive(string panel)
    {
        HidePanel("all");
        ShowPanel(panel);
    }
    public void ShowPanel(string panel)
    {
        switch (panel)
        {
            case "home":
                homePanel.SetActive(true);
                bg.SetActive(false);
                layerOrder.Add(homePanel);
                Time.timeScale = 0;
                break;

            case "run":
                runPanel.SetActive(true);
                bg.SetActive(false);
                layerOrder.Add(runPanel);
                Time.timeScale = 1;
                break;

            case "death":
                deathPanel.SetActive(true);
                bg.SetActive(true);
                layerOrder.Add(deathPanel);
                Time.timeScale = 0;
                break;

            case "settings":
                settingsPanel.SetActive(true);
                bg.SetActive(true);
                layerOrder.Add(settingsPanel);
                Time.timeScale = 0;
                break;

            case "upgrades":
                upgradesPanel.SetActive(true);
                bg.SetActive(true);
                layerOrder.Add(upgradesPanel);
                Time.timeScale = 0;
                break;
            case "run/boost":
                boostPanel.SetActive(true);
                bg.SetActive(true);
                layerOrder.Add(boostPanel);
                Time.timeScale = 0;
                break;
        }
    }

    public void HidePanel(string panel)
    {
        switch (panel)
        {
            case "home":
                homePanel.SetActive(false);
                layerOrder.Remove(homePanel);
                break;

            case "run":
                runPanel.SetActive(false);
                layerOrder.Remove(runPanel);
                break;

            case "death":
                deathPanel.SetActive(false);
                layerOrder.Remove(deathPanel);
                break;

            case "settings":
                settingsPanel.SetActive(false);
                layerOrder.Remove(settingsPanel);
                break;

            case "upgrades":
                upgradesPanel.SetActive(false);
                layerOrder.Remove(upgradesPanel);
                break;

            case "run/boost":
                boostPanel.SetActive(false);
                layerOrder.Remove(boostPanel);
                break;

            case "all":
                HidePanel("home");
                HidePanel("run");
                HidePanel("death");
                HidePanel("settings");
                HidePanel("upgrades");
                HidePanel("run/boost");
                break;
        }
    }
}
