using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ROBOTIN
{
    public class ShopButtons : MonoBehaviour
    {
        public Button skin1Button;
        public Image skin1;
        public Button skin2Button;
        public Image skin2;
        public Button skin3Button;
        public Image skin3;
        public Button skin4Button;
        public Image skin4;
        public Button skin5Button;
        public Image skin5;
        public Button skin6Button;
        public Image skin6;

        private void Awake()
        {
            GameManager.instance.playerData.SetPlayerSkin(skin1.sprite);
            skin1Button.onClick.AddListener(() => GameManager.instance.playerData.SetPlayerSkin(skin1.sprite));
            skin2Button.onClick.AddListener(() => GameManager.instance.playerData.SetPlayerSkin(skin2.sprite));
            skin3Button.onClick.AddListener(() => GameManager.instance.playerData.SetPlayerSkin(skin3.sprite));
            skin4Button.onClick.AddListener(() => GameManager.instance.playerData.SetPlayerSkin(skin4.sprite));
            skin5Button.onClick.AddListener(() => GameManager.instance.playerData.SetPlayerSkin(skin5.sprite));
            skin6Button.onClick.AddListener(() => GameManager.instance.playerData.SetPlayerSkin(skin6.sprite));
        }
    }
}