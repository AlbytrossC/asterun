using UnityEngine;

public class TempPath : MonoBehaviour
{
    public float speed;
    public int reset = -10;
    public float rate = 1;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.position.y < reset)
            transform.position = Vector2.zero;

        speed += rate * Time.deltaTime;
    }
}
