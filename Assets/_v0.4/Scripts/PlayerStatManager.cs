using UnityEngine;

public class PlayerStatManager : MonoBehaviour
{
    private PlayerScript _ps;
    private Rigidbody2D _rb;
    public SaveData SaveData;

    public int currentRunMaxHeight { get; set; } = 0;
    public int currentRunFlagsPassed { get; set; } = 0;
    public int currentRunGatesPassed { get; set; } = 0;

    public int currentShieldCharge { get; set; } = 33;
    public int currentShieldUses { get; set; } = 1;
    public int maxShieldCharge { get; set; } = 100;
    public int maxShieldUses { get; set; } = 1;
    public int currentAbilityCharge { get; set; } = 66;
    public int currentAbilityUses { get; set; } = 1;
    public int maxAbilityCharge { get; set; } = 100;
    public int maxAbilityUses { get; set; } = 1;
    public float currentSpeed { get; set; }

    private void OnEnable()
    {
        _ps = GetComponent<PlayerScript>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        SetRunHeight();
        currentSpeed = _ps.wallClimbMulti * _ps.wallClimbForce;
    }
    private void SetRunHeight()
    {
        if (transform.position.y > currentRunMaxHeight)
            currentRunMaxHeight = (int)transform.position.y;
    }

    public void PassFlag() => currentRunFlagsPassed++;

    public void SaveStats()
    {
        if (currentRunMaxHeight > SaveData.bestClimbHeight)
            SaveData.bestClimbHeight = currentRunMaxHeight;
        SaveData.totalHeightClimbed += currentRunMaxHeight;
        SaveData.lastClimbHeight = currentRunMaxHeight;
    }
}
