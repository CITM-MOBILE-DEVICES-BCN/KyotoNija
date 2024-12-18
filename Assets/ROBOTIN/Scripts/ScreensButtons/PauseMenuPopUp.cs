using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ROBOTIN
{
    public class PauseMenuPopUp : MonoBehaviour
    {
        [SerializeField] Button continueButton;
        [SerializeField] Button exitButton;
        private void Start()
        {
            continueButton.onClick.AddListener(OnPauseButtonClicked);
            exitButton.onClick.AddListener(OnExitButtonClicked);
        }

        private void OnPauseButtonClicked()
        {

            GameManager.instance.UnLoadPopUp(gameObject.name);
            GameManager.instance.currentLevel.timerManager.PauseResumeTimer();
            //You can add a resume game function here
        }

        private void OnExitButtonClicked()
        {
            Time.timeScale = 1;
            GameManager.instance.LoadScene("RobotinMeta");
            GameManager.instance.currentLevel.timerManager.ResetTimer();
        }
    }
}