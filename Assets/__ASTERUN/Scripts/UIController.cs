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
    public GameObject pausePanel;
    public GameObject PressToStart;

    public List<string> panels = new List<string>();

    public List<GameObject> layerOrder = new List<GameObject>();

    private void OnEnable()
    {
        ShowPanelExclusive("home");
        panels.Add("home");
        panels.Add("run");
        panels.Add("run/boost");
        panels.Add("death");
        panels.Add("settings");
        panels.Add("upgrades");
        panels.Add("pause");
        panels.Add("PressToStart");
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
                PressToStart.SetActive(true);
                bg.SetActive(false);
                layerOrder.Add(homePanel);
                Time.timeScale = 0;
                break;

            case "run":
                runPanel.SetActive(true);
                PressToStart.SetActive(false);
                bg.SetActive(false);
                layerOrder.Add(runPanel);
                Time.timeScale = 1;
                break;

            case "death":
                deathPanel.SetActive(true);
                PressToStart.SetActive(false);
                bg.SetActive(true);
                layerOrder.Add(deathPanel);
                Time.timeScale = 0;
                break;

            case "settings":
                settingsPanel.SetActive(true);
                PressToStart.SetActive(false);
                bg.SetActive(true);
                layerOrder.Add(settingsPanel);
                Time.timeScale = 0;
                break;

            case "upgrades":
                upgradesPanel.SetActive(true);
                PressToStart.SetActive(false);
                bg.SetActive(true);
                layerOrder.Add(upgradesPanel);
                Time.timeScale = 0;
                break;
            case "run/boost":
                boostPanel.SetActive(true);
                PressToStart.SetActive(false);
                bg.SetActive(true);
                layerOrder.Add(boostPanel);
                Time.timeScale = 0;
                break;
            case "pause":
                pausePanel.SetActive(true);
                PressToStart.SetActive(false);
                bg.SetActive(true);
                layerOrder.Add(pausePanel);
                Time.timeScale = 0;
                break;

            default:
                //restart game and dump error
                break;
        }
    }

    public void HidePanel(string panel)
    {
        switch (panel)
        {
            case "home":
                homePanel.SetActive(false);
                PressToStart.SetActive(false);
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

            case "PressToStart":
                PressToStart.SetActive(false);
                break;

            case "all":
                PressToStart.SetActive(false);
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
