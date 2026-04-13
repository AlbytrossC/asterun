using UnityEngine;

public class GravityModifier : MonoBehaviour
{
    public float Xgrav;
    public bool Ldir = true;
    public bool doForce = false;
    public float force;
    public Vector2 currentGravity;

    private void Start()
    {
        Physics2D.gravity = currentGravity;
    }
    void OnClimbHold()
    {
        ToggleGravDir();
    }
    
    void OnClimbRelease()
    {
        Physics2D.gravity = new Vector2(0,0);
    }

    private void FixedUpdate()
    {
        currentGravity = Physics2D.gravity;

        if (doForce)
            ApplyForce(force);
    }

    void ApplyForce(float f) => GetComponent<Rigidbody2D>().AddForceX(f);


    void ToggleGravDir()
    {
        if (Physics2D.gravity.x > 0)
            Physics2D.gravity = new Vector2(-9.81f, 0);
        else Physics2D.gravity = new Vector2(9.81f, 0);
    }
}
