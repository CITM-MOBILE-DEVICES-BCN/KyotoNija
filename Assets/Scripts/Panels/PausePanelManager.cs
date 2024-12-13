using MyNavigationSystem;
using UnityEngine;
using UnityEngine.UI;

public class PausePanelManager : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button continueButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button mainMenuButton;

    [Header("Button Actions")]
    [SerializeField] private string pausePanelId;
    [SerializeField] private string settingsPanelId;
    [SerializeField] private string menuScene;

    private void Start()
    {
        continueButton.onClick.AddListener(() => AudioManager.instance.PlayButtonSound());
        continueButton.onClick.AddListener(() => NavigationManager.Instance.HidePopUp(pausePanelId));
        settingsButton.onClick.AddListener(() => AudioManager.instance.PlayButtonSound());
        settingsButton.onClick.AddListener(() => NavigationManager.Instance.ShowPopUp(settingsPanelId));
        mainMenuButton.onClick.AddListener(() => AudioManager.instance.PlayButtonSound());
        mainMenuButton.onClick.AddListener(() => NavigationManager.Instance.HidePopUp(pausePanelId));
        mainMenuButton.onClick.AddListener(() => NavigationManager.Instance.LoadSceneAsync(menuScene)); 
    }
}