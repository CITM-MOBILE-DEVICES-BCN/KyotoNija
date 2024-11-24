using MyNavigationSystem;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button shopButton;
    [SerializeField] private Button exitButton;

    [Header("Button Actions")]
    [SerializeField] private string inGameSceneName;
    [SerializeField] private string settingsPanelId;
    [SerializeField] private string shopSceneName;
    [SerializeField] private string exitSceneName;

    private void Start()
    {
        playButton.onClick.AddListener(() => NavigationManager.Instance.LoadSceneAsync(inGameSceneName));
        settingsButton.onClick.AddListener(() => NavigationManager.Instance.ShowPopUp(settingsPanelId));
        shopButton.onClick.AddListener(() => NavigationManager.Instance.LoadSceneAsync(shopSceneName));
        exitButton.onClick.AddListener(() => NavigationManager.Instance.LoadSceneAsync(exitSceneName));
    }
}
