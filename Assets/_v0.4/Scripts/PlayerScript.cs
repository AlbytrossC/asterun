using UnityEngine;
using UnityEngine.Events;

public class PlayerScript : MonoBehaviour
{
    [Header("LIVE STAT READOUTS")]
    public Vector2 curVelocity;
    public Vector2 maxVelocity;
    public float curSpeed;
    public float maxSpeed;
    [Header("Velocity Limit")]
    public Vector2 velLimit;
    public float deathSpeed;
    [Header("Everything Else")]
    public GameObject deathPanel;
    public Collider2D nearestWallColliderToPlayer;
    public Collider2D RangeFinder;
    public Vector2 closestPointOnWall;
    public float wallPullMulti = 1;
    public float wallClimbMulti = 1;
    public float wallClimbForce;
    public bool onWall = false;
    public float minClimbRange = 0.1f;
    public float distanceToClosestPoint;
    public bool touchIsHeld = false;
    public float jumpForce = 1;
    public GameObject facingWall;
    public UnityEvent onDeath;

    private Rigidbody2D _rb;
    private WallManager _wallManager;

    #region Fun
    public void Fun()
    {
        float hue = Mathf.Repeat(Time.time * 0.2f, 1f);
        Color color = Color.HSVToRGB(hue, 1, 1);
        GetComponentInChildren<SpriteRenderer>().color = color;
    }
    #endregion Fun
    private void OnEnable()
    {
        _rb = GetComponent<Rigidbody2D>();
        _wallManager = FindFirstObjectByType<WallManager>();
        touchIsHeld = false;
    }

    private void FixedUpdate()
    {
        if (_wallManager.GetNearestWallToPlayer() == null)
            return;
        if (_wallManager.GetNearestWallToPlayer().GetComponent<Collider2D>() != null)
            nearestWallColliderToPlayer = _wallManager.GetNearestWallToPlayer().GetComponent<Collider2D>();
        //wallClimbMulti += 0.1f * Time.deltaTime;


        if (nearestWallColliderToPlayer != null)
        {
            closestPointOnWall = nearestWallColliderToPlayer.ClosestPoint(transform.position);
            distanceToClosestPoint = Vector2.Distance(closestPointOnWall, transform.position);
        }
            
        if (closestPointOnWall == Vector2.zero)
            return;

        // strong gravity when not climbing
        if (!touchIsHeld)
            _rb.gravityScale = 2;
        else _rb.gravityScale = 1;

        PullTowardsWall();
        ClimbUpWall();
        RotateToFaceWall();
        StatReadouts();
        Fun();
        VelocityManagement();
        PlayerDeath();
    }
    private void StatReadouts()
    {
        curVelocity = _rb.linearVelocity;
        if (curVelocity.x > maxVelocity.x)
            maxVelocity.x = curVelocity.x;
        if (curVelocity.y > maxVelocity.y)
            maxVelocity.y = curVelocity.y;
    }

    private void PlayerDeath()
    {
        if (_rb.linearVelocityY < deathSpeed)
        {
            onDeath.Invoke();
        }
    }
    private void VelocityManagement()
    {
        if (_rb.linearVelocityY > velLimit.y)
            _rb.linearVelocityY = velLimit.y;
    }

    public void VelocityLimitUp() => velLimit.y *= 1.1f; //default = 1.05f
    
    private void PullTowardsWall()
    {
        float dist = Vector2.Distance(closestPointOnWall, transform.position);
        //timeline.AddToTotalTime(GetTime(TimeLine.Default));
        if (onWall)
        {
            _rb.AddForceY( ( (closestPointOnWall.y - transform.position.y) * wallPullMulti) /* * GetTime(TimeLine.Game, true)*/ );
            _rb.AddForceX( ( ( closestPointOnWall.x - transform.position.x ) * ( wallPullMulti * Mathf.InverseLerp(0.5f, 0.25f, dist) ) ) /* * GetTime(TimeLine.Game, true)*/ );
        }
    }

    private void ClimbUpWall()
    {
        if (onWall)
            if (touchIsHeld)
                _rb.AddForce(facingWall.transform.up * wallClimbForce * wallClimbMulti);
    }

    private void RotateToFaceWall()
    {
        //rotate Z to look at wallpos

        if (nearestWallColliderToPlayer == null)
            return;

        facingWall.transform.LookAt(closestPointOnWall);
        /*float targetAngle;

        if (wallCollider.CompareTag("WALL Left"))
        {
            targetAngle = Mathf.Atan2(wallPos.y - transform.position.y, (wallPos.x*-1) - transform.position.x);
        }else targetAngle = Mathf.Atan2(wallPos.y - transform.position.y, wallPos.x - transform.position.x);

        facingWall.transform.rotation = Quaternion.AngleAxis(targetAngle * Mathf.Rad2Deg, Vector3.forward);*/
    }

    public void OnJump()
    {
        touchIsHeld = !touchIsHeld;

        if (!touchIsHeld && onWall) //if the player lets go while on the wall
        {
            nearestWallColliderToPlayer = null;
            onWall = false;
            _rb.AddForce(((Vector2)transform.position - closestPointOnWall) * jumpForce, ForceMode2D.Impulse);
            closestPointOnWall = Vector2.zero;

        }
            
    }

    ////////////////////////////////////////////////////////
    
    //public void AddClimbMult(float mult) => wallClimbMulti += mult;
    public void SetClimbMult(float mult) => wallClimbMulti = mult;
}
