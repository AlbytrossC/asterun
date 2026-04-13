using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class RunManager : MonoBehaviour
{
    public GameObject player;
    public Transform chkParent;
    private UIController _UI;
    

    public List<GameObject> minorCheckpoints = new List<GameObject>();
    public List<GameObject> majorCheckpoints = new List<GameObject>();
    public List<GameObject> allCheckpoints = new List<GameObject>();
    public List<GameObject> chkTemplates = new List<GameObject>();

    public float dist = 10;

    [Header("Events")]
    public UnityEvent onCheckPointReached;

    private float diff = 10;
    private Vector2 lastCheckPos;
    private Vector2 nextCheckPos;

    private int minorCheckpointsSpawned = 0;
    private bool nextCheckMajor = false;

    private void Start()
    {
        nextCheckPos = Vector2.zero;
        SpawnNextCheckpoint();
        _UI = FindFirstObjectByType<UIController>();
    }

    private void Update()
    {
        if (CheckPlayerHeight() > lastCheckPos.y)
        {
            allCheckpoints[allCheckpoints.Count - 1].GetComponent<Checkpoint>().OnReachedFlag();
        }
    }

    private float CheckPlayerHeight()
    {
        return player.transform.position.y;
    }

    /*public void SpawnCheckpoints()
    {
        for(int i = 0; i < 10; i++)
        {
            var chk = Instantiate(chkTemplates[0], chkParent);
            chk.AddComponent<Checkpoint>().Setup(Checkpoint.FlagType.Minor, i + 1, nextCheckPos);
            minorCheckpoints.Add(chk);

            
            lastCheckPos = chk.transform.position;
            nextCheckPos = new Vector2(lastCheckPos.x, lastCheckPos.y + (diff * 1.2f));
            diff = nextCheckPos.y - lastCheckPos.y;
        }
    }*/

    public void SpawnNextCheckpoint()
    {
        var chk = gameObject;
        if (!nextCheckMajor)
        {
            chk = Instantiate(chkTemplates[0], chkParent); // spawn minor point
            minorCheckpoints.Add(chk);
            minorCheckpointsSpawned++;
            chk.AddComponent<Checkpoint>().Setup(Checkpoint.FlagType.Minor, minorCheckpoints.Count, nextCheckPos);
        }else
        {
            chk = Instantiate(chkTemplates[1], chkParent); // spawn major point
            majorCheckpoints.Add(chk);
            chk.AddComponent<Checkpoint>().Setup(Checkpoint.FlagType.Major, majorCheckpoints.Count, nextCheckPos);
            nextCheckMajor = false;
            minorCheckpointsSpawned = 0;
        }
        allCheckpoints.Add(chk);
        lastCheckPos = chk.transform.position;
        nextCheckPos = new Vector2(lastCheckPos.x, lastCheckPos.y + (diff * 1.2f));
        diff = nextCheckPos.y - lastCheckPos.y;


        if (minorCheckpointsSpawned > 3)
        {
            nextCheckMajor = true;
        }
    }


    public void OnMajorCheckpointReached()
    {
        _UI.ShowPanel("run/boost");
    }

    public void OnPlayerDeath()
    {
        _UI.ShowPanel("death");
        //SetTimelineScale(TimeLine.Game, 0);
    }
}
