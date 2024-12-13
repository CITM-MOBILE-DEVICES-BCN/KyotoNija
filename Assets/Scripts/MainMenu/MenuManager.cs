using MyNavigationSystem;
using System.Collections.Generic;
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
        playButton.onClick.AddListener(() => AudioManager.instance.PlayButtonSound());
        playButton.onClick.AddListener(() => AudioManager.instance.PlayInGameMusic());
        playButton.onClick.AddListener(() => NavigationManager.Instance.LoadSceneAsync(inGameSceneName));
        settingsButton.onClick.AddListener(() => AudioManager.instance.PlayButtonSound());
        settingsButton.onClick.AddListener(() => NavigationManager.Instance.ShowPopUp(settingsPanelId));
        shopButton.onClick.AddListener(() => AudioManager.instance.PlayButtonSound());
        shopButton.onClick.AddListener(() => NavigationManager.Instance.LoadSceneAsync(shopSceneName));
        exitButton.onClick.AddListener(() => AudioManager.instance.PlayButtonSound());
        exitButton.onClick.AddListener(() => NavigationManager.Instance.LoadSceneAsync(exitSceneName));



        List<GameObject> buttons = new List<GameObject>
        {
            playButton.gameObject,
            shopButton.gameObject,
            settingsButton.gameObject,
            exitButton.gameObject
        };

        NavigationManager.Instance.StartAnim(buttons, 1);
    }
}
