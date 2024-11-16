using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    private static SceneManager instance { get; set; }
    public void Awake()
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
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneAsync(string sceneName, System.Action onComplete = null)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName, onComplete));
    }

    public string GetCurrentSceneName()
    {
        return UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }

    private IEnumerator LoadSceneCoroutine(string sceneName, System.Action onComplete)
    {
        AsyncOperation operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            // Aquí se puede poner una barra de carga
            yield return null;
        }

        onComplete?.Invoke();

    }
}


