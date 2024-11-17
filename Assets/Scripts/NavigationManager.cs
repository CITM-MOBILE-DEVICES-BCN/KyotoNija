using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationManager : MonoBehaviour
{
    private static NavigationManager instance { get; set; }

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

    public void LoadScene(string sceneName)
    {
        SceneManager.Instance.LoadScene(sceneName);
    }

    public void LoadSceneAsync(string sceneName)
    {
        SceneManager.Instance.LoadSceneAsync(sceneName);
    }

    public void ShowPausePanel(Transform parent = null)
    {
        PopUpManager.Instance.ShowPausePanel(parent);
    }

    public void HidePausePanel()
    {
        PopUpManager.Instance.HidePausePanel();
    }

    public void ShowSettingsPanel(Transform parent = null)
    {
        PopUpManager.Instance.ShowSettingsPanel(parent);
    }

    public void HideSettingsPanel()
    {
        PopUpManager.Instance.HideSettingsPanel();
    }
    
    public void HideAllPanels()
    {
        PopUpManager.Instance.HidePausePanel();
        PopUpManager.Instance.HideSettingsPanel();
    }

    public void NavigateToSceneAndClose(string sceneName)
    {
        HideAllPanels();
        LoadScene(sceneName);
    }

}


