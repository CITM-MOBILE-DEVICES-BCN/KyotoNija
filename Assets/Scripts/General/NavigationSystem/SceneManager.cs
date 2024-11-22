using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyNavigationSystem
{
    public class SceneManager : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }

        public void LoadSceneAsync(string sceneName, Action onComplete = null)
        {
            StartCoroutine(LoadSceneCoroutine(sceneName, onComplete));
        }

        public string GetCurrentScene()
        {
            return UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        }

        private System.Collections.IEnumerator LoadSceneCoroutine(string sceneName, Action onComplete)
        {
            AsyncOperation operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);

            while (!operation.isDone)
            {
                yield return null;
            }

            onComplete?.Invoke();
        }
    }
}

