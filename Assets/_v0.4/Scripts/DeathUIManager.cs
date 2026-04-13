using TMPro;
using UnityEngine;

public class DeathUIManager : MonoBehaviour
{
    public TMP_Text flagsTXT;
    public TMP_Text heightTXT;
    public TMP_Text cardsTXT;
    public TMP_Text xpTXT;

    private PlayerStatManager _psm;

    private void OnEnable()
    {
        _psm = FindFirstObjectByType<PlayerStatManager>();
        SetStats();
    }

    public void SetStats()
    {
        flagsTXT.text = _psm.currentRunFlagsPassed.ToString("###,###,###,##0");
        heightTXT.text = _psm.currentRunMaxHeight.ToString("###,###,###,##0" + "m");
        cardsTXT.text = _psm.currentRunGatesPassed.ToString("###,###,###,##0");
        xpTXT.text = (_psm.currentRunFlagsPassed * 1.75f).ToString("###,###,###,##0"+"xp");
    }
}
