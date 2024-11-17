using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpManager : MonoBehaviour
{
    private static PopUpManager instance { get; set; }
    public static PopUpManager Instance => instance;

    [SerializeField] private GameObject settingsPanelPrefab;
    [SerializeField] private GameObject pausePanelPrefab;

    private GameObject activeSettingsPanel;
    private GameObject activePausePanel;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowSettingsPanel(Transform parent = null)
    {
        if (activeSettingsPanel == null)
        {
            activeSettingsPanel = Instantiate(settingsPanelPrefab, parent);
        }
        else
        {
            Debug.LogWarning("Settings panel is already active");
        }
    }

    public void HideSettingsPanel()
    {
        if (activeSettingsPanel != null)
        {
            Destroy(activeSettingsPanel);
            activeSettingsPanel = null;
        }
        else
        {
            Debug.LogWarning("No active settings panel to hide");
        }
    }

    public void ShowPausePanel(Transform parent = null)
    {
        if (activePausePanel == null)
        {
            activePausePanel = Instantiate(pausePanelPrefab, parent);
        }
        else
        {
            Debug.LogWarning("Pause panel is already active");
        }
    }

    public void HidePausePanel()
    {
        if (activePausePanel != null)
        {
            Destroy(activePausePanel);
            activePausePanel = null;
        }
        else
        {
            Debug.LogWarning("No active pause panel to hide");
        }
    }

    public void ToggleSettingsPanel(Transform parent = null)
    {
        if (activePausePanel != null)
        {
            ShowPausePanel(parent);
        }
        else
        {
            HidePausePanel();
        }
    }


}
