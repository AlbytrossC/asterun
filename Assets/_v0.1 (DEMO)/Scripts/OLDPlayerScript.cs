using UnityEngine;
using UnityEngine.SceneManagement;

public class OLDPlayerScript : MonoBehaviour
{
    private UIManager _UI;
    private void Start()
    {
        _UI = FindFirstObjectByType<UIManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            _UI.SetActiveUI(UIManager.UI.END);
            _UI.SetEndUI();
            this.gameObject.SetActive(false);
        }
    }
}
