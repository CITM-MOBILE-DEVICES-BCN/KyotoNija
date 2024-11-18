using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Slider loadingBar;
    [SerializeField] private TextMeshProUGUI progressText;
    [SerializeField] private string nextSceneName;

    [Header("Initialization Tasks")]
    [SerializeField] private float fakeLoadDuration = 2f;

    private void Start()
    {
        StartCoroutine(LoadGame());
    }

    private IEnumerator LoadGame()
    {
        float elapsed = 0f;
        while (elapsed < fakeLoadDuration)
        {
            elapsed += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsed / fakeLoadDuration);

            UpdateProgressUI(progress * 0.5f);

            yield return null;
        }

        AsyncOperation sceneLoadOperation = SceneManager.LoadSceneAsync(nextSceneName);
        sceneLoadOperation.allowSceneActivation = false;

        while (!sceneLoadOperation.isDone)
        {
            float progress = Mathf.Clamp01(sceneLoadOperation.progress / 0.9f);
            UpdateProgressUI(0.5f + progress * 0.5f);

            if (sceneLoadOperation.progress >= 0.9f)
            {
                sceneLoadOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    private void UpdateProgressUI(float progress)
    {
        if (loadingBar != null)
        {
            loadingBar.value = progress;
        }

        if (progressText != null)
        {
            progressText.text = $"{Mathf.RoundToInt(progress * 100)}%";
        }
    }
}
