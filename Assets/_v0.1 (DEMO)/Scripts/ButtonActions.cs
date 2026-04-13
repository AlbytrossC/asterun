using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{
    public void ReloadCurrentScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    public void LoadMainLevelScene() => SceneManager.LoadScene("DEMO_Main");
}
