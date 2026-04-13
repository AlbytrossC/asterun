using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float maxDist; //max distance from wall
    public float pullForce; //force to apply when pulling player toward wall
    public float damping; //reduces bouncing, force reduction proportional to speed
    private Rigidbody2D player;
    [Header("Wall Checkers")]
    public Transform checkL;
    public Transform checkR;

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        RaycastHit2D hitL = Physics2D.Raycast(checkL.position, Vector2.left);
        RaycastHit2D hitR = Physics2D.Raycast(checkR.position, Vector2.right);

        if (hitL)
        {
            float distance = Mathf.Abs(hitL.point.x - transform.position.x);
            
            float heightError = maxDist - distance;

            float force = pullForce * heightError - player.linearVelocity.x * damping;

            player.AddForce(Vector2.left * force);
            print("[L] Dist: " + distance + ". Error: " + heightError + ". Force: " + force);
        }
        if (hitR)
        {
            float distance = Mathf.Abs(hitR.point.x - transform.position.x);

            float heightError = maxDist - distance;

            float force = pullForce * heightError - player.linearVelocity.x * damping;

            player.AddForce(Vector2.right * force);
            print("[R] Dist: " + distance + ". Error: " + heightError + ". Force: " + force);
        }
    }
}
