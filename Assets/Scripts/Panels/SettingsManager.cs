using MyNavigationSystem;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button backButton;
    
    [Header("Button Actions")]
    [SerializeField] private string settingsPanelId;
   
    private void Start()
    {
        backButton.onClick.AddListener(() => AudioManager.instance.PlayButtonSound());
        backButton.onClick.AddListener(() => NavigationManager.Instance.HidePopUp(settingsPanelId));       
    }
}