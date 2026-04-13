using UnityEngine;

public class SensorActions : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
            player.GetComponent<GravitySwitcher>().onTheWall = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
            player.GetComponent<GravitySwitcher>().onTheWall = false;
    }
}
