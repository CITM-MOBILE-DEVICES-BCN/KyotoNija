using ROBOTIN.TimerModule;
using TMPro;
using UnityEngine;

namespace ROBOTIN
{
    namespace TimerSampleScene
    {
        public class TimerViewValues : MonoBehaviour
        {
            [SerializeField]
            private TextMeshProUGUI currentTime;
            [SerializeField]
            private TextMeshProUGUI maxTime;


            public void UpdateTimerView(Timer timer, TimerService timerService)
            {
                currentTime.text = $"Duration Time: {timer.Duration}";
                maxTime.text = $"Remaining Time: {timerService.GetTimerElapsedTime(timer)}";
            }
        }
    }
}
