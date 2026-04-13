using TMPro;
using UnityEngine;

public class HomeUIManager : MonoBehaviour
{
    private UIController _UI;
    public SaveDataManager _SDM;
    public SaveData _SaveData;

    public TMP_Text maxHeight;
    //public TMP_Text totalHeight;
    public TMP_Text lastClimbHeight;


    public void OnEnable()
    {
        _UI = FindFirstObjectByType<UIController>();
        _SaveData = _SDM.GetSaveData();

        maxHeight.text = _SaveData.bestClimbHeight.ToString("###,###,###,##0" + "m");
        //totalHeight.text = _SaveData.totalHeightClimbed.ToString("###,###,###,##0" + "m");
        lastClimbHeight.text = _SaveData.lastClimbHeight.ToString("###,###,###,##0" + "m");
    }

    public void OnSettingsPressed()
    {

    }
    public void OnUpgradesPressed()
    {

    }
    public void OnRunStart()
    {
        _UI.ShowPanelExclusive("run");
    }
}
