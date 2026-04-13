using UnityEngine;

public class AX_MatchTransform : MonoBehaviour
{
    public GameObject target;
    public bool matchX;
    public bool matchY;
    public bool matchZ;
    private Vector3 destination;

    private void Update()
    {
        destination = target.transform.position;
        transform.position = new Vector3(GetX(matchX), GetY(matchY), GetZ(matchZ));
    }

    public void ToggleMatchX() => matchX = !matchX;
    public void ToggleMatchY() => matchY = !matchY;
    public void ToggleMatchZ() => matchZ = !matchZ;
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
}
