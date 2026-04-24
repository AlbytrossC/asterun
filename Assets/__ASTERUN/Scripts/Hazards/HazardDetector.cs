using UnityEngine;
using static UIManager;

public class HazardDetector : MonoBehaviour
{
    public RunUIManager _UI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            _UI.TakeDamageTemp();
            Destroy(collision.gameObject.transform.parent.gameObject.transform.parent.gameObject);
        }
    }
}
