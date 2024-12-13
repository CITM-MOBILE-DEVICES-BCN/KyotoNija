using System;
using System.Collections.Generic;
using UnityEngine;

namespace MyNavigationSystem
{
    public class NavigationManager : MonoBehaviour
    {
        public static NavigationManager Instance { get; private set; }

        [Header("References")]
        [SerializeField] private SceneManager sceneManager;
        [SerializeField] private PopUpManager popUpManager;
        [SerializeField] private PopUpAnimManager popUpAnimManager;

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

        public void StartAnim(List<GameObject> gameObjects, int typeOfAnim)
        {
            switch(typeOfAnim)
            {
                case 1:
                    popUpAnimManager.AnimatePopUpScale(gameObjects);
                    break;
                case 2:
                    popUpAnimManager.AnimatePopUpWithRotation(gameObjects);
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }
    }
}

