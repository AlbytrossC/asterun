using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class MainControls : MonoBehaviour
{
    public bool isHeld;
    public float pushX;
    public float pushY;
    public UnityEvent onHold;
    public UnityEvent onRelease;

    private void Update()
    {
        if (isHeld)
            Physics2D.gravity = new Vector2(0, -20);
        else Physics2D.gravity = new Vector2(0, -10);
    }

    void OnClimbHold() => onHold?.Invoke();
    void OnClimbRelease() => onRelease?.Invoke();

    public void SetHeldState(bool state) => isHeld = state;
    public void PushDown() => GetComponent<Rigidbody2D>().AddForce(new Vector2(pushX, pushY), ForceMode2D.Impulse);

}
