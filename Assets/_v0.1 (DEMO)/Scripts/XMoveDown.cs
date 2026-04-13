using UnityEngine;

public class XMoveDown : MonoBehaviour
{
    public float spd;

    private Vector3 startPos;

    private void Awake()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        spd +=  Time.deltaTime * 0.6f;
        transform.Translate(Vector2.down * spd * Time.deltaTime, Space.Self);

        //if (transform.position.y <= -95) transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        if (transform.position.y <= -95) transform.position = startPos;
    }
}
