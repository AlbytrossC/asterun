using UnityEngine;
using UnityEngine.Events;

public class Checkpoint : MonoBehaviour
{
    public enum FlagType { Minor, Major };

    [Header("Basic Info")]
    private GameObject _go;
    private bool reached = false;

    [SerializeField] private int _ID;
    private float _height;
    public FlagType _type = FlagType.Minor;
    private Sprite _sprite;

    private RunManager _RM;

    #region functions

    public void Setup(FlagType type, int id, Vector2 pos, Sprite sprite = null)
    {
        _ID = id;
        _go = gameObject;
        _go.transform.position = pos;
        _height = _go.transform.position.y;
        _type = type;
        //_sprite = sprite;
        _RM = FindFirstObjectByType<RunManager>();
        print("["+_ID+"] "+_type+" Flag setup Complete!");
    }
    public void OnReachedFlag()
    {
        if (reached)
            return;
        Debug.Log("[Checkpoint.cs] OnReachedFlag()");
        _RM.onCheckPointReached.Invoke();
        GetComponent<SpriteRenderer>().color = Color.green;
        reached = true;
        if (_type == FlagType.Major)
            OnReachedMajorFlag();
    }

    public void OnReachedMajorFlag()
    {
        Debug.Log("[Checkpoint.cs] OnReachedMajorFlag()");
        _RM.OnMajorCheckpointReached();
        //pause game
        //show card selection
        //add chosen card to hand OR upgrade lv if already in hand
        //increase other card prices
        //hide cards on exit
        // 321 resume game
    }

    #endregion functions
}
