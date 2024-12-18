using System;
using System.Collections;
using System.Collections.Generic;
using TimerModule;
using UnityEngine;
public class ScoreManager
{
    private int currentScore;
    private int highScore;

    // Configurable factors for scoring
    private int coinMultiplier = 10; 
    private float timePenaltyFactor = 1f; 

    public ScoreManager()
    {
        currentScore = 0;
        highScore = 0;
    }

    public void AddScore(int points)
    {
        currentScore += points;
        GameCanvasUI.instance.UpdateScoreUI();
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    //Call this funcion when you die/finish the level
    public int CalculateLevelScore(float time, float maxTime)
    {
        int finalTimeMultiplayer = (int)(maxTime - time);
        return currentScore + finalTimeMultiplayer;
    }
}
