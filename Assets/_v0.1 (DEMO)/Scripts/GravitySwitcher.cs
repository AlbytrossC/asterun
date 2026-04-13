using System.Drawing;
using UnityEngine;
using UnityEngine.Events;

public class GravitySwitcher : MonoBehaviour
{
    public enum GravDir { Left, Right };
    public GravDir _GD;
    [Header("Gravity [9.81]")]
    public float hGrav = 9.8f;
    public float vGrav = 9.8f;
    [Header("Temp")]
    public GameObject player;
    public Vector2 jumpForce;
    public bool inMinigame = false;
    public UnityEvent onJumpPressed;
    public bool touchIsHeld = false;
    public GameObject heightMarker;
    public GameObject wallSensor;
    public bool onTheWall = false;
    public float markerSpeed;
    private float _markerSpeed = 1;

    public Vector2 closeWall;

    private void Start()
    {
        Application.targetFrameRate = 60;

        touchIsHeld = false;
        ToggleMarkerDirection(false);
    }

    private void FixedUpdate()
    {

        closeWall = GetComponent<Collider2D>().ClosestPoint(transform.position);

        transform.position = new Vector2( transform.position.x, heightMarker.transform.position.y);

        switch (_GD)
        {
            case GravDir.Left:
                Physics2D.gravity = new Vector2(-hGrav, -vGrav);
                break;
            case GravDir.Right:
                Physics2D.gravity = new Vector2(hGrav, -vGrav);
                break;
        }

        MoveHeightMarker();
    }
    public void SetWallStatus(bool status) => onTheWall = status;

    public void OnJump()
    {
        touchIsHeld = !touchIsHeld;
        if (touchIsHeld)
            return;

        switch (_GD)
        {
            case GravDir.Left:
            _GD = GravDir.Right;
                player.gameObject.GetComponent<Rigidbody2D>().AddForce(jumpForce, ForceMode2D.Impulse);
                break;
            case GravDir.Right:
                _GD = GravDir.Left;
                player.gameObject.GetComponent<Rigidbody2D>().AddForce(-jumpForce, ForceMode2D.Impulse);
                break;
        }

    }
    public void ToggleMarkerDirection(bool dir) => _markerSpeed = dir ? markerSpeed : markerSpeed *-1.5f;

    public void MoveHeightMarker()
    {
        if (onTheWall)
        {
            if (touchIsHeld)
                ToggleMarkerDirection(true);
            else ToggleMarkerDirection(false);
        }
        //else _markerSpeed = markerSpeed * -2.5f;
        heightMarker.transform.Translate(Vector2.up * _markerSpeed * Time.deltaTime);
    }

    
}