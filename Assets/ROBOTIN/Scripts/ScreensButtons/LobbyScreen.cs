using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ROBOTIN
{
    public class LobbyScreen : MonoBehaviour
    {
        [SerializeField] Button RobotinButton;

        private void Start()
        {
            RobotinButton.onClick.AddListener(OnRobotinButtonClicked);
        }

        private void OnRobotinButtonClicked()
        {
            GameManager.instance.LoadScene("RobotinMeta");
        }
    }
}
