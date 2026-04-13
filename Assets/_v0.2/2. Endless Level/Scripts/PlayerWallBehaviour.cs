using UnityEngine;

public class PlayerWallBehaviour : MonoBehaviour
{
    public float xgrav;
    public float ygrav;
    public float xforce;
    public float yforce;
    public float ejectForce;
    public SpriteRenderer sensor;
    [SerializeField]private Vector2 _curgrav;
    public bool onWall = false;
    public float climbSpeed;
    private Rigidbody2D prb;
    public Vector2 vel;

    private void OnEnable()
    {
        prb = GetComponentInParent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        vel = GetComponentInParent<Rigidbody2D>().linearVelocity;
        _curgrav = Physics2D.gravity;

        if (onWall)
        {
            //prb.linearVelocityY += climbSpeed * Time.deltaTime;
            //climbSpeed += 1 * Time.deltaTime;
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        onWall = true;

        if (collision.gameObject.layer == 6) // Left Wall
        {
            //Physics2D.gravity = new Vector2(-xgrav, ygrav);
            Physics2D.gravity = new Vector2(Physics2D.gravity.x, ygrav);
            sensor.color = Color.green;
        }
            
        if (collision.gameObject.layer == 7) // Right Wall
        {
            //Physics2D.gravity = new Vector2(xgrav, ygrav);
            Physics2D.gravity = new Vector2(Physics2D.gravity.x, ygrav);
            sensor.color = Color.blue;
        }
            
    }private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.layer == 6) // Left Wall
        {
            prb.AddForceX(-xforce);
            prb.AddForceY(yforce);
        }
            
        if (collision.gameObject.layer == 7) // Right Wall
        {
            prb.AddForceX(xforce);
            prb.AddForceY(yforce);

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onWall= false;

        if ((collision.gameObject.layer == 6) || (collision.gameObject.layer == 7))
        {
            Physics2D.gravity = new Vector2(Physics2D.gravity.x, -ygrav * 0.5f);
            sensor.color = Color.red;

            GetComponentInParent<Rigidbody2D>().AddForce(new Vector2(ejectForce,0), ForceMode2D.Impulse);
            GetComponentInParent<Rigidbody2D>().AddForceX(ejectForce * -Mathf.Sign(_curgrav.x), ForceMode2D.Impulse);
        }

            
    }
}
