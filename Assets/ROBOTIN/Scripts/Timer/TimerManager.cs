using System;
using System.Collections;
using System.Collections.Generic;
using ROBOTIN.TimerModule;
using ROBOTIN.TimerSampleScene;
using UnityEngine;

namespace ROBOTIN
{
    public class TimerManager
    {
        private Timer timer;
        private IDateTimeProvider dateTimeProvider;
        private TimerService timerService;

        private bool isOnPause = false;
        public TimerManager(float duration)
        {
            dateTimeProvider = new DateTimeProvider();
            timerService = new TimerService(dateTimeProvider);

            timer = new Timer(TimeSpan.FromSeconds(0));

            timerService.StartTimer(timer, TimeSpan.FromSeconds(duration));
        }

        public void UpdateTime()
        {
            if (timer != null)
            {
                var elapsedTime = timerService.GetTimerElapsedTime(timer);

                if (elapsedTime >= timer.Duration)
                {
                    timerService.StopTimer(timer);
                }

                if (timerService.IsTimerDefrosted(timer))
                {
                    timerService.DefrostTimer(timer);
                }

                GameCanvasUI.instance.UpdateTimerView(timer, timerService);
            }
        }

        private float GetTimerRemainingTimeNormalized(Timer timer)
        {
            return (float)(timerService.GetTimerElapsedTime(timer).TotalSeconds / timer.Duration.TotalSeconds);

        }

        //Called On Level Passed
        public void ResetTimer()
        {
            timerService.ResetTimer(ref timer);
        }

        public void PauseResumeTimer()
        {
            if (!isOnPause)
            {
                Time.timeScale = 0;
                timerService.PauseTimer(timer);
                isOnPause = true;

            }
            else
            {
                Time.timeScale = 1;
                timerService.ResumeTimer(timer);
                isOnPause = false;
            }

        }

        public float GetCurrentTime()
        {
            return timerService.GetTimerElapsedTime(timer).Seconds;
        }
    }
}