using UnityEngine;

public class StaticHazard : MonoBehaviour
{
    public GameObject hazard;
    public int numToSpawn;

    private void OnEnable()
    {
        for (int i = 0; i < numToSpawn; i++)
        {
            var hz = Instantiate(hazard, transform);
            hz.transform.position = GetComponent<Collider2D>().ClosestPoint(new Vector2(0, Random.Range( transform.position.y-(19.2f/2) , transform.position.y + (19.2f / 2))));

        }
    }
}
