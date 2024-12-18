using System.Collections;
using System.Collections.Generic;
using ROBOTIN.TimerModule;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ROBOTIN
{
    public class GameCanvasUI : MonoBehaviour
    {
        [SerializeField] Button pauseButton;
        [SerializeField] string pauseMenuPopUp;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI currentTime;
        [SerializeField] private TextMeshProUGUI maxTime;

        public static GameCanvasUI instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
        private void Start()
        {
            pauseButton.onClick.AddListener(OnPauseButtonClicked);
            scoreText.text = GameManager.instance.scoreManager.GetCurrentScore().ToString();
            // bestText.text = GameManager.instance.levelData.best.ToString();
        }
        public void UpdateScoreUI()
        {
            scoreText.text = GameManager.instance.scoreManager.GetCurrentScore().ToString();
        }



        public void UpdateTimerView(Timer timer, TimerService timerService)
        {
            currentTime.text = $"Duration Time: {(int)timer.Duration.TotalSeconds}";
            maxTime.text = $"Remaining Time: {(int)timerService.GetTimerElapsedTime(timer).TotalSeconds}";
        }


        private void OnPauseButtonClicked()
        {
            GameManager.instance.LoadPopUp(pauseMenuPopUp);

            //TODO: Make a system to load diferent levels but for now it will just call the current level manager to pause the game
            GameManager.instance.currentLevel.timerManager.PauseResumeTimer();

            //You can add a pause game function here and if you want the same button to resume the
            //game create a bool so it unloads the popup and resumes the game
        }
    }
}