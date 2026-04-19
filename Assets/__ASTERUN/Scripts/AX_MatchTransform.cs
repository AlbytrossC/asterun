using UnityEngine;
using UnityEngine.UI;

public class AX_MatchTransform : MonoBehaviour
{
    public GameObject target;
    public bool matchX;
    public bool matchY;
    public bool matchZ;
    [Header("Bonus Feature Toggle")]
    public bool dontGoDown = false;
    public Toggle dontgodownToggle;
    private Vector3 destination;

    private void Update()
    {
        destination = target.transform.position;
        transform.position = new Vector3(GetX(matchX), GetY(matchY), GetZ(matchZ));
        DontGoDown(dontGoDown);
    }

    public void ToggleMatchX() => matchX = !matchX;
    public void SetMatchX(bool x) => matchX = x;
    public void ToggleMatchY() => matchY = !matchY;
    public void SetMatchY(bool y) => matchY = y;
    public void ToggleMatchZ() => matchZ = !matchZ;
    public void SetMatchZ(bool z) => matchZ = z;
    public void MatchAll()
    {
        matchX = true;
        matchY = true;
        matchZ = true;
    }
    public void MatchNone()
    {
        matchX = false;
        matchY = false;
        matchZ = false;
    }

    private float GetX(bool match) => match ? destination.x : transform.position.x;
    private float GetY(bool match) => match ? destination.y : transform.position.y;
    private float GetZ(bool match) => match ? destination.z : transform.position.z;

    #region extra features

    public void DontGoDown(bool enabled = false)
    {
        if (!enabled)
        {
            dontGoDown = false;
            return;
        }

        dontGoDown = true;
        if (target.transform.position.y <= transform.position.y)
            SetMatchY(false);
        else SetMatchY(true);
    }

    public void ToggleDontGoDown() => DontGoDown(dontgodownToggle.isOn);

    #endregion
}
