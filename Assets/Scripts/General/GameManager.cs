using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Difficulty gameDifficulty;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); 
    }

    public void SetDifficulty(int height)
    {
        if(height > 0 && height < 200)
        {
            gameDifficulty = Difficulty.BABY;
        }
        else if(height > 200 && height < 500)
        {
            gameDifficulty = Difficulty.EASY;
        }
        else if(height > 500 && height < 1000)
        {
            gameDifficulty = Difficulty.MEDIUM;
        }
        else if(height > 1000 && height < 2000)
        {
            gameDifficulty = Difficulty.HARD;
        }
        else if(height > 2000 && height < 3000)
        {
            gameDifficulty = Difficulty.HARDER;
        }
        else
        {
            gameDifficulty = Difficulty.HERALD_OF_CHAOS;
        }
    }

}

public enum  Difficulty
{
    BABY,
    EASY,
    MEDIUM,
    HARD,
    HARDER,
    HERALD_OF_CHAOS
}
