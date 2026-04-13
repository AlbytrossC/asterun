using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public List<GameObject> MainPanels = new List<GameObject>();

    public enum ActivePanel { MainMenu, Upgrades, Options, Pause, None }
    public ActivePanel _activePanel = ActivePanel.None;
    public GameObject _acPan;

    private void OnEnable()
    {
        SetActivePanel(ActivePanel.MainMenu);
    }
    public void SetActivePanel(ActivePanel panel)
    {
        if (_acPan != null)
            _acPan.SetActive(false);
        _activePanel = panel;
        
        foreach(GameObject mainPanel in MainPanels)
        {
            mainPanel.SetActive(false);
        }
        switch (panel)
        {
            case ActivePanel.None:
                _acPan = null;
                break;
            case ActivePanel.MainMenu:
                _acPan = MainPanels[0];
                break;
            case ActivePanel.Upgrades:
                _acPan = MainPanels[1];
                break;
            case ActivePanel.Options:
                _acPan = MainPanels[2];
                break;
            case ActivePanel.Pause:
                _acPan = MainPanels[3];
                break;
        }
        _acPan.SetActive(true);
    }
}
