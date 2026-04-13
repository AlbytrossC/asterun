using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DEMOSceneChanger : MonoBehaviour
{
    public int seconds = 10;
    public UnityEvent timerDone;

    public void OnEnable()
    {
        StartCoroutine(SceneChangeTimer(seconds));
    }

    public IEnumerator SceneChangeTimer(int sec)
    {
        yield return new WaitForSeconds(sec);
        timerDone.Invoke();
    }
}
