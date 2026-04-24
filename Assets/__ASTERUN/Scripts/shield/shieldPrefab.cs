using UnityEngine;

public class shieldPrefab : MonoBehaviour
{
    public GameObject activeIcon;
    public bool isFull;
    private void OnEnable()
    {
        isFull = false;
    }

    public void ToggleActiveIcon()
    {
        switch (isFull)
        {
            case true:
                activeIcon.SetActive(true);
                break;
            case false:
                activeIcon.SetActive(false);
                break;
        }
    }

    public void SetFull() => activeIcon.SetActive(true);
    public void SetEmpty() => activeIcon.SetActive(false);
    public void Activate() => gameObject.SetActive(true);
    public void DeActivate() => gameObject.SetActive(false);

}
