using UnityEngine;
using System.IO;
using System.Collections.Generic;

[System.Serializable]
public class PlayerData
{
    [Header("Currency & Powerups")]
    public int currency = 0;
    public int DashLevel = 0;
    public int DashTimeLevel = 0;
    public int TimeStopLevel = 0;
    public int CoinCollectionLevel = 0;
    public int LuckLevel = 0;
    public int DashPrice = 10;
    public int DashTimePrice = 10;
    public int TimeStopPrice = 10;
    public int CoinCollectionPrice = 10;
    public int LuckPrice = 10;
}

[System.Serializable]
public class Item
{
    public string Name;
    public int level;
    public int Price;
}

[System.Serializable]
public class ItemCollection
{
    public List<Item> Items = new List<Item>();
}

public class GameDataManager
{
    private static string dataPath = Path.Combine(Application.persistentDataPath, "PlayerData.json");
    private static string itemsPath = Path.Combine(Application.persistentDataPath, "ItemsData.json");

    private PlayerData playerData;
    private ItemCollection itemCollection;

    public GameDataManager()
    {
        EnsureDataFilesExist();
        LoadPlayerData();
        LoadItemsData();
    }

    public int GetCoins()
    {
        return playerData.currency;
    }

    public int DashLevel()
    {
        return playerData.DashLevel;
    }

    public int TimeStopLevel()
    {
        return playerData.TimeStopLevel;
    }

    public int CoinCollectionLevel()
    {
        return playerData.CoinCollectionLevel;
    }

    public int DashTimeLevel()
    {
        return playerData.DashTimeLevel;
    }

    public int LuckLevel()
    {
        return playerData.LuckLevel;
    }

    public int DashPrice()
    {
        return playerData.DashPrice;
    }

    public int DashTimePrice()
    {
        return playerData.DashTimePrice;
    }

    public int TimeStopPrice()
    {
        return playerData.TimeStopPrice;
    }

    public int CoinCollectionPrice()
    {
        return playerData.CoinCollectionPrice;
    }

    public int LuckPrice()
    {
        return playerData.LuckPrice;
    }

    public void AddCoins(int amount)
    {
        playerData.currency += amount;
        SavePlayerData();
    }

    public void BuyItem(string itemName)
    {

        Item item = itemCollection.Items.Find(i => i.Name == itemName);
        if (item == null)
        {
            Debug.LogError($"Item {itemName} no encontrado.");
            return;
        }

        if (playerData.currency >= item.Price)
        {

            playerData.currency -= item.Price;
            item.level++;
            item.Price *= 5;

            UpdatePlayerDataItemLevel(itemName, item.level);
            UpdatePlayerDataItemPrice(itemName, item.Price);

            SavePlayerData();
            SaveItemsData();

            Debug.Log($" {itemName}  upgraded level {item.level}.");
        }
        else
        {
            Debug.Log("You don't have enough currency to buy this upgrade :(.");
        }
    }


    private void EnsureDataFilesExist()
    {
        if (!File.Exists(dataPath))
        {
            playerData = new PlayerData();
            File.WriteAllText(dataPath, JsonUtility.ToJson(playerData, true));
        }

        if (!File.Exists(itemsPath))
        {
            itemCollection = new ItemCollection
            {
                Items = new List<Item>
                {
                    new Item { Name = "Dash", level = 0, Price = 10 },
                    new Item { Name = "Dash time", level = 0, Price = 10 },
                    new Item { Name = "Time stop", level = 0, Price = 10 },
                    new Item { Name = "Coin collection", level = 0, Price = 10 },
                    new Item { Name = "Luck", level = 0, Price = 10 }
                }
            };
            File.WriteAllText(itemsPath, JsonUtility.ToJson(itemCollection, true));
        }
    }

    private void LoadPlayerData()
    {
        string json = File.ReadAllText(dataPath);
        playerData = JsonUtility.FromJson<PlayerData>(json);
    }

    private void LoadItemsData()
    {
        string json = File.ReadAllText(itemsPath);
        itemCollection = JsonUtility.FromJson<ItemCollection>(json);
    }

    private void SavePlayerData()
    {
        string json = JsonUtility.ToJson(playerData, true);
        File.WriteAllText(dataPath, json);
    }

    private void SaveItemsData()
    {
        string json = JsonUtility.ToJson(itemCollection, true);
        File.WriteAllText(itemsPath, json);
    }
    private void UpdatePlayerDataItemLevel(string itemName, int newLevel)
    {
        switch (itemName)
        {
            case "Dash":
                playerData.DashLevel = newLevel;
                break;
            case "Dash time":
                playerData.DashTimeLevel = newLevel;
                break;
            case "Time stop":
                playerData.TimeStopLevel = newLevel;
                break;
            case "Coin collection":
                playerData.CoinCollectionLevel = newLevel;
                break;
            case "Luck":
                playerData.LuckLevel = newLevel;
                break;
            default:
                Debug.LogError($"Ítem {itemName} no tiene un nivel asociado en PlayerData.");
                break;
        }
    }

    private void UpdatePlayerDataItemPrice(string itemName, int newPrice)
    {
        switch (itemName)
        {
            case "Dash":
                playerData.DashPrice = newPrice;
                break;
            case "Dash time":
                playerData.DashTimePrice = newPrice;
                break;
            case "Time stop":
                playerData.TimeStopPrice = newPrice;
                break;
            case "Coin collection":
                playerData.CoinCollectionPrice = newPrice;
                break;
            case "Luck":
                playerData.LuckPrice = newPrice;
                break;
            default:
                Debug.LogError($"Ítem {itemName} no tiene un precio asociado en PlayerData.");
                break;
        }
    }

}
