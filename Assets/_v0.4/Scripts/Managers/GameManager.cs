using UnityEngine;
public class GameManager : MonoBehaviour
{
    public enum GameState { Menus, MidRun }
    public enum PauseState { Unpaused, Paused }

    public GameState _GameState;
    public PauseState _PauseState;

    private void Awake()
    {
        Application.targetFrameRate = 60; //sets the target FPS
    }

    private void Update()
    {
        /*if (_PauseState == PauseState.Paused)
            SetTimelineScale(TimeLine.Default, 0);
        if (_PauseState == PauseState.Unpaused)
            SetTimelineScale(TimeLine.Default, 1);*/

        /*if (_GameState == GameState.Menus)
            Time.timeScale = 0;
        if (_GameState == GameState.MidRun) //THIS SCRIPT SHOULD NOT EXIST IN THE GAME !!! DONT LET THESE CHANGE TIME !!!
            Time.timeScale = 1;*/
    }
}
