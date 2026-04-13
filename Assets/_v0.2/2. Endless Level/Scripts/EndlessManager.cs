using UnityEngine;

public class EndlessManager : MonoBehaviour
{
    public Vector2 levelGravity = new Vector2(0, -9.8f);
    void OnEnable()
    {
        Physics2D.gravity = levelGravity;
    }

    private void Update()
    {
        levelGravity = Physics2D.gravity;
    }
}
