using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.HDROutputUtils;

namespace ROBOTIN
{
    public class LoadingScreen : MonoBehaviour
    {
        public Slider loadingSlider;

        private float progress = 0;

        private int currentStep = 0;
        private int numSteps = 6000;
        private float stepIncrement;

        private void Start()
        {
            StartCoroutine("LoadGame");
            stepIncrement = 1.0f / (float)numSteps;
        }

        private IEnumerator LoadGame()
        {

            AsyncOperation loadingOperation = SceneManager.LoadSceneAsync("Lobby");
            loadingOperation.allowSceneActivation = false;

            while (loadingOperation.isDone == false)
            {
                yield return null;

                float t = currentStep * stepIncrement;

                progress = Mathf.Lerp(progress, loadingOperation.progress + 0.1f, t);
                loadingSlider.value = progress;

                currentStep++;

                if (progress >= 0.999f)
                {


                    loadingOperation.allowSceneActivation = true;

                }

            }
        }

    }

}