using UnityEngine;

public class AX_Slider : MonoBehaviour
{
    public float speed;
    public float rate = 1;
    public Vector2 resetAtPOS;
    public Vector2 resetToPOS;


    private void Start() => resetToPOS = transform.position;
    private void FixedUpdate()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.position.y < resetAtPOS.y)
            transform.position = resetToPOS;
        speed += rate * Time.deltaTime;
    }
}
