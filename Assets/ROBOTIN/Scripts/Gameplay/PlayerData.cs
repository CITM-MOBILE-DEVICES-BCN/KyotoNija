using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ROBOTIN
{
    public class PlayerData
    {
        public Sprite playerSkin;
        public int currentLevel;

        public PlayerData()
        {
            playerSkin = null;
            currentLevel = 1;
        }

        public void SetPlayerSkin(Sprite skin)
        {
            playerSkin = skin;
        }
    }
}
