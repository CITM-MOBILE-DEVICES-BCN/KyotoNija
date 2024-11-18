using System;
using UnityEngine;

namespace MyNavigationSystem
{
    public class NavigationManager : MonoBehaviour
    {
        public static NavigationManager Instance { get; private set; }

        [Header("References")]
        [SerializeField] private SceneManager sceneManager;
        [SerializeField] private PopUpManager popUpManager;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void LoadScene(string sceneName)
        {
            sceneManager.LoadScene(sceneName);
        }

        public void LoadSceneAsync(string sceneName, Action onComplete = null)
        {
            sceneManager.LoadSceneAsync(sceneName, onComplete);
        }

        public string GetCurrentScene()
        {
            return sceneManager.GetCurrentScene();
        }

        public void ShowPopUp(string popUpID)
        {
            popUpManager.ShowPopUp(popUpID);
        }

        public void HidePopUp(string popUpID)
        {
            popUpManager.HidePopUp(popUpID);
        }
    }
}

