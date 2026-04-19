using UnityEngine;

public class RangeScript : MonoBehaviour
{
    private WallManager wallManager;
    public RunUIManager _UI;

    public float distance;

    private void OnEnable()
    {
        wallManager = FindFirstObjectByType<WallManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
            wallManager.nearbyWalls.Add(collision.gameObject);
        if (collision.gameObject.layer == 12)
            _UI.TakeDamageTemp();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
            wallManager.nearbyWalls.Remove(collision.gameObject);
    }
}
