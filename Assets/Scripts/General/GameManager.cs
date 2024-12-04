using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Difficulty gameDifficulty;

    public PowerUpLevel powerUpLevel;

    public PowerUpPrice powerUpPrice;

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

    public int GetLevel(PowerUpLevel powerUpLevel)
    {
        int level = 0;

        switch (powerUpLevel)
        {
            case PowerUpLevel.DASHLEVEL:
                level = dataManager.DashLevel();
                break;
            case PowerUpLevel.DASHTIMELEVEL:
                level = dataManager.DashTimeLevel();
                break;
            case PowerUpLevel.TIMESTOPLEVEL:
                level = dataManager.TimeStopLevel();
                break;
            case PowerUpLevel.COINCOLLECTIONLEVEL:
                level = dataManager.CoinCollectionLevel();
                break;
            case PowerUpLevel.LUCKLEVEL:
                level = dataManager.LuckLevel();
                break;
        }
        return level;
    }

    public int GetPrice(PowerUpPrice powerUpPrice)
    {
        int price = 0;

        switch (powerUpPrice)
        {
            case PowerUpPrice.DASHPRICE:
                price = dataManager.DashPrice();
                break;
            case PowerUpPrice.DASHTIMEPRICE:
                price = dataManager.DashTimePrice();
                break;
            case PowerUpPrice.TIMESTOPPRICE:
                price = dataManager.TimeStopPrice();
                break;
            case PowerUpPrice.COINCOLLECTIONPRICE:
                price = dataManager.CoinCollectionPrice();
                break;
            case PowerUpPrice.LUCKPRICE:
                price = dataManager.LuckPrice();
                break;
        }
        return price;
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

public enum PowerUpLevel
{
    DASHLEVEL,
    DASHTIMELEVEL,
    TIMESTOPLEVEL,
    COINCOLLECTIONLEVEL,
    LUCKLEVEL,
}

public enum PowerUpPrice
{
    DASHPRICE,
    DASHTIMEPRICE,
    TIMESTOPPRICE,
    COINCOLLECTIONPRICE,
    LUCKPRICE,
}
