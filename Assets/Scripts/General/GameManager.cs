using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Difficulty gameDifficulty;

    private GameDataManager dataManager;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        dataManager = new GameDataManager();
    }

    private void Start()
    {
        dataManager.AddCoins(1000);
    }

    public void SetDifficulty(int height)
    {
        if (height > -1 && height < 200)
        {
            gameDifficulty = Difficulty.BABY;
        }
        else if (height > 200 && height < 500)
        {
            gameDifficulty = Difficulty.EASY;
        }
        else if (height > 500 && height < 1000)
        {
            gameDifficulty = Difficulty.MEDIUM;
        }
        else if (height > 1000 && height < 2000)
        {
            gameDifficulty = Difficulty.HARD;
        }
        else if (height > 2000 && height < 3000)
        {
            gameDifficulty = Difficulty.HARDER;
        }
        else
        {
            gameDifficulty = Difficulty.HERALD_OF_CHAOS;
        }
    }

    public int GetCoins()
    {
        return dataManager.GetCoins();
    }

    public void AddCoins(int amount)
    {
        dataManager.AddCoins(amount);
    }

    public void BuyItem(string itemName)
    {
        dataManager.BuyItem(itemName);
    }
}

public enum Difficulty
{
    BABY,
    EASY,
    MEDIUM,
    HARD,
    HARDER,
    HERALD_OF_CHAOS
}
