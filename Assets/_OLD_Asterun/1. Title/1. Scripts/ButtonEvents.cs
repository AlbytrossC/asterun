using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour
{

    #region Public Button Events

    [Header("Main Menu")]
    public UnityEvent onStartRun;
    public UnityEvent onUpgrade;
    public UnityEvent onOptions;
    public UnityEvent onQuit;

    [Header("Upgrade Menu")]
    public float o;
    [Header("Options Menu")]
    public int oo;
    [Header("Pause Menu")]
    public UnityEvent onTitleScreen;


    public void TitleScreenPressed() => onTitleScreen.Invoke();
    public void StartRunPressed() => onStartRun.Invoke();
    public void UpgradePressed() => onUpgrade.Invoke();
    public void OptionsPressed() => onOptions.Invoke();
    public void QuitPressed() => onQuit.Invoke();

    #endregion

    public void LoadMainLevel() => SceneManager.LoadScene("Main");
    public void LoadTitleScreen() => SceneManager.LoadScene("Title");
    public void LoadScene(string name) => SceneManager.LoadScene(name);
    public void QuitGame() => Application.Quit();
    public void UIShowUpgradeMenu() => FindFirstObjectByType<UIScript>().SetActivePanel(UIScript.ActivePanel.Upgrades);
    public void UIShowMainMenu() => FindFirstObjectByType<UIScript>().SetActivePanel(UIScript.ActivePanel.MainMenu);
    public void UIShowOptionsMenu() => FindFirstObjectByType<UIScript>().SetActivePanel(UIScript.ActivePanel.Options);
    public void UIShowPauseMenu() => FindFirstObjectByType<UIScript>().SetActivePanel(UIScript.ActivePanel.Pause);
    public void UIHideAllMenus() => FindFirstObjectByType<UIScript>().SetActivePanel(UIScript.ActivePanel.None);

}