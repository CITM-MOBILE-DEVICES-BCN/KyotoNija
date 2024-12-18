using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ROBOTIN.TimerModule;
using System;
using ROBOTIN.TimerSampleScene;

namespace ROBOTIN
{
    public class LevelManager : MonoBehaviour
    {

        public GameObject player;
        public TimerManager timerManager;
        public FloodController floodController;
        public int levelOnWorld;
        public float timeToCompleteLevel;
        [SerializeField] private int level = 1;

        public enum LevelState
        {
            Playing,
            LevelPassed,
            Pause,
            GameOver
        }

        public void Init(int level, Sprite skinPlayer)
        {
            levelOnWorld = level;

            // Dependiendo del nivel desbloquea unas habilidades u otras
            player.GetComponent<PlayerController>().Init(level, skinPlayer);
            floodController.Init(level);

        }

        void Start()
        {
            timeToCompleteLevel = (int)CalculateMaxTime(level);
            timerManager = new TimerManager(timeToCompleteLevel);
        }


        private void Update()
        {
            timerManager.UpdateTime();
        }

        public float CalculateMaxTime(int dificulty)
        {
            //Base num 30
            return 30 - ((dificulty / GameManager.instance.maxLevelsPerLoop) * 5);
        }


    }
}
